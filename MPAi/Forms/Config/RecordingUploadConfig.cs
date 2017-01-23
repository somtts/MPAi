﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPAi.Models;
using MPAi.Cores;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.IO;

namespace MPAi.Forms.Config
{
    /// <summary>
    /// Class handling the recording file upload form.
    /// </summary>
    public partial class RecordingUploadConfig : Form
    {
        /// <summary>
        /// Set up the UI and attach the list to the database.
        /// </summary>
        public RecordingUploadConfig()
        {
            InitializeComponent();

            this.onDBListBox.DataSource = MainForm.self.DBModel.SingleFile.Local.ToBindingList();
            this.onDBListBox.DisplayMember = "Name";
        }
        /// <summary>
        /// Runs when this form is closed, clearing the local list box.
        /// </summary>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.mediaLocalListBox.DataSource = null;

            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }
        /// <summary>
        /// Copies a file from the local list box into the database, and the corresponding folder in the MPAi directory and persists it.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void toDBButton_Click(object sender, EventArgs e)
        {
            try
            {
                var DBContext = MainForm.self.DBModel;
                foreach (KeyValuePair<string, string> item in mediaLocalListBox.SelectedItems)      // For each selected item...
                {
                    String filename = item.Key.ToString();
                    NameParser paser = new NameParser();
                    paser.FullName = filename;          // Put the name into the parser
                    // Set the parser address to the audio or video folder as appropriate. 
                    if (paser.MediaFormat == "audio") paser.Address = Properties.Settings.Default.AudioFolder;
                    else if (paser.MediaFormat == "video") paser.Address = Properties.Settings.Default.VideoFolder;
                    // Get the file and add it to the database context.
                    DBContext.AddOrUpdateRecordingFile(paser.SingleFile);
                    // Copy the existing local file into the audio/video folder if it wasn't already there.
                    string existingFile = item.Value + "\\" + item.Key;
                    string newFile = paser.Address + "\\" + item.Key;
                    if (!existingFile.Equals(newFile))
                    {
                        File.Copy(existingFile, newFile, true);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                MessageBox.Show("Fail to update!");
            }
        }
        /// <summary>
        /// When clicking the button to remove a(some) file(s) from the database, removes the file(s) and any parent objects.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void toLocalButton_Click(object sender, EventArgs e)
        {
            try
            {
                var DBContext = MainForm.self.DBModel;

                // Creating a copy of the list box selected items to iterate through
                List<SingleFile> selectedItemsCopy = new List<SingleFile>();
                foreach (SingleFile sf in onDBListBox.SelectedItems)
                {
                    selectedItemsCopy.Add(sf);
                }

                // For each item in the database list box...
                foreach (SingleFile sf in selectedItemsCopy)
                { 
                    Recording rd = null;
                    NameParser paser = new NameParser();
                    paser.FullName = sf.Name;       // Add the file to the Parser
                    // Use the parser to create the model objects.
                    if (paser.MediaFormat == "audio") rd = sf.Audio;
                    else if (paser.MediaFormat == "video") rd = sf.Video;
                    Speaker spk = rd.Speaker;
                    Word word = rd.Word;
                    Category cty = word.Category;
                    string existingFile = sf.Address + "\\" + sf.Name;
                    if (File.Exists(existingFile))      // If the file already exists,
                    {
                        File.Delete(existingFile);      // Delete it,
                    }
                    DBContext.SingleFile.Remove(sf);    // And remove it from the database.

                    // If the deleted file was: 
                    if(rd.Audios.Count == 0 && rd.Video == null) DBContext.Recording.Remove(rd);    // The last file attached to a recording, then delete the recording.
                    if (spk.Recordings.Count == 0) DBContext.Speaker.Remove(spk);                   // The last recording attached to a speaker, then delete the speaker.
                    if (word.Recordings.Count == 0) DBContext.Word.Remove(word);                    // The last recording attached to a word, then delete the word.
                    if (cty.Words.Count == 0) DBContext.Category.Remove(cty);                       // The last word attached to a category, then delete the category.
                }
                MainForm.self.DBModel.SaveChanges();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Fail to delete!");
            }
        }
        /// <summary>
        /// When the "all" button is clicked, highlights all items in the selected list box.
        /// The button also changes function to the "none" button, deselecting all items in the selected list box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void allItemsButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button bt = sender as Button;
                bool value = false;
                ListBox operatingListBox = null;

                // Update button text, and specify the function of this method.
                if (bt.Text == "All") { value = true; bt.Text = "None"; }
                else if (bt.Text == "None") { value = false; bt.Text = "All"; }
                
                //Select the list box to work on
                if (DBRadioButton.Checked) operatingListBox = onDBListBox;
                else if (localRadioButton.Checked) operatingListBox = mediaLocalListBox;
                if(operatingListBox == null)
                {
                    MessageBox.Show("Please choose a listbox to operate on first!");
                }
                else
                {
                    for (int i = 0; i < operatingListBox.Items.Count; i++)  // For each item...
                    {
                        operatingListBox.SetSelected(i, value); // Select or deselect it, as appropriate.
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message,"Fail to pick all items!");
            }
        }
        /// <summary>
        /// Opens a dialog box allowing the user to choose a file from their computer to add to the local list box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Put all the file names and file paths that the user selected into an array each.
                    String[] fileNames = openFileDialog.FileNames.Select(x => x = x.Substring(x.LastIndexOf('\\') + 1)).ToArray();
                    String[] fileAddresses = openFileDialog.FileNames.Select(x => x = x.Substring(0, x.LastIndexOf('\\'))).ToArray();
                    // Convert the file names and addresses into key/value pairs, and store them in a dictionary.
                    Dictionary<string, string> dataSource = fileNames.Zip(fileAddresses, (lText, lValue) => new { lText, lValue }).ToDictionary(x => x.lText, x => x.lValue);

                    ListBox localListBox = this.mediaLocalListBox;
                    localListBox.DataSource = new BindingSource() { DataSource = dataSource };  // Replace the values in the list box with the new dictionary.
                    localListBox.DisplayMember = "Key";     // Display the names.
                    localListBox.ValueMember = "Value";     // Retain the full path for calculations, but don't display it.
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
    }
}
