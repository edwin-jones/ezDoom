using ezDoom.Code;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

namespace ezDoom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try //wrap page in a try catch so we get errors after deployment and not a rubbish xamlexception..
            {
                InitializeComponent();

                //load the relevant packages that are available to choose.
                LoadPackages(IWADSelectionComboBox, ConstStrings.IWADFolderName);
                LoadPackages(ModSelectionListView, ConstStrings.ModsFolderName);

                //hook up click events
                AddIWADButton.Click += (o, args) => AddPackage(IWADSelectionComboBox, ConstStrings.IWADFolderName);
                AddModButton.Click += (o, args) => AddPackage(ModSelectionListView, ConstStrings.ModsFolderName);

                DeleteIWADButton.Click += (o, args) =>
                {
                    if (IWADSelectionComboBox.Items.Count > 1)
                    {
                        DeletePackage(IWADSelectionComboBox, (IWADSelectionComboBox.SelectedItem as GamePackage), ConstStrings.IWADFolderName);
                    }
                    else //throw an error if the user tries to delete their last IWAD
                    {
                        MessageBox.Show("You can't delete your last IWAD!", ConstStrings.ErrorBoxTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                };

                DeleteModButton.Click += (o, args) =>
                {
                    GamePackage[] itemsToDelete = new GamePackage[ModSelectionListView.SelectedItems.Count];
                    ModSelectionListView.SelectedItems.CopyTo(itemsToDelete, 0);

                    foreach (GamePackage gp in itemsToDelete)
                    {
                        DeletePackage(ModSelectionListView, gp, ConstStrings.ModsFolderName);
                    }
                };

                //disable automatic highlighting of the first item for the modselection listview
                ModSelectionListView.SelectedItems.Clear();

                //attempt to load settings if there are any
                var loadResult = SettingsHandler.LoadSettings();

                if (loadResult != null)
                {
                    //Set the saved iwad as the selected iwad
                    foreach (GamePackage item in IWADSelectionComboBox.Items)
                    {
                        if (item.FullName == loadResult.ChosenIwadName)
                        {
                            IWADSelectionComboBox.SelectedItem = item;
                        }
                    }

                    //it is important that we set the selected mods in the SAME order that the save file specifies so as not to change this.
                    //The order of the selected items collection affects the order they are passed to GZDoom.exe and can affect how the mods work.
                    foreach (String modName in loadResult.ChosenModNames)
                    {
                        var tempGamePackage = ModSelectionListView.Items.Cast<GamePackage>().Where(gp => gp.FullName == modName).FirstOrDefault();

                        if (tempGamePackage != null)
                        {
                            ModSelectionListView.SelectedItems.Add(tempGamePackage);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// This method runs when the play button is clicked and launches the game with the selected packages.
        /// </summary>
        public void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            var IWAD = IWADSelectionComboBox.SelectedItem as GamePackage;
            var PWAD = ModSelectionListView.SelectedItem as GamePackage;
            var selectedPackages = ModSelectionListView.SelectedItems.Cast<GamePackage>();

            //run the game and save the most recently chosen settings for the next run.
            GameProcessHandler.RunGame(IWAD.FullName, selectedPackages);
            SettingsHandler.SaveSettings(IWAD, selectedPackages);

            this.Close(); //program complete, close it.
        }


        /// <summary>
        /// Attempt to load all the items from the selected folder into the relevant selectors items list.
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="packageFolderName"></param>
        void LoadPackages(Selector selector, string packageFolderName)
        {
            //check iwads folder and load everything in
            DirectoryInfo dirInfo = new DirectoryInfo(packageFolderName);

            //Get the files in the directory and store them in a list by the date they were added to the folder.
            //This is important as some wads need to be loaded in order and this allows the user to define an order to load them in with.
            List<FileInfo> fileNames = dirInfo.GetFiles("*.wad").ToList();
            fileNames.AddRange(dirInfo.GetFiles("*.pk3"));
            fileNames = fileNames.OrderBy(fn => fn.CreationTime).ToList();


            //// Get the files in the directory and add them to the selectors items list.
            foreach (var f in fileNames)
            {
                var newGamePackage = new GamePackage { FullName = f.Name };

                //only add the items if they dont already exist in the selection.
                bool alreadyExists = false;

                foreach (GamePackage gp in selector.Items)
                {
                    if(String.Equals(gp.FullName, newGamePackage.FullName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        alreadyExists = true;
                    }
                }

                if(!alreadyExists)
                {
                    selector.Items.Add(newGamePackage);
                }
            }

            //make sure the selector shows the NAME of the game package to the user, not the fullname/file extention.
            selector.DisplayMemberPath = "Name";
            if (selector is ComboBox && ((ComboBox)selector).SelectedItem == null) //default to primary item for the IWAD selector ONLY.
            {
                selector.SelectedIndex = 0;
            }
        }


        //Abstracted add package function
        void AddPackage(Selector comboBox, string folderName)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WAD files (*.wad)|*.wad";
            ofd.Multiselect = true;

            //special logic so we can add PK3 files to the mods folder.
            if (folderName.Contains(ConstStrings.ModsFolderName)) 
            {
                ofd.Filter = @"WAD/PK3 files |*.wad;*.pk3";
            }

            if (ofd.ShowDialog() == true)
            {
                try
                {
                    for (int i = 0; i < ofd.FileNames.Length; i++)
                    {
                        System.IO.File.Copy(ofd.FileNames[i], folderName + "/" + ofd.SafeFileNames[i], false);
                    }

                    LoadPackages(comboBox, folderName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ConstStrings.ErrorBoxTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        //abstracted delete wad function.
        void DeletePackage(Selector selectionBox, GamePackage itemToDelete, string folderName)
        {
            File.Delete(folderName + "/" + itemToDelete.FullName);
            selectionBox.Items.Remove(itemToDelete);
            LoadPackages(selectionBox, folderName);
        }


        //Hyperlink navigation handler
        void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
