namespace GYMProject
{
    partial class CustomerIncomeForm
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
            totalIncomeLabel = new Label();
            activeMembersLabel = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // totalIncomeLabel
            // 
            totalIncomeLabel.AutoSize = true;
            totalIncomeLabel.Location = new Point(3, 10);
            totalIncomeLabel.Name = "totalIncomeLabel";
            totalIncomeLabel.Size = new Size(50, 20);
            totalIncomeLabel.TabIndex = 0;
            totalIncomeLabel.Text = "label1";
            // 
            // activeMembersLabel
            // 
            activeMembersLabel.AutoSize = true;
            activeMembersLabel.Location = new Point(3, 84);
            activeMembersLabel.Name = "activeMembersLabel";
            activeMembersLabel.Size = new Size(50, 20);
            activeMembersLabel.TabIndex = 1;
            activeMembersLabel.Text = "label1";
            // 
            // panel1
            // 
            panel1.Controls.Add(totalIncomeLabel);
            panel1.Controls.Add(activeMembersLabel);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(471, 309);
            panel1.TabIndex = 2;
            // 
            // CustomerIncomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "CustomerIncomeForm";
            Text = "CustomerIncomeForm";
            Load += CustomerIncomeForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label totalIncomeLabel;
        private Label activeMembersLabel;
        private Panel panel1;
    }
}