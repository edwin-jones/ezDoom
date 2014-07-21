using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace ezDoom.Code
{
    /// <summary>
    /// This class handles loading and saving ezDoom settings information so we can persist the user's preferrered options.
    /// </summary>
    public static class SettingsHandler
    {
        /// <summary>
        /// This function loads the settings file values, if it exists and they are valid. Returns null if no valid settings found.
        /// </summary>
        /// <returns></returns>
        public static SettingsLoadResult LoadSettings()
        {
            SettingsLoadResult loadResult = null;
            if (System.IO.File.Exists(ConstStrings.SaveFileName)) //only try to load the file if it exists!
            {
                try //to load the settings from an xml save file if it exists.
                {
                    loadResult = new SettingsLoadResult();
                    XDocument doc = XDocument.Load(ConstStrings.SaveFileName);

                    loadResult.ChosenIwadName = doc.Root.Element(ConstStrings.IwadNodeName).Value;
                    var mods = doc.Root.Element(ConstStrings.ModRootNodeName).Descendants().ToList();

                    foreach (XElement xe in mods)
                    {
                        loadResult.ChosenModNames.Add(xe.Value);
                    }
                }
                catch (Exception) //warn user on error.
                {
                    System.Windows.MessageBox.Show("Settings file has invalid data or could not be loaded.", ConstStrings.ErrorBoxTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            return loadResult;
        }

        /// <summary>
        /// This function saves the current ezdoom options to an xml file.
        /// </summary>
        public static void SaveSettings(GamePackage iwad, IEnumerable<GamePackage> mods)
        {
            var xDoc = new XDocument(
                new XElement(ConstStrings.RootNodeName,
                    new XElement(ConstStrings.IwadNodeName, iwad.FullName),
                    new XElement(ConstStrings.ModRootNodeName,
                        from m in mods
                        select new XElement(ConstStrings.ModNodeName, m.FullName))));

            xDoc.Save(ConstStrings.SaveFileName);
        }
    }

    /// <summary>
    /// This class represents the result of a load operation for the SettingsHandler class.
    /// </summary>
    public class SettingsLoadResult
    {
        public SettingsLoadResult()
        {
            ChosenModNames = new List<string>();
        }

        public string ChosenIwadName { get; set; }
        public List<string> ChosenModNames { get; set; }
    }
}
