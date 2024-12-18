namespace GYMProject
{
    partial class MyClassesForm
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
            dataGridViewMemberClasses = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMemberClasses).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMemberClasses
            // 
            dataGridViewMemberClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMemberClasses.Location = new Point(142, 66);
            dataGridViewMemberClasses.Name = "dataGridViewMemberClasses";
            dataGridViewMemberClasses.RowHeadersWidth = 51;
            dataGridViewMemberClasses.Size = new Size(556, 209);
            dataGridViewMemberClasses.TabIndex = 0;
            // 
            // MyClassesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewMemberClasses);
            Name = "MyClassesForm";
            Text = "MyClassesForm";
            Load += MyClassesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMemberClasses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMemberClasses;
    }
}