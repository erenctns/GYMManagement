namespace GYMProject
{
    partial class Payment
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
            tickButton = new Button();
            label1 = new Label();
            amountLabel1 = new Label();
            SuspendLayout();
            // 
            // tickButton
            // 
            tickButton.Location = new Point(371, 372);
            tickButton.Name = "tickButton";
            tickButton.Size = new Size(75, 23);
            tickButton.TabIndex = 2;
            tickButton.Text = "Confirm";
            tickButton.UseVisualStyleBackColor = true;
            tickButton.Click += tickButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(350, 162);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 3;
            // 
            // amountLabel1
            // 
            amountLabel1.AutoSize = true;
            amountLabel1.Location = new Point(335, 190);
            amountLabel1.Name = "amountLabel1";
            amountLabel1.Size = new Size(38, 15);
            amountLabel1.TabIndex = 4;
            amountLabel1.Text = "label2";
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(amountLabel1);
            Controls.Add(label1);
            Controls.Add(tickButton);
            Name = "Payment";
            Text = "Payment";
            Load += Payment_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label amountLabel;
        private Button tickButton;
        private Label label1;
        private Label amountLabel1;
    }
}