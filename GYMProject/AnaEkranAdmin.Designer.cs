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
            SuspendLayout();
            // 
            // newMemberButton
            // 
            newMemberButton.Location = new Point(47, 41);
            newMemberButton.Margin = new Padding(3, 4, 3, 4);
            newMemberButton.Name = "newMemberButton";
            newMemberButton.Size = new Size(135, 31);
            newMemberButton.TabIndex = 0;
            newMemberButton.Text = "New Member";
            newMemberButton.UseVisualStyleBackColor = true;
            newMemberButton.Click += newMemberButton_Click;
            // 
            // memberListButton
            // 
            memberListButton.Location = new Point(47, 158);
            memberListButton.Margin = new Padding(3, 4, 3, 4);
            memberListButton.Name = "memberListButton";
            memberListButton.Size = new Size(135, 31);
            memberListButton.TabIndex = 1;
            memberListButton.Text = "View Members";
            memberListButton.UseVisualStyleBackColor = true;
            memberListButton.Click += memberListButton_Click;
            // 
            // equipmentButton
            // 
            equipmentButton.Location = new Point(47, 97);
            equipmentButton.Name = "equipmentButton";
            equipmentButton.Size = new Size(135, 29);
            equipmentButton.TabIndex = 2;
            equipmentButton.Text = "Equipments";
            equipmentButton.UseVisualStyleBackColor = true;
            equipmentButton.Click += equipmentButton_Click;
            // 
            // newTrainerButton
            // 
            newTrainerButton.Location = new Point(47, 221);
            newTrainerButton.Name = "newTrainerButton";
            newTrainerButton.Size = new Size(135, 29);
            newTrainerButton.TabIndex = 3;
            newTrainerButton.Text = "New Trainer";
            newTrainerButton.UseVisualStyleBackColor = true;
            newTrainerButton.Click += newTrainerButton_Click;
            // 
            // AnaEkranAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(newTrainerButton);
            Controls.Add(equipmentButton);
            Controls.Add(memberListButton);
            Controls.Add(newMemberButton);
            Margin = new Padding(3, 4, 3, 4);
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
    }
}