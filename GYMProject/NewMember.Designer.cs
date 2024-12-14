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
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)ageCounter).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(258, 15);
            firstNameTextBox.Margin = new Padding(3, 4, 3, 4);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(290, 27);
            firstNameTextBox.TabIndex = 0;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(99, 18);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(80, 20);
            firstNameLabel.TabIndex = 1;
            firstNameLabel.Text = "First Name";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(258, 71);
            lastNameTextBox.Margin = new Padding(3, 4, 3, 4);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(290, 27);
            lastNameTextBox.TabIndex = 2;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(99, 74);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(79, 20);
            lastNameLabel.TabIndex = 3;
            lastNameLabel.Text = "Last Name";
            lastNameLabel.Click += lastNameLabel_Click;
            // 
            // genderComboBox
            // 
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Items.AddRange(new object[] { "Male", "Female" });
            genderComboBox.Location = new Point(258, 117);
            genderComboBox.Margin = new Padding(3, 4, 3, 4);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(97, 28);
            genderComboBox.TabIndex = 4;
            genderComboBox.SelectedIndexChanged += genderComboBox_SelectedIndexChanged;
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(99, 120);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(57, 20);
            genderLabel.TabIndex = 5;
            genderLabel.Text = "Gender";
            // 
            // ageCounter
            // 
            ageCounter.Location = new Point(258, 165);
            ageCounter.Margin = new Padding(3, 4, 3, 4);
            ageCounter.Name = "ageCounter";
            ageCounter.Size = new Size(54, 27);
            ageCounter.TabIndex = 6;
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(99, 165);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(36, 20);
            ageLabel.TabIndex = 7;
            ageLabel.Text = "Age";
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(258, 213);
            phoneNumberTextBox.Margin = new Padding(3, 4, 3, 4);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(290, 27);
            phoneNumberTextBox.TabIndex = 8;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(99, 213);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(108, 20);
            phoneNumberLabel.TabIndex = 9;
            phoneNumberLabel.Text = "Phone Number";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(258, 261);
            emailTextBox.Margin = new Padding(3, 4, 3, 4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(290, 27);
            emailTextBox.TabIndex = 10;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(99, 261);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 11;
            emailLabel.Text = "Email";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(258, 400);
            addressTextBox.Margin = new Padding(3, 4, 3, 4);
            addressTextBox.Multiline = true;
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(290, 44);
            addressTextBox.TabIndex = 12;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(99, 400);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(62, 20);
            addressLabel.TabIndex = 13;
            addressLabel.Text = "Address";
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "Admin", "Customer" });
            roleComboBox.Location = new Point(258, 307);
            roleComboBox.Margin = new Padding(3, 4, 3, 4);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(97, 28);
            roleComboBox.TabIndex = 14;
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Location = new Point(99, 307);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(39, 20);
            roleLabel.TabIndex = 15;
            roleLabel.Text = "Role";
            // 
            // membershipTypeComboBox
            // 
            membershipTypeComboBox.FormattingEnabled = true;
            membershipTypeComboBox.Items.AddRange(new object[] { "Month", "Year" });
            membershipTypeComboBox.Location = new Point(258, 352);
            membershipTypeComboBox.Margin = new Padding(3, 4, 3, 4);
            membershipTypeComboBox.Name = "membershipTypeComboBox";
            membershipTypeComboBox.Size = new Size(97, 28);
            membershipTypeComboBox.TabIndex = 16;
            // 
            // membershipTypeLabel
            // 
            membershipTypeLabel.AutoSize = true;
            membershipTypeLabel.Location = new Point(99, 352);
            membershipTypeLabel.Name = "membershipTypeLabel";
            membershipTypeLabel.Size = new Size(127, 20);
            membershipTypeLabel.TabIndex = 17;
            membershipTypeLabel.Text = "Membership Type";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(258, 481);
            saveButton.Margin = new Padding(3, 4, 3, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(86, 31);
            saveButton.TabIndex = 18;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Menu;
            panel1.Controls.Add(firstNameTextBox);
            panel1.Controls.Add(saveButton);
            panel1.Controls.Add(firstNameLabel);
            panel1.Controls.Add(membershipTypeLabel);
            panel1.Controls.Add(lastNameTextBox);
            panel1.Controls.Add(membershipTypeComboBox);
            panel1.Controls.Add(lastNameLabel);
            panel1.Controls.Add(roleLabel);
            panel1.Controls.Add(genderComboBox);
            panel1.Controls.Add(roleComboBox);
            panel1.Controls.Add(genderLabel);
            panel1.Controls.Add(addressLabel);
            panel1.Controls.Add(ageCounter);
            panel1.Controls.Add(addressTextBox);
            panel1.Controls.Add(ageLabel);
            panel1.Controls.Add(emailLabel);
            panel1.Controls.Add(phoneNumberTextBox);
            panel1.Controls.Add(emailTextBox);
            panel1.Controls.Add(phoneNumberLabel);
            panel1.Location = new Point(164, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(625, 560);
            panel1.TabIndex = 19;
            // 
            // NewMember
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 600);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "NewMember";
            Text = "NewMember";
            Load += NewMember_Load;
            ((System.ComponentModel.ISupportInitialize)ageCounter).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
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
        private Panel panel1;
    }
}