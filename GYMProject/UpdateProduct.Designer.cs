namespace GYMProject
{
    partial class UpdateProduct
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
            productNameComboBox = new ComboBox();
            productPriceCounter = new NumericUpDown();
            productStockCounter = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            saveChangesButton = new Button();
            ((System.ComponentModel.ISupportInitialize)productPriceCounter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productStockCounter).BeginInit();
            SuspendLayout();
            // 
            // productNameComboBox
            // 
            productNameComboBox.FormattingEnabled = true;
            productNameComboBox.Location = new Point(144, 56);
            productNameComboBox.Name = "productNameComboBox";
            productNameComboBox.Size = new Size(140, 28);
            productNameComboBox.TabIndex = 0;
            productNameComboBox.SelectedIndexChanged += productNameComboBox_SelectedIndexChanged_1;
            // 
            // productPriceCounter
            // 
            productPriceCounter.Location = new Point(412, 54);
            productPriceCounter.Name = "productPriceCounter";
            productPriceCounter.Size = new Size(105, 27);
            productPriceCounter.TabIndex = 1;
            // 
            // productStockCounter
            // 
            productStockCounter.Location = new Point(635, 53);
            productStockCounter.Name = "productStockCounter";
            productStockCounter.Size = new Size(97, 27);
            productStockCounter.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 64);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(328, 60);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 4;
            label2.Text = "Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(564, 56);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 5;
            label3.Text = "Stock";
            // 
            // saveChangesButton
            // 
            saveChangesButton.Location = new Point(338, 275);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(145, 29);
            saveChangesButton.TabIndex = 6;
            saveChangesButton.Text = "Save Changes";
            saveChangesButton.UseVisualStyleBackColor = true;
            saveChangesButton.Click += saveChangesButton_Click_1;
            // 
            // UpdateProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveChangesButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(productStockCounter);
            Controls.Add(productPriceCounter);
            Controls.Add(productNameComboBox);
            Name = "UpdateProduct";
            Text = "UpdateProduct";
            ((System.ComponentModel.ISupportInitialize)productPriceCounter).EndInit();
            ((System.ComponentModel.ISupportInitialize)productStockCounter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox productNameComboBox;
        private NumericUpDown productPriceCounter;
        private NumericUpDown productStockCounter;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button saveChangesButton;
    }
}