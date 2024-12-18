namespace GYMProject
{
    partial class AnaEkranCustomer
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
            customerInfo = new Button();
            exitbuttonCustomer = new Button();
            LogOutButtonCustomer = new Button();
            welcomeLabel = new Label();
            myClassesButton = new Button();
            SuspendLayout();
            // 
            // customerInfo
            // 
            customerInfo.BackgroundImage = Properties.Resources.project;
            customerInfo.BackgroundImageLayout = ImageLayout.None;
            customerInfo.Location = new Point(48, 119);
            customerInfo.Name = "customerInfo";
            customerInfo.Size = new Size(167, 74);
            customerInfo.TabIndex = 0;
            customerInfo.Text = "Information";
            customerInfo.TextAlign = ContentAlignment.MiddleRight;
            customerInfo.UseVisualStyleBackColor = true;
            customerInfo.Click += customerInfo_Click;
            // 
            // exitbuttonCustomer
            // 
            exitbuttonCustomer.BackgroundImage = Properties.Resources.exit;
            exitbuttonCustomer.BackgroundImageLayout = ImageLayout.None;
            exitbuttonCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            exitbuttonCustomer.Location = new Point(671, 365);
            exitbuttonCustomer.Name = "exitbuttonCustomer";
            exitbuttonCustomer.Size = new Size(118, 73);
            exitbuttonCustomer.TabIndex = 6;
            exitbuttonCustomer.Text = "Exit";
            exitbuttonCustomer.TextAlign = ContentAlignment.MiddleRight;
            exitbuttonCustomer.UseVisualStyleBackColor = true;
            exitbuttonCustomer.Click += exitbuttonCustomer_Click;
            // 
            // LogOutButtonCustomer
            // 
            LogOutButtonCustomer.BackgroundImage = Properties.Resources.logout;
            LogOutButtonCustomer.BackgroundImageLayout = ImageLayout.None;
            LogOutButtonCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            LogOutButtonCustomer.Location = new Point(500, 365);
            LogOutButtonCustomer.Name = "LogOutButtonCustomer";
            LogOutButtonCustomer.Size = new Size(149, 73);
            LogOutButtonCustomer.TabIndex = 5;
            LogOutButtonCustomer.Text = "Log Out";
            LogOutButtonCustomer.TextAlign = ContentAlignment.MiddleRight;
            LogOutButtonCustomer.UseVisualStyleBackColor = true;
            LogOutButtonCustomer.Click += LogOutButtonCustomer_Click;
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Algerian", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeLabel.ForeColor = Color.White;
            welcomeLabel.Location = new Point(180, 19);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(0, 38);
            welcomeLabel.TabIndex = 7;
            // 
            // myClassesButton
            // 
            myClassesButton.Location = new Point(264, 119);
            myClassesButton.Name = "myClassesButton";
            myClassesButton.Size = new Size(167, 74);
            myClassesButton.TabIndex = 8;
            myClassesButton.Text = "My Classes";
            myClassesButton.UseVisualStyleBackColor = true;
            // 
            // AnaEkranCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(myClassesButton);
            Controls.Add(welcomeLabel);
            Controls.Add(exitbuttonCustomer);
            Controls.Add(LogOutButtonCustomer);
            Controls.Add(customerInfo);
            Name = "AnaEkranCustomer";
            Text = "Main Menu";
            Load += AnaEkranCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button customerInfo;
        private Button exitbuttonCustomer;
        private Button LogOutButtonCustomer;
        private Label welcomeLabel;
        private Button myClassesButton;
    }
}