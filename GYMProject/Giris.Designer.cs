using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GYMProject
{
    partial class Giris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userNameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            userNameLabel = new Label();
            passwordLabel = new Label();
            loginButton = new Button();
            SuspendLayout();
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(265, 163);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(100, 23);
            userNameTextBox.TabIndex = 0;
            userNameTextBox.TextChanged += userNameTextBox_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(265, 237);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 1;
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(268, 121);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(60, 15);
            userNameLabel.TabIndex = 2;
            userNameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(272, 208);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(276, 295);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // Giris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginButton);
            Controls.Add(passwordLabel);
            Controls.Add(userNameLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(userNameTextBox);
            Name = "Giris";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userNameTextBox;
        private TextBox passwordTextBox;
        private Label userNameLabel;
        private Label passwordLabel;
        private Button loginButton;
    }
}
