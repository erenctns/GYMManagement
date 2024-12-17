namespace GYMProject
{
    partial class ExpiringMembershipsForm
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
            dataGridViewExpiringMemberships = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpiringMemberships).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewExpiringMemberships
            // 
            dataGridViewExpiringMemberships.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExpiringMemberships.Location = new Point(176, 46);
            dataGridViewExpiringMemberships.Name = "dataGridViewExpiringMemberships";
            dataGridViewExpiringMemberships.RowHeadersWidth = 51;
            dataGridViewExpiringMemberships.Size = new Size(432, 366);
            dataGridViewExpiringMemberships.TabIndex = 0;
            dataGridViewExpiringMemberships.CellFormatting += dataGridViewExpiringMemberships_CellFormatting;
            // 
            // ExpiringMembershipsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewExpiringMemberships);
            Name = "ExpiringMembershipsForm";
            Text = "ExpiringMembershipsForm";
            Load += ExpiringMembershipsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpiringMemberships).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewExpiringMemberships;
    }
}