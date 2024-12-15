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
            productNameLabel = new Label();
            productPriceLabel = new Label();
            productStockLabel = new Label();
            saveChangesButton = new Button();
            ((System.ComponentModel.ISupportInitialize)productPriceCounter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productStockCounter).BeginInit();
            SuspendLayout();
            // 
            // productNameComboBox
            // 
            productNameComboBox.FormattingEnabled = true;
            productNameComboBox.Location = new Point(91, 68);
            productNameComboBox.Name = "productNameComboBox";
            productNameComboBox.Size = new Size(151, 28);
            productNameComboBox.TabIndex = 0;
            // 
            // productPriceCounter
            // 
            productPriceCounter.Location = new Point(371, 67);
            productPriceCounter.Name = "productPriceCounter";
            productPriceCounter.Size = new Size(94, 27);
            productPriceCounter.TabIndex = 1;
            // 
            // productStockCounter
            // 
            productStockCounter.Location = new Point(612, 67);
            productStockCounter.Name = "productStockCounter";
            productStockCounter.Size = new Size(95, 27);
            productStockCounter.TabIndex = 2;
            // 
            // productNameLabel
            // 
            productNameLabel.AutoSize = true;
            productNameLabel.Location = new Point(21, 74);
            productNameLabel.Name = "productNameLabel";
            productNameLabel.Size = new Size(60, 20);
            productNameLabel.TabIndex = 3;
            productNameLabel.Text = "Product";
            // 
            // productPriceLabel
            // 
            productPriceLabel.AutoSize = true;
            productPriceLabel.Location = new Point(292, 69);
            productPriceLabel.Name = "productPriceLabel";
            productPriceLabel.Size = new Size(41, 20);
            productPriceLabel.TabIndex = 4;
            productPriceLabel.Text = "Price";
            // 
            // productStockLabel
            // 
            productStockLabel.AutoSize = true;
            productStockLabel.Location = new Point(528, 71);
            productStockLabel.Name = "productStockLabel";
            productStockLabel.Size = new Size(45, 20);
            productStockLabel.TabIndex = 5;
            productStockLabel.Text = "Stock";
            // 
            // saveChangesButton
            // 
            saveChangesButton.Location = new Point(302, 314);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(163, 29);
            saveChangesButton.TabIndex = 6;
            saveChangesButton.Text = "Save Changes";
            saveChangesButton.UseVisualStyleBackColor = true;
            saveChangesButton.Click += saveChangesButton_Click;
            // 
            // UpdateProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveChangesButton);
            Controls.Add(productStockLabel);
            Controls.Add(productPriceLabel);
            Controls.Add(productNameLabel);
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
        private Label productNameLabel;
        private Label productPriceLabel;
        private Label productStockLabel;
        private Button saveChangesButton;
    }
}