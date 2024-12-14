namespace GYMProject
{
    partial class NewTrainer
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
            firstNameLabel = new Label();
            firstNameTextBox = new TextBox();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            genderComboBox = new ComboBox();
            genderLabel = new Label();
            ageCounter = new NumericUpDown();
            ageLabel = new Label();
            phoneNumberLabel = new Label();
            emailLabel = new Label();
            phoneNumberTextBox = new TextBox();
            emailTextBox = new TextBox();
            specializationComboBox = new ComboBox();
            specializationLabel = new Label();
            saveButton = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)ageCounter).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(82, 38);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(80, 20);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(208, 35);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(231, 27);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(82, 86);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(79, 20);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Nmae";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(207, 83);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(231, 27);
            lastNameTextBox.TabIndex = 3;
            // 
            // genderComboBox
            // 
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Items.AddRange(new object[] { "Male", "Female" });
            genderComboBox.Location = new Point(207, 134);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(125, 28);
            genderComboBox.TabIndex = 4;
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(82, 137);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(57, 20);
            genderLabel.TabIndex = 5;
            genderLabel.Text = "Gender";
            // 
            // ageCounter
            // 
            ageCounter.Location = new Point(208, 179);
            ageCounter.Name = "ageCounter";
            ageCounter.Size = new Size(71, 27);
            ageCounter.TabIndex = 6;
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(82, 181);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(36, 20);
            ageLabel.TabIndex = 7;
            ageLabel.Text = "Age";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(82, 227);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(108, 20);
            phoneNumberLabel.TabIndex = 8;
            phoneNumberLabel.Text = "Phone Number";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(82, 280);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(50, 20);
            emailLabel.TabIndex = 9;
            emailLabel.Text = "E mail";
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(208, 224);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(231, 27);
            phoneNumberTextBox.TabIndex = 10;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(208, 277);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(231, 27);
            emailTextBox.TabIndex = 11;
            // 
            // specializationComboBox
            // 
            specializationComboBox.FormattingEnabled = true;
            specializationComboBox.Items.AddRange(new object[] { "Fitness", "Yoga", "Kick Box" });
            specializationComboBox.Location = new Point(208, 323);
            specializationComboBox.Name = "specializationComboBox";
            specializationComboBox.Size = new Size(125, 28);
            specializationComboBox.TabIndex = 12;
            // 
            // specializationLabel
            // 
            specializationLabel.AutoSize = true;
            specializationLabel.Location = new Point(83, 326);
            specializationLabel.Name = "specializationLabel";
            specializationLabel.Size = new Size(102, 20);
            specializationLabel.TabIndex = 13;
            specializationLabel.Text = "Specialization";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(218, 426);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 14;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(firstNameLabel);
            panel1.Controls.Add(saveButton);
            panel1.Controls.Add(firstNameTextBox);
            panel1.Controls.Add(specializationLabel);
            panel1.Controls.Add(lastNameLabel);
            panel1.Controls.Add(specializationComboBox);
            panel1.Controls.Add(lastNameTextBox);
            panel1.Controls.Add(emailTextBox);
            panel1.Controls.Add(genderComboBox);
            panel1.Controls.Add(phoneNumberTextBox);
            panel1.Controls.Add(genderLabel);
            panel1.Controls.Add(emailLabel);
            panel1.Controls.Add(ageCounter);
            panel1.Controls.Add(phoneNumberLabel);
            panel1.Controls.Add(ageLabel);
            panel1.Location = new Point(195, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 478);
            panel1.TabIndex = 15;
            panel1.Paint += panel1_Paint;
            // 
            // NewTrainer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(958, 556);
            Controls.Add(panel1);
            Name = "NewTrainer";
            Text = "NewTrainer";
            ((System.ComponentModel.ISupportInitialize)ageCounter).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label firstNameLabel;
        private TextBox firstNameTextBox;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private ComboBox genderComboBox;
        private Label genderLabel;
        private NumericUpDown ageCounter;
        private Label ageLabel;
        private Label phoneNumberLabel;
        private Label emailLabel;
        private TextBox phoneNumberTextBox;
        private TextBox emailTextBox;
        private ComboBox specializationComboBox;
        private Label specializationLabel;
        private Button saveButton;
        private Panel panel1;
    }
}