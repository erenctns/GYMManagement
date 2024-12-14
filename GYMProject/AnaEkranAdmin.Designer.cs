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
            memberListButton = new Button();
            equipmentButton = new Button();
            newTrainerButton = new Button();
            viewTrainersButton = new Button();
            classesButton = new Button();
            SuspendLayout();
            // 
            // newMemberButton
            // 
            newMemberButton.Location = new Point(41, 31);
            newMemberButton.Name = "newMemberButton";
            newMemberButton.Size = new Size(118, 23);
            newMemberButton.TabIndex = 0;
            newMemberButton.Text = "New Member";
            newMemberButton.UseVisualStyleBackColor = true;
            newMemberButton.Click += newMemberButton_Click;
            // 
            // memberListButton
            // 
            memberListButton.Location = new Point(41, 118);
            memberListButton.Name = "memberListButton";
            memberListButton.Size = new Size(118, 23);
            memberListButton.TabIndex = 1;
            memberListButton.Text = "View Members";
            memberListButton.UseVisualStyleBackColor = true;
            memberListButton.Click += memberListButton_Click;
            // 
            // equipmentButton
            // 
            equipmentButton.Location = new Point(41, 73);
            equipmentButton.Margin = new Padding(3, 2, 3, 2);
            equipmentButton.Name = "equipmentButton";
            equipmentButton.Size = new Size(118, 22);
            equipmentButton.TabIndex = 2;
            equipmentButton.Text = "Equipments";
            equipmentButton.UseVisualStyleBackColor = true;
            equipmentButton.Click += equipmentButton_Click;
            // 
            // newTrainerButton
            // 
            newTrainerButton.Location = new Point(41, 166);
            newTrainerButton.Margin = new Padding(3, 2, 3, 2);
            newTrainerButton.Name = "newTrainerButton";
            newTrainerButton.Size = new Size(118, 22);
            newTrainerButton.TabIndex = 3;
            newTrainerButton.Text = "New Trainer";
            newTrainerButton.UseVisualStyleBackColor = true;
            newTrainerButton.Click += newTrainerButton_Click;
            // 
            // viewTrainersButton
            // 
            viewTrainersButton.Location = new Point(41, 211);
            viewTrainersButton.Name = "viewTrainersButton";
            viewTrainersButton.Size = new Size(118, 23);
            viewTrainersButton.TabIndex = 4;
            viewTrainersButton.Text = "View Trainers";
            viewTrainersButton.UseVisualStyleBackColor = true;
            viewTrainersButton.Click += viewTrainersButton_Click;
            // 
            // classesButton
            // 
            classesButton.Location = new Point(41, 260);
            classesButton.Name = "classesButton";
            classesButton.Size = new Size(118, 23);
            classesButton.TabIndex = 5;
            classesButton.Text = "Classes";
            classesButton.UseVisualStyleBackColor = true;
            classesButton.Click += classesButton_Click;
            // 
            // AnaEkranAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(classesButton);
            Controls.Add(viewTrainersButton);
            Controls.Add(newTrainerButton);
            Controls.Add(equipmentButton);
            Controls.Add(memberListButton);
            Controls.Add(newMemberButton);
            Name = "AnaEkranAdmin";
            Text = "AnaEkranAdmin";
            Load += AnaEkranAdmin_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button newMemberButton;
        private Button memberListButton;
        private Button equipmentButton;
        private Button newTrainerButton;
        private Button viewTrainersButton;
        private Button classesButton;
    }
}