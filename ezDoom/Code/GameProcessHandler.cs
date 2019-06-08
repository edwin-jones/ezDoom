using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

            //Store game saves in the user's saved games folder.
            var userDirectory = Environment.ExpandEnvironmentVariables("%USERPROFILE%");
            var savesDirectory = Path.Combine(userDirectory, "Saved Games", "ezDoom");
            savesDirectory = string.Format("\"{0}\"", savesDirectory);

            //launch GZDoom with the correct args.
            details.Arguments = string.Format("-iwad \"../iwads/{0}\" -file {1}  -savedir {2}", IWADPath, chosenPackages, savesDirectory);

            //we wrap the process in a using statement to make sure the handle is always disposed after use.
            using (Process process = Process.Start(details)) { };
        }
    }
}
