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
            ((System.ComponentModel.ISupportInitialize)quantityCounter).BeginInit();
            SuspendLayout();
            // 
            // EquipmentNameComboBox
            // 
            EquipmentNameComboBox.FormattingEnabled = true;
            EquipmentNameComboBox.Location = new Point(66, 82);
            EquipmentNameComboBox.Name = "EquipmentNameComboBox";
            EquipmentNameComboBox.Size = new Size(151, 28);
            EquipmentNameComboBox.TabIndex = 0;
            EquipmentNameComboBox.SelectedIndexChanged += EquipmentNameComboBox_SelectedIndexChanged_1;
            // 
            // ConditionNameComboBox
            // 
            ConditionNameComboBox.FormattingEnabled = true;
            ConditionNameComboBox.Location = new Point(545, 82);
            ConditionNameComboBox.Name = "ConditionNameComboBox";
            ConditionNameComboBox.Size = new Size(151, 28);
            ConditionNameComboBox.TabIndex = 1;
            // 
            // quantityCounter
            // 
            quantityCounter.Location = new Point(288, 83);
            quantityCounter.Name = "quantityCounter";
            quantityCounter.Size = new Size(150, 27);
            quantityCounter.TabIndex = 2;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(310, 200);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 3;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click_1;
            // 
            // UpdateEquipmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveButton);
            Controls.Add(quantityCounter);
            Controls.Add(ConditionNameComboBox);
            Controls.Add(EquipmentNameComboBox);
            Name = "UpdateEquipmentForm";
            Text = "Update Equipment Form";
            ((System.ComponentModel.ISupportInitialize)quantityCounter).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox EquipmentNameComboBox;
        private ComboBox ConditionNameComboBox;
        private NumericUpDown quantityCounter;
        private Button saveButton;
    }
}