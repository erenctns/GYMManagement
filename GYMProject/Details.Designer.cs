namespace GYMProject
{
    partial class Details
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
            classDetailsButton = new Button();
            expirationButton = new Button();
            panelMembers = new Panel();
            pictureBoxMembers = new PictureBox();
            membersLabel = new Label();
            activeMembersLabel = new Label();
            panelStaffs = new Panel();
            pictureBoxStaffs = new PictureBox();
            label1 = new Label();
            trainerCountLabel = new Label();
            panelClasses = new Panel();
            pictureBoxClasses = new PictureBox();
            label3 = new Label();
            classCountLabel = new Label();
            panelMoney = new Panel();
            pictureBoxMoney = new PictureBox();
            totalIncomeLabel = new Label();
            panelMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMembers).BeginInit();
            panelStaffs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStaffs).BeginInit();
            panelClasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClasses).BeginInit();
            panelMoney.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMoney).BeginInit();
            SuspendLayout();
            // 
            // classDetailsButton
            // 
            classDetailsButton.BackgroundImageLayout = ImageLayout.None;
            classDetailsButton.Location = new Point(221, 27);
            classDetailsButton.Name = "classDetailsButton";
            classDetailsButton.Size = new Size(166, 74);
            classDetailsButton.TabIndex = 0;
            classDetailsButton.Text = "Class Details";
            classDetailsButton.TextAlign = ContentAlignment.MiddleRight;
            classDetailsButton.UseVisualStyleBackColor = true;
            classDetailsButton.Click += showIncomesButton_Click;
            // 
            // expirationButton
            // 
            expirationButton.BackgroundImage = Properties.Resources.deadline;
            expirationButton.BackgroundImageLayout = ImageLayout.None;
            expirationButton.Location = new Point(12, 27);
            expirationButton.Name = "expirationButton";
            expirationButton.Size = new Size(166, 74);
            expirationButton.TabIndex = 1;
            expirationButton.Text = "Expirations";
            expirationButton.TextAlign = ContentAlignment.MiddleRight;
            expirationButton.UseVisualStyleBackColor = true;
            expirationButton.Click += expirationButton_Click;
            // 
            // panelMembers
            // 
            panelMembers.BackColor = Color.MediumAquamarine;
            panelMembers.Controls.Add(pictureBoxMembers);
            panelMembers.Controls.Add(membersLabel);
            panelMembers.Controls.Add(activeMembersLabel);
            panelMembers.Location = new Point(12, 371);
            panelMembers.Name = "panelMembers";
            panelMembers.Size = new Size(232, 120);
            panelMembers.TabIndex = 2;
            // 
            // pictureBoxMembers
            // 
            pictureBoxMembers.BackgroundImage = Properties.Resources.icons8_person_64;
            pictureBoxMembers.BackgroundImageLayout = ImageLayout.None;
            pictureBoxMembers.Location = new Point(83, 14);
            pictureBoxMembers.Name = "pictureBoxMembers";
            pictureBoxMembers.Size = new Size(64, 64);
            pictureBoxMembers.TabIndex = 6;
            pictureBoxMembers.TabStop = false;
            // 
            // membersLabel
            // 
            membersLabel.AutoSize = true;
            membersLabel.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            membersLabel.ForeColor = Color.White;
            membersLabel.Location = new Point(102, 89);
            membersLabel.Name = "membersLabel";
            membersLabel.Size = new Size(67, 18);
            membersLabel.TabIndex = 6;
            membersLabel.Text = "Members";
            // 
            // activeMembersLabel
            // 
            activeMembersLabel.AutoSize = true;
            activeMembersLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            activeMembersLabel.ForeColor = Color.White;
            activeMembersLabel.Location = new Point(68, 78);
            activeMembersLabel.Name = "activeMembersLabel";
            activeMembersLabel.Size = new Size(79, 31);
            activeMembersLabel.TabIndex = 6;
            activeMembersLabel.Text = "label1";
            // 
            // panelStaffs
            // 
            panelStaffs.BackColor = Color.CornflowerBlue;
            panelStaffs.Controls.Add(pictureBoxStaffs);
            panelStaffs.Controls.Add(label1);
            panelStaffs.Controls.Add(trainerCountLabel);
            panelStaffs.Location = new Point(270, 371);
            panelStaffs.Name = "panelStaffs";
            panelStaffs.Size = new Size(232, 120);
            panelStaffs.TabIndex = 3;
            // 
            // pictureBoxStaffs
            // 
            pictureBoxStaffs.BackgroundImage = Properties.Resources.icons8_queue_64;
            pictureBoxStaffs.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxStaffs.Location = new Point(90, 14);
            pictureBoxStaffs.Name = "pictureBoxStaffs";
            pictureBoxStaffs.Size = new Size(64, 64);
            pictureBoxStaffs.TabIndex = 9;
            pictureBoxStaffs.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(90, 89);
            label1.Name = "label1";
            label1.Size = new Size(97, 18);
            label1.TabIndex = 7;
            label1.Text = "Staffs/Trainers";
            // 
            // trainerCountLabel
            // 
            trainerCountLabel.AutoSize = true;
            trainerCountLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            trainerCountLabel.ForeColor = Color.White;
            trainerCountLabel.Location = new Point(69, 78);
            trainerCountLabel.Name = "trainerCountLabel";
            trainerCountLabel.Size = new Size(79, 31);
            trainerCountLabel.TabIndex = 8;
            trainerCountLabel.Text = "label1";
            // 
            // panelClasses
            // 
            panelClasses.BackColor = Color.Salmon;
            panelClasses.Controls.Add(pictureBoxClasses);
            panelClasses.Controls.Add(label3);
            panelClasses.Controls.Add(classCountLabel);
            panelClasses.Location = new Point(524, 371);
            panelClasses.Name = "panelClasses";
            panelClasses.Size = new Size(232, 120);
            panelClasses.TabIndex = 4;
            // 
            // pictureBoxClasses
            // 
            pictureBoxClasses.BackgroundImage = Properties.Resources.icons8_gym_64;
            pictureBoxClasses.BackgroundImageLayout = ImageLayout.None;
            pictureBoxClasses.Location = new Point(92, 14);
            pictureBoxClasses.Name = "pictureBoxClasses";
            pictureBoxClasses.Size = new Size(64, 64);
            pictureBoxClasses.TabIndex = 9;
            pictureBoxClasses.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.White;
            label3.Location = new Point(112, 89);
            label3.Name = "label3";
            label3.Size = new Size(53, 18);
            label3.TabIndex = 7;
            label3.Text = "Classes";
            // 
            // classCountLabel
            // 
            classCountLabel.AutoSize = true;
            classCountLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            classCountLabel.ForeColor = Color.White;
            classCountLabel.Location = new Point(86, 78);
            classCountLabel.Name = "classCountLabel";
            classCountLabel.Size = new Size(79, 31);
            classCountLabel.TabIndex = 8;
            classCountLabel.Text = "label1";
            // 
            // panelMoney
            // 
            panelMoney.BackColor = Color.PaleGoldenrod;
            panelMoney.Controls.Add(pictureBoxMoney);
            panelMoney.Controls.Add(totalIncomeLabel);
            panelMoney.Location = new Point(777, 371);
            panelMoney.Name = "panelMoney";
            panelMoney.Size = new Size(232, 120);
            panelMoney.TabIndex = 5;
            // 
            // pictureBoxMoney
            // 
            pictureBoxMoney.BackgroundImage = Properties.Resources.icons8_money_48;
            pictureBoxMoney.BackgroundImageLayout = ImageLayout.None;
            pictureBoxMoney.Location = new Point(93, 14);
            pictureBoxMoney.Name = "pictureBoxMoney";
            pictureBoxMoney.Size = new Size(64, 64);
            pictureBoxMoney.TabIndex = 9;
            pictureBoxMoney.TabStop = false;
            // 
            // totalIncomeLabel
            // 
            totalIncomeLabel.AutoSize = true;
            totalIncomeLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            totalIncomeLabel.ForeColor = Color.White;
            totalIncomeLabel.Location = new Point(58, 76);
            totalIncomeLabel.Name = "totalIncomeLabel";
            totalIncomeLabel.Size = new Size(79, 31);
            totalIncomeLabel.TabIndex = 8;
            totalIncomeLabel.Text = "label1";
            // 
            // Details
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1029, 503);
            Controls.Add(panelMoney);
            Controls.Add(panelClasses);
            Controls.Add(panelStaffs);
            Controls.Add(panelMembers);
            Controls.Add(expirationButton);
            Controls.Add(classDetailsButton);
            Name = "Details";
            Text = "Details";
            Load += Details_Load;
            panelMembers.ResumeLayout(false);
            panelMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMembers).EndInit();
            panelStaffs.ResumeLayout(false);
            panelStaffs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStaffs).EndInit();
            panelClasses.ResumeLayout(false);
            panelClasses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClasses).EndInit();
            panelMoney.ResumeLayout(false);
            panelMoney.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMoney).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button classDetailsButton;
        private Button expirationButton;
        private Panel panelMembers;
        private Panel panelStaffs;
        private Panel panelClasses;
        private Panel panelMoney;
        private Label activeMembersLabel;
        private Label membersLabel;
        private Label label1;
        private Label trainerCountLabel;
        private Label label3;
        private Label classCountLabel;
        private Label totalIncomeLabel;
        private PictureBox pictureBoxStaffs;
        private PictureBox pictureBoxMembers;
        private PictureBox pictureBoxClasses;
        private PictureBox pictureBoxMoney;
    }
}