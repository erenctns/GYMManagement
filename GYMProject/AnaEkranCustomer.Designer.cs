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
            SuspendLayout();
            // 
            // customerInfo
            // 
            customerInfo.BackgroundImage = Properties.Resources.project;
            customerInfo.BackgroundImageLayout = ImageLayout.None;
            customerInfo.Location = new Point(61, 25);
            customerInfo.Name = "customerInfo";
            customerInfo.Size = new Size(167, 74);
            customerInfo.TabIndex = 0;
            customerInfo.Text = "Information";
            customerInfo.TextAlign = ContentAlignment.MiddleRight;
            customerInfo.UseVisualStyleBackColor = true;
            customerInfo.Click += customerInfo_Click;
            // 
            // AnaEkranCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(customerInfo);
            Name = "AnaEkranCustomer";
            Text = "AnaEkranCustomer";
            Load += AnaEkranCustomer_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button customerInfo;
    }
}