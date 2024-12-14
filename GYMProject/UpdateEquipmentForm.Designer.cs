namespace GYMProject
{
    partial class UpdateEquipmentForm
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
            EquipmentNameComboBox = new ComboBox();
            ConditionNameComboBox = new ComboBox();
            quantityCounter = new NumericUpDown();
            saveButton = new Button();
            panel1 = new Panel();
            selectEquipmentLabel = new Label();
            selectQuantityLabel = new Label();
            selectConditionLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)quantityCounter).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // EquipmentNameComboBox
            // 
            EquipmentNameComboBox.FormattingEnabled = true;
            EquipmentNameComboBox.Location = new Point(23, 113);
            EquipmentNameComboBox.Name = "EquipmentNameComboBox";
            EquipmentNameComboBox.Size = new Size(151, 28);
            EquipmentNameComboBox.TabIndex = 0;
            EquipmentNameComboBox.SelectedIndexChanged += EquipmentNameComboBox_SelectedIndexChanged_1;
            // 
            // ConditionNameComboBox
            // 
            ConditionNameComboBox.FormattingEnabled = true;
            ConditionNameComboBox.Location = new Point(422, 112);
            ConditionNameComboBox.Name = "ConditionNameComboBox";
            ConditionNameComboBox.Size = new Size(151, 28);
            ConditionNameComboBox.TabIndex = 1;
            // 
            // quantityCounter
            // 
            quantityCounter.Location = new Point(234, 113);
            quantityCounter.Name = "quantityCounter";
            quantityCounter.Size = new Size(138, 27);
            quantityCounter.TabIndex = 2;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(262, 253);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 3;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(selectConditionLabel);
            panel1.Controls.Add(selectQuantityLabel);
            panel1.Controls.Add(selectEquipmentLabel);
            panel1.Controls.Add(quantityCounter);
            panel1.Controls.Add(saveButton);
            panel1.Controls.Add(EquipmentNameComboBox);
            panel1.Controls.Add(ConditionNameComboBox);
            panel1.Location = new Point(93, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(603, 334);
            panel1.TabIndex = 4;
            // 
            // selectEquipmentLabel
            // 
            selectEquipmentLabel.AutoSize = true;
            selectEquipmentLabel.Location = new Point(38, 77);
            selectEquipmentLabel.Name = "selectEquipmentLabel";
            selectEquipmentLabel.Size = new Size(125, 20);
            selectEquipmentLabel.TabIndex = 4;
            selectEquipmentLabel.Text = "Select Equipment";
            // 
            // selectQuantityLabel
            // 
            selectQuantityLabel.AutoSize = true;
            selectQuantityLabel.Location = new Point(247, 77);
            selectQuantityLabel.Name = "selectQuantityLabel";
            selectQuantityLabel.Size = new Size(109, 20);
            selectQuantityLabel.TabIndex = 5;
            selectQuantityLabel.Text = "Select Quantity";
            // 
            // selectConditionLabel
            // 
            selectConditionLabel.AutoSize = true;
            selectConditionLabel.Location = new Point(440, 77);
            selectConditionLabel.Name = "selectConditionLabel";
            selectConditionLabel.Size = new Size(118, 20);
            selectConditionLabel.TabIndex = 6;
            selectConditionLabel.Text = "Select Condition";
            // 
            // UpdateEquipmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "UpdateEquipmentForm";
            Text = "Update Equipment Form";
            ((System.ComponentModel.ISupportInitialize)quantityCounter).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox EquipmentNameComboBox;
        private ComboBox ConditionNameComboBox;
        private NumericUpDown quantityCounter;
        private Button saveButton;
        private Panel panel1;
        private Label selectEquipmentLabel;
        private Label selectQuantityLabel;
        private Label selectConditionLabel;
    }
}