namespace GYMProject
{
    partial class AnaEkranAdmin
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
            newMemberButton = new Button();
            equipmentButton = new Button();
            memberList = new Button();
            LogOutButton = new Button();
            exitbutton = new Button();
            newTrainerButton = new Button();
            viewTrainersButton = new Button();
            classesButton = new Button();
            productButton = new Button();
            SuspendLayout();
            // 
            // newMemberButton
            // 
            newMemberButton.BackgroundImage = Properties.Resources.add_group__1_;
            newMemberButton.BackgroundImageLayout = ImageLayout.None;
            newMemberButton.Location = new Point(36, 37);
            newMemberButton.Margin = new Padding(3, 4, 3, 4);
            newMemberButton.Name = "newMemberButton";
            newMemberButton.Size = new Size(167, 70);
            newMemberButton.TabIndex = 0;
            newMemberButton.Text = "New Member";
            newMemberButton.TextAlign = ContentAlignment.MiddleRight;
            newMemberButton.UseVisualStyleBackColor = true;
            newMemberButton.Click += newMemberButton_Click;
            // 
            // equipmentButton
            // 
            equipmentButton.BackgroundImage = Properties.Resources.gym;
            equipmentButton.BackgroundImageLayout = ImageLayout.None;
            equipmentButton.ImageAlign = ContentAlignment.MiddleLeft;
            equipmentButton.Location = new Point(673, 37);
            equipmentButton.Margin = new Padding(3, 4, 3, 4);
            equipmentButton.Name = "equipmentButton";
            equipmentButton.Size = new Size(175, 70);
            equipmentButton.TabIndex = 1;
            equipmentButton.Text = "Equipments";
            equipmentButton.TextAlign = ContentAlignment.MiddleRight;
            equipmentButton.UseVisualStyleBackColor = true;
            equipmentButton.Click += button1_Click;
            // 
            // memberList
            // 
            memberList.BackgroundImage = Properties.Resources.file;
            memberList.BackgroundImageLayout = ImageLayout.None;
            memberList.Location = new Point(356, 37);
            memberList.Margin = new Padding(3, 4, 3, 4);
            memberList.Name = "memberList";
            memberList.Size = new Size(175, 70);
            memberList.TabIndex = 2;
            memberList.Text = "View Members";
            memberList.TextAlign = ContentAlignment.MiddleRight;
            memberList.UseVisualStyleBackColor = true;
            memberList.Click += memberList_Click;
            // 
            // LogOutButton
            // 
            LogOutButton.BackgroundImage = Properties.Resources.logout;
            LogOutButton.BackgroundImageLayout = ImageLayout.None;
            LogOutButton.ImageAlign = ContentAlignment.MiddleLeft;
            LogOutButton.Location = new Point(613, 515);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(149, 73);
            LogOutButton.TabIndex = 3;
            LogOutButton.Text = "Log Out";
            LogOutButton.TextAlign = ContentAlignment.MiddleRight;
            LogOutButton.UseVisualStyleBackColor = true;
            LogOutButton.Click += LogOutButton_Click;
            // 
            // exitbutton
            // 
            exitbutton.BackgroundImage = Properties.Resources.exit;
            exitbutton.BackgroundImageLayout = ImageLayout.None;
            exitbutton.ImageAlign = ContentAlignment.MiddleLeft;
            exitbutton.Location = new Point(784, 515);
            exitbutton.Name = "exitbutton";
            exitbutton.Size = new Size(118, 73);
            exitbutton.TabIndex = 4;
            exitbutton.Text = "Exit";
            exitbutton.TextAlign = ContentAlignment.MiddleRight;
            exitbutton.UseVisualStyleBackColor = true;
            exitbutton.Click += button1_Click_2;
            // 
            // newTrainerButton
            // 
            newTrainerButton.BackgroundImage = Properties.Resources.soccer_player;
            newTrainerButton.BackgroundImageLayout = ImageLayout.None;
            newTrainerButton.Location = new Point(36, 174);
            newTrainerButton.Name = "newTrainerButton";
            newTrainerButton.Size = new Size(167, 70);
            newTrainerButton.TabIndex = 5;
            newTrainerButton.Text = "New Trainer";
            newTrainerButton.TextAlign = ContentAlignment.MiddleRight;
            newTrainerButton.UseVisualStyleBackColor = true;
            newTrainerButton.Click += newTrainerButton_Click;
            // 
            // viewTrainersButton
            // 
            viewTrainersButton.BackgroundImage = Properties.Resources.coach;
            viewTrainersButton.BackgroundImageLayout = ImageLayout.None;
            viewTrainersButton.Location = new Point(356, 174);
            viewTrainersButton.Name = "viewTrainersButton";
            viewTrainersButton.Size = new Size(175, 70);
            viewTrainersButton.TabIndex = 6;
            viewTrainersButton.Text = "View Trainers";
            viewTrainersButton.TextAlign = ContentAlignment.MiddleRight;
            viewTrainersButton.UseVisualStyleBackColor = true;
            viewTrainersButton.Click += viewTrainersButton_Click;
            // 
            // classesButton
            // 
            classesButton.BackgroundImage = Properties.Resources.timetable;
            classesButton.BackgroundImageLayout = ImageLayout.None;
            classesButton.Location = new Point(673, 174);
            classesButton.Name = "classesButton";
            classesButton.Size = new Size(175, 70);
            classesButton.TabIndex = 7;
            classesButton.Text = "Classes      ";
            classesButton.TextAlign = ContentAlignment.MiddleRight;
            classesButton.UseVisualStyleBackColor = true;
            classesButton.Click += classesButton_Click;
            // 
            // productButton
            // 
            productButton.Location = new Point(36, 293);
            productButton.Name = "productButton";
            productButton.Size = new Size(167, 57);
            productButton.TabIndex = 8;
            productButton.Text = "Products";
            productButton.UseVisualStyleBackColor = true;
            productButton.Click += productButton_Click;
            // 
            // AnaEkranAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 600);
            Controls.Add(productButton);
            Controls.Add(classesButton);
            Controls.Add(viewTrainersButton);
            Controls.Add(newTrainerButton);
            Controls.Add(exitbutton);
            Controls.Add(LogOutButton);
            Controls.Add(memberList);
            Controls.Add(equipmentButton);
            Controls.Add(newMemberButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AnaEkranAdmin";
            Text = "AnaEkranAdmin";
            Load += AnaEkranAdmin_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button newMemberButton;
        private Button equipmentButton;
        private Button memberList;
        private Button LogOutButton;
        private Button exitbutton;
        private Button newTrainerButton;
        private Button viewTrainersButton;
        private Button classesButton;
        private Button productButton;
    }
}