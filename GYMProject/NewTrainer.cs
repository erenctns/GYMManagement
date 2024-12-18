using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GYMProject
{
    public partial class NewTrainer : Form
    {
        public NewTrainer()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Get user input
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string gender = genderComboBox.SelectedItem?.ToString();
            int age = (int)ageCounter.Value;
            string phoneNumber = phoneNumberTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string specialization = specializationComboBox.SelectedItem?.ToString();

            // Validation check
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(specialization))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL connection
            string connectionString = GlobalVariables.ConnectionString;

            // New record insertion query
            string insertQuery = @"INSERT INTO Trainer (FirstName, LastName, Gender, Age, PhoneNumber, Email, Specialization)
                                   VALUES (@FirstName, @LastName, @Gender, @Age, @PhoneNumber, @Email, @Specialization)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add SQL parameters
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Age", age);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Specialization", specialization);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Trainer successfully registered.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm(); // Clear the form
                        }
                        else
                        {
                            MessageBox.Show("An issue occurred during registration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearForm()
        {
            // Clear form fields after trainer is added
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            genderComboBox.SelectedIndex = -1;
            ageCounter.Value = ageCounter.Minimum;
            phoneNumberTextBox.Clear();
            emailTextBox.Clear();
            specializationComboBox.SelectedIndex = -1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
