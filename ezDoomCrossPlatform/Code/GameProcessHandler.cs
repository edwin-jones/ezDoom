using System.Diagnostics;

namespace ezDoomCrossPlatform
{
    public static class GameProcessHandler
    {
        public static void RunGame(string IWADPath, string PWADPath)
        {
            var details = new ProcessStartInfo(@"engine\zdoom.exe");

#if Mac // change process details if we are deploying to a macintosh.
            details = new ProcessStartInfo("./Engine/Contents/MacOS/zdoom", string.Format("-iwad \"../../../iwads/{0}\" -file \"../../../pwads/{1}\" -savedir Saves", IWADPath, PWADPath));
            details.UseShellExecute = false;
#endif

#if !Mac
            details.Arguments = string.Format("-iwad \"../iwads/{0}\" -file \"../pwads/{1}\"  -savedir Saves", IWADPath, PWADPath);
#endif

            Process.Start(details);

        }
    }
}
