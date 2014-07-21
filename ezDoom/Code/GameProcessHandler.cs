using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Text;

namespace ezDoom.Code
{
    /// <summary>
    /// This class handles launching the doom engine with chosen settings.
    /// </summary>
    public static class GameProcessHandler
    {
        /// <summary>
        /// This method launches the doom engine with chosen settings.
        /// </summary>
        public static void RunGame(string IWADPath, IEnumerable<GamePackage> mods)
        {
            //use a string builder to take all the chosen mods and turn them into a string we can pass as an argument.
            StringBuilder sb = new StringBuilder();
            foreach (GamePackage item in mods)
            {
                sb.AppendFormat(" \"../{0}/{1}\" ", ConstStrings.ModsFolderName, item.FullName);
            }

            string chosenPackages = sb.ToString();

            //create process to launch the game.
            var details = new ProcessStartInfo(ConstStrings.EngineFolderName + "/gzdoom.exe");
            details.UseShellExecute = false; //we need to set UseShellExecute to false to make the exe run from the local folder.

            //attempt to use the clickonce data directory folder for saves to keep them persistent between updates.
            //Default to the /Saves directory if this fails.
            var savesDirectory = "/Saves";
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                savesDirectory = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory;
            }

            //launch GZDoom with the correct args.
            details.Arguments = string.Format("-iwad \"../iwads/{0}\" -file {1}  -savedir {2}", IWADPath, chosenPackages, savesDirectory);

            //we wrap the process in a using statement to make sure the handle is always disposed after use.
            using (Process process = Process.Start(details)) { };
        }
    }
}
