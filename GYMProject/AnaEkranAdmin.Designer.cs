﻿namespace GYMProject
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
            // AnaEkranAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(newMemberButton);
            Name = "AnaEkranAdmin";
            Text = "AnaEkranAdmin";
            Load += AnaEkranAdmin_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button newMemberButton;
    }
}