namespace GYMProject
{
    partial class CustomerInfo
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
            dataGridViewUserInfo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserInfo).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUserInfo
            // 
            dataGridViewUserInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUserInfo.Location = new Point(21, 44);
            dataGridViewUserInfo.Name = "dataGridViewUserInfo";
            dataGridViewUserInfo.RowHeadersWidth = 51;
            dataGridViewUserInfo.Size = new Size(767, 394);
            dataGridViewUserInfo.TabIndex = 0;
            // 
            // CustomerInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewUserInfo);
            Name = "CustomerInfo";
            Text = "CustomerInfo";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUserInfo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewUserInfo;
    }
}