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
            var details = new ProcessStartInfo(Path.Combine(ConstStrings.EngineFolderName, ConstStrings.GzDoomExeName));
            details.UseShellExecute = false; //we need to set UseShellExecute to false to make the exe run from the local folder.

            //Store game saves in the user's saved games folder.
            var userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var savesDirectoryRaw = Path.Combine(userDirectory, ConstStrings.GameSaveFolderName);
            var savesDirectory = string.Format("\"{0}\"", savesDirectoryRaw).Replace(@"\", "/");

            //launch GZDoom with the correct args.
            details.Arguments = $@"-iwad ../iwads/{IWADPath} -file {chosenPackages} -savedir {savesDirectory}";

            //we wrap the process in a using statement to make sure the handle is always disposed after use.
            using (Process process = Process.Start(details)) { };
        }
    }
}
