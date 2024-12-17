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
            panel1 = new Panel();
            eyePictureBox = new PictureBox();
            logoName2 = new Label();
            logoName1 = new Label();
            logoBox = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eyePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(73, 210);
            userNameTextBox.Margin = new Padding(3, 4, 3, 4);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(180, 27);
            userNameTextBox.TabIndex = 0;
            userNameTextBox.TextChanged += userNameTextBox_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(73, 292);
            passwordTextBox.Margin = new Padding(3, 4, 3, 4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(180, 27);
            passwordTextBox.TabIndex = 1;
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            userNameLabel.Location = new Point(73, 186);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(78, 20);
            userNameLabel.TabIndex = 2;
            userNameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            passwordLabel.Location = new Point(73, 268);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(73, 20);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(119, 361);
            loginButton.Margin = new Padding(3, 4, 3, 4);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(86, 31);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(eyePictureBox);
            panel1.Controls.Add(logoName2);
            panel1.Controls.Add(logoName1);
            panel1.Controls.Add(logoBox);
            panel1.Controls.Add(userNameLabel);
            panel1.Controls.Add(loginButton);
            panel1.Controls.Add(userNameTextBox);
            panel1.Controls.Add(passwordTextBox);
            panel1.Controls.Add(passwordLabel);
            panel1.Location = new Point(298, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(327, 431);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // eyePictureBox
            // 
            eyePictureBox.BackColor = SystemColors.Window;
            eyePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            eyePictureBox.BorderStyle = BorderStyle.FixedSingle;
            eyePictureBox.Location = new Point(224, 292);
            eyePictureBox.Name = "eyePictureBox";
            eyePictureBox.Size = new Size(29, 27);
            eyePictureBox.TabIndex = 8;
            eyePictureBox.TabStop = false;
            eyePictureBox.Click += eyePictureBox_Click;
            // 
            // logoName2
            // 
            logoName2.AutoSize = true;
            logoName2.Font = new System.Drawing.Font("Stencil", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoName2.Location = new Point(116, 123);
            logoName2.Name = "logoName2";
            logoName2.Size = new Size(102, 27);
            logoName2.TabIndex = 7;
            logoName2.Text = "Center";
            // 
            // logoName1
            // 
            logoName1.AutoSize = true;
            logoName1.Font = new System.Drawing.Font("Stencil", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoName1.Location = new Point(83, 96);
            logoName1.Name = "logoName1";
            logoName1.Size = new Size(170, 27);
            logoName1.TabIndex = 6;
            logoName1.Text = "Algo Sports";
            // 
            // logoBox
            // 
            logoBox.BackgroundImage = Properties.Resources.dumbell;
            logoBox.BackgroundImageLayout = ImageLayout.Stretch;
            logoBox.Location = new Point(123, 17);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(95, 76);
            logoBox.TabIndex = 5;
            logoBox.TabStop = false;
            // 
            // Giris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 600);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Giris";
            Text = "Welcome";
            Load += Giris_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eyePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox userNameTextBox;
        private TextBox passwordTextBox;
        private Label userNameLabel;
        private Label passwordLabel;
        private Button loginButton;
        private Panel panel1;
        private PictureBox logoBox;
        private Label logoName1;
        private Label logoName2;
        private PictureBox eyePictureBox;
    }
}
