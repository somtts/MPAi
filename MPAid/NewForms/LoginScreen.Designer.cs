﻿namespace MPAid.NewForms
{
    partial class LoginScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.signupButton = new System.Windows.Forms.Button();
            this.rememberCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoBox
            // 
            this.logoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoBox.BackgroundImage")));
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoBox.Location = new System.Drawing.Point(3, 3);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(280, 118);
            this.logoBox.TabIndex = 15;
            this.logoBox.TabStop = false;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.userNameTextBox.Location = new System.Drawing.Point(12, 127);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(260, 20);
            this.userNameTextBox.TabIndex = 16;
            this.userNameTextBox.Text = "Username...";
            this.userNameTextBox.Enter += new System.EventHandler(this.userNameTextBox_Enter);
            this.userNameTextBox.Leave += new System.EventHandler(this.userNameTextBox_Leave);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.passwordTextBox.Location = new System.Drawing.Point(12, 162);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(260, 20);
            this.passwordTextBox.TabIndex = 17;
            this.passwordTextBox.Text = "Password...";
            this.passwordTextBox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            this.passwordTextBox.Leave += new System.EventHandler(this.passwordTextBox_Leave);
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.Location = new System.Drawing.Point(12, 227);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 18;
            this.loginButton.Text = "Log In";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // signupButton
            // 
            this.signupButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.signupButton.Location = new System.Drawing.Point(197, 227);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(75, 23);
            this.signupButton.TabIndex = 19;
            this.signupButton.Text = "Sign Up";
            this.signupButton.UseVisualStyleBackColor = true;
            // 
            // rememberCheckBox
            // 
            this.rememberCheckBox.AutoSize = true;
            this.rememberCheckBox.Location = new System.Drawing.Point(100, 199);
            this.rememberCheckBox.Name = "rememberCheckBox";
            this.rememberCheckBox.Size = new System.Drawing.Size(95, 17);
            this.rememberCheckBox.TabIndex = 20;
            this.rememberCheckBox.Text = "Remember Me";
            this.rememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.rememberCheckBox);
            this.Controls.Add(this.signupButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.logoBox);
            this.Name = "LoginScreen";
            this.Text = "LoginScreen";
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.CheckBox rememberCheckBox;
    }
}