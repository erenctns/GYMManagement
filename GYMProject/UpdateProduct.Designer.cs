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
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)productPriceCounter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productStockCounter).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // productNameComboBox
            // 
            productNameComboBox.FormattingEnabled = true;
            productNameComboBox.Location = new Point(41, 72);
            productNameComboBox.Name = "productNameComboBox";
            productNameComboBox.Size = new Size(140, 28);
            productNameComboBox.TabIndex = 0;
            productNameComboBox.SelectedIndexChanged += productNameComboBox_SelectedIndexChanged_1;
            // 
            // productPriceCounter
            // 
            productPriceCounter.Location = new Point(274, 73);
            productPriceCounter.Name = "productPriceCounter";
            productPriceCounter.Size = new Size(105, 27);
            productPriceCounter.TabIndex = 1;
            // 
            // productStockCounter
            // 
            productStockCounter.Location = new Point(454, 73);
            productStockCounter.Name = "productStockCounter";
            productStockCounter.Size = new Size(97, 27);
            productStockCounter.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 40);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(274, 40);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 4;
            label2.Text = "Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(454, 40);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 5;
            label3.Text = "Stock";
            // 
            // saveChangesButton
            // 
            saveChangesButton.Location = new Point(244, 208);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(145, 29);
            saveChangesButton.TabIndex = 6;
            saveChangesButton.Text = "Save Changes";
            saveChangesButton.UseVisualStyleBackColor = true;
            saveChangesButton.Click += saveChangesButton_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(saveChangesButton);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(productNameComboBox);
            panel1.Controls.Add(productPriceCounter);
            panel1.Controls.Add(productStockCounter);
            panel1.Location = new Point(88, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(626, 264);
            panel1.TabIndex = 7;
            // 
            // UpdateProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "UpdateProduct";
            Text = "UpdateProduct";
            ((System.ComponentModel.ISupportInitialize)productPriceCounter).EndInit();
            ((System.ComponentModel.ISupportInitialize)productStockCounter).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox productNameComboBox;
        private NumericUpDown productPriceCounter;
        private NumericUpDown productStockCounter;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button saveChangesButton;
        private Panel panel1;
    }
}