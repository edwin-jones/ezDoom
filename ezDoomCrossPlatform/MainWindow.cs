using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ezDoomCrossPlatform
{
    public partial class MainWindow : Form
    {
        const string none = "None.wad";
        const string IWADFolderName = "IWADS";
        const string PWADFolderName = "PWADS";
        const string ErrorBoxTitle = "ezDoom Error";

        public MainWindow()
        {
            InitializeComponent();

            LoadWADS(IWADSelectionComboBox, IWADFolderName);
            LoadWADS(PWADSelectionComboBox, PWADFolderName);

            //hook up click events
            AddIWADButton.Click += (o, args) => AddWAD(IWADSelectionComboBox, IWADFolderName);
            AddPWADButton.Click += (o, args) => AddWAD(PWADSelectionComboBox, PWADFolderName);
            DeleteIWADButton.Click += (o, args) => DeleteWAD(IWADSelectionComboBox, IWADFolderName);
            DeletePWADButton.Click += (o, args) => DeleteWAD(PWADSelectionComboBox, PWADFolderName);
        }

        void PlayButton_Click(object sender, EventArgs e)
        {
            var IWAD = IWADSelectionComboBox.SelectedItem as WADDetail;
            var PWAD = PWADSelectionComboBox.SelectedItem as WADDetail;

            if (PWAD.Path == none) //no pwad selected, run game with just an IWAD
            {
                GameProcessHandler.RunGame(IWAD.Path, string.Empty);
            }
            else //run game with iwad and pwad
            {
                GameProcessHandler.RunGame(IWAD.Path, PWAD.Path);
            }

            this.Close();
        }


        public void LoadWADS(ComboBox comboBox, string wadFolderName)
        {
            comboBox.Items.Clear();

            ///check iwads folder and load everything in
            DirectoryInfo dirInfo = new DirectoryInfo(wadFolderName);

            //add empty default PWAD
            if (wadFolderName.ToLower() == "pwads")
            {
                var defaultWADInfo = new WADDetail { Path = none };
                PWADSelectionComboBox.Items.Add(defaultWADInfo);
            }

            //// Get the files in the directory and print out some information about them.
            FileInfo[] fileNames = dirInfo.GetFiles("*.wad");


            //// Get the files in the directory and print out some information about them.
            foreach (var f in fileNames)
            {
                var wD = new WADDetail { Path = f.Name };

                comboBox.Items.Add(wD);
            }

            comboBox.DisplayMember  = "Name";
            comboBox.SelectedIndex = 0;
        }

        //Abstracted add wad function
        void AddWAD(ComboBox comboBox, string folderName)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WAD files (*.wad)|*.wad";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var newWADPath = folderName + "/" + ofd.SafeFileName;
                var wadPath = ofd.FileName;

                // Copy file
                //30-07-12 added try/catch to stop same file name errors and more.
                try
                {
                    System.IO.File.Copy(wadPath, newWADPath, false);

                    LoadWADS(comboBox, folderName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ErrorBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //abstracted delete wad function.
        void DeleteWAD(ComboBox comboBox, string folderName)
        {
            var tempWADDetail = comboBox.SelectedItem as WADDetail;

            //Throw warning message if user tries to delete last game wad, ignoring patch/mod wads.
            if (comboBox.Items.Count > 1 || (comboBox.Items[0] as WADDetail).Name == "None")
            {
                File.Delete(folderName + "/" + tempWADDetail.Path);
                LoadWADS(comboBox, folderName);
            }
            else
            {
                MessageBox.Show("Cannot delete last WAD!", ErrorBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
