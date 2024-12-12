namespace GYMProject
{
    partial class NewMember
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
            firstNameTextBox = new TextBox();
            firstNameLabel = new Label();
            lastNameTextBox = new TextBox();
            lastNameLabel = new Label();
            genderComboBox = new ComboBox();
            genderLabel = new Label();
            ageCounter = new NumericUpDown();
            ageLabel = new Label();
            phoneNumberTextBox = new TextBox();
            phoneNumberLabel = new Label();
            emailTextBox = new TextBox();
            emailLabel = new Label();
            addressTextBox = new TextBox();
            addressLabel = new Label();
            roleComboBox = new ComboBox();
            roleLabel = new Label();
            membershipTypeComboBox = new ComboBox();
            membershipTypeLabel = new Label();
            saveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ageCounter).BeginInit();
            SuspendLayout();
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(93, 89);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(100, 23);
            firstNameTextBox.TabIndex = 0;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(12, 92);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(64, 15);
            firstNameLabel.TabIndex = 1;
            firstNameLabel.Text = "First Name";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(336, 89);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(100, 23);
            lastNameTextBox.TabIndex = 2;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(252, 92);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(63, 15);
            lastNameLabel.TabIndex = 3;
            lastNameLabel.Text = "Last Name";
            lastNameLabel.Click += lastNameLabel_Click;
            // 
            // genderComboBox
            // 
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Items.AddRange(new object[] { "Male", "Female" });
            genderComboBox.Location = new Point(93, 164);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(121, 23);
            genderComboBox.TabIndex = 4;
            genderComboBox.SelectedIndexChanged += genderComboBox_SelectedIndexChanged;
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(16, 166);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(45, 15);
            genderLabel.TabIndex = 5;
            genderLabel.Text = "Gender";
            // 
            // ageCounter
            // 
            ageCounter.Location = new Point(349, 165);
            ageCounter.Name = "ageCounter";
            ageCounter.Size = new Size(120, 23);
            ageCounter.TabIndex = 6;
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(270, 167);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(28, 15);
            ageLabel.TabIndex = 7;
            ageLabel.Text = "Age";
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(102, 231);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(129, 23);
            phoneNumberTextBox.TabIndex = 8;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(8, 234);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(88, 15);
            phoneNumberLabel.TabIndex = 9;
            phoneNumberLabel.Text = "Phone Number";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(351, 235);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(100, 23);
            emailTextBox.TabIndex = 10;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(287, 240);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 11;
            emailLabel.Text = "Email";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(555, 132);
            addressTextBox.Multiline = true;
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(148, 106);
            addressTextBox.TabIndex = 12;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(563, 97);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(49, 15);
            addressLabel.TabIndex = 13;
            addressLabel.Text = "Address";
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "Admin", "Customer" });
            roleComboBox.Location = new Point(102, 300);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(121, 23);
            roleComboBox.TabIndex = 14;
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Location = new Point(16, 303);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(30, 15);
            roleLabel.TabIndex = 15;
            roleLabel.Text = "Role";
            // 
            // membershipTypeComboBox
            // 
            membershipTypeComboBox.FormattingEnabled = true;
            membershipTypeComboBox.Items.AddRange(new object[] { "Month", "Year" });
            membershipTypeComboBox.Location = new Point(408, 311);
            membershipTypeComboBox.Name = "membershipTypeComboBox";
            membershipTypeComboBox.Size = new Size(121, 23);
            membershipTypeComboBox.TabIndex = 16;
            // 
            // membershipTypeLabel
            // 
            membershipTypeLabel.AutoSize = true;
            membershipTypeLabel.Location = new Point(287, 314);
            membershipTypeLabel.Name = "membershipTypeLabel";
            membershipTypeLabel.Size = new Size(101, 15);
            membershipTypeLabel.TabIndex = 17;
            membershipTypeLabel.Text = "Membership Type";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(290, 400);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 18;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // NewMember
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveButton);
            Controls.Add(membershipTypeLabel);
            Controls.Add(membershipTypeComboBox);
            Controls.Add(roleLabel);
            Controls.Add(roleComboBox);
            Controls.Add(addressLabel);
            Controls.Add(addressTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(phoneNumberLabel);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(ageLabel);
            Controls.Add(ageCounter);
            Controls.Add(genderLabel);
            Controls.Add(genderComboBox);
            Controls.Add(lastNameLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameLabel);
            Controls.Add(firstNameTextBox);
            Name = "NewMember";
            Text = "NewMember";
            ((System.ComponentModel.ISupportInitialize)ageCounter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstNameTextBox;
        private Label firstNameLabel;
        private TextBox lastNameTextBox;
        private Label lastNameLabel;
        private ComboBox genderComboBox;
        private Label genderLabel;
        private NumericUpDown ageCounter;
        private Label ageLabel;
        private TextBox phoneNumberTextBox;
        private Label phoneNumberLabel;
        private TextBox emailTextBox;
        private Label emailLabel;
        private TextBox addressTextBox;
        private Label addressLabel;
        private ComboBox roleComboBox;
        private Label roleLabel;
        private ComboBox membershipTypeComboBox;
        private Label membershipTypeLabel;
        private Button saveButton;
    }
}