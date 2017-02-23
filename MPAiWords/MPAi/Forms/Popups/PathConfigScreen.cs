﻿using MPAi.Components;
using MPAi.Cores;
using System;
using System.IO;
using System.Windows.Forms;

namespace MPAi.Forms.Popups
{
    /// <summary>
    /// Class for the system configuration form.
    /// </summary>
    public partial class SystemConfig : Form
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SystemConfig()
        {
            InitializeComponent();
            InitializeContent();
        }
        /// <summary>
        /// Initialises all text boxes, and fills them in with values from the current system settings.
        /// </summary>
        public void InitializeContent()
        {
            try
            {
                // Audio folder.
                InitializeTextBox(this.audioFolderTextBox, DirectoryManagement.AudioFolder);
                // Recording folder.
                InitializeTextBox(this.recordingFolderTextBox, DirectoryManagement.RecordingFolder);
                // Report folder.
                InitializeTextBox(this.reportFolderTextBox, DirectoryManagement.ScoreboardReportFolder);
                // HTK folder.
                InitializeTextBox(this.HTKFolderTextBox, DirectoryManagement.HTKFolder);
            }
            catch(Exception exp)
            {
                MPAiMessageBoxFactory.Show(exp.Message);
            }
        }
        /// <summary>
        /// Populates the text boxes on the form and creates the referenced directories if they don't already exist.
        /// </summary>
        /// <param name="tb">The text box to initialise.</param>
        /// <param name="dir">The directory to create (if needed) and fill the text box with.</param>
        private void InitializeTextBox(TextBox tb, string dir)
        {
            try
            {
                Directory.CreateDirectory(dir);
                tb.Text = dir;
            }
            catch(Exception exp)
            {
                MPAiMessageBoxFactory.Show(exp.Message);
            }
        }
        /// <summary>
        /// When the save button is clicked, saves the changes to the settings and closes the window.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            DirectoryManagement.AudioFolder = audioFolderTextBox.Text;
            DirectoryManagement.RecordingFolder = recordingFolderTextBox.Text;
            DirectoryManagement.ScoreboardReportFolder = reportFolderTextBox.Text;
            DirectoryManagement.HTKFolder = HTKFolderTextBox.Text;
            DirectoryManagement.WritePaths();
            Close();
        }
        /// <summary>
        /// When the button to select the audio folder is clicked, opens a dialog allowing the user to navigate to their directory of choice.
        /// Once the user confirms their selection, updates the appropriate text box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void audioFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                audioFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
       
        /// <summary>
        /// When the button to select the recording folder is clicked, opens a dialog allowing the user to navigate to their directory of choice.
        /// Once the user confirms their selection, updates the appropriate text box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void recordingFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                recordingFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        /// <summary>
        /// When the button to select the report folder is clicked, opens a dialog allowing the user to navigate to their directory of choice.
        /// Once the user confirms their selection, updates the appropriate text box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void reportFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                reportFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        /// <summary>
        /// When the button to select the HTK folder is clicked, opens a dialog allowing the user to navigate to their directory of choice.
        /// Once the user confirms their selection, updates the appropriate text box.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void HTKFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                HTKFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// When the cancel button is clicked, close the form without saving folder changes.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}