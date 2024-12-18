using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace GYMProject
{
    public partial class NewMember : Form
    {
        public NewMember()
        {
            InitializeComponent();
        }

        private void lastNameLabel_Click(object sender, EventArgs e)
        {


        }

        private void genderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for empty fields
                if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                    genderComboBox.SelectedItem == null ||
                    ageCounter.Value <= 0 ||
                    string.IsNullOrWhiteSpace(phoneNumberTextBox.Text) ||
                    string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                    roleComboBox.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(addressTextBox.Text) ||
                    membershipTypeComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please fill out all the fields!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Email validation
                if (!System.Text.RegularExpressions.Regex.IsMatch(emailTextBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address!", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Phone number validation
                if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumberTextBox.Text, @"^\d{11}$"))
                {
                    MessageBox.Show("Phone number must be exactly 11 digits!", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal membershipPrice = 0;
                DateTime startDate = DateTime.Now;
                DateTime endDate = startDate;

                // Determine membership price and end date based on membership type
                switch (membershipTypeComboBox.SelectedItem.ToString())
                {
                    case "Month":
                        membershipPrice = 1000; // Price for one month
                        endDate = startDate.AddMonths(1); // Add one month
                        break;

                    case "Year":
                        membershipPrice = 9000; // Price for one year
                        endDate = startDate.AddYears(1); // Add one year
                        break;

                    default:
                        MessageBox.Show("Please select a valid membership type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Database connection
                string connectionString = GlobalVariables.ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert data into Member table
                    string insertMemberQuery = @"
            INSERT INTO Member (FirstName, LastName, Gender, Age, PhoneNumber, Email, Address, Role)
            OUTPUT INSERTED.MemberID
            VALUES (@FirstName, @LastName, @Gender, @Age, @PhoneNumber, @Email, @Address, @Role)";

                    using (SqlCommand command = new SqlCommand(insertMemberQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstNameTextBox.Text);
                        command.Parameters.AddWithValue("@LastName", lastNameTextBox.Text);
                        command.Parameters.AddWithValue("@Gender", genderComboBox.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@Age", ageCounter.Value);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumberTextBox.Text);
                        command.Parameters.AddWithValue("@Email", emailTextBox.Text);
                        command.Parameters.AddWithValue("@Address", addressTextBox.Text);
                        command.Parameters.AddWithValue("@Role", roleComboBox.SelectedItem.ToString());

                        int memberId = (int)command.ExecuteScalar(); // Get MemberID

                        // Insert data into Membership table
                        string insertMembershipQuery = @"
            INSERT INTO Membership (MemberID, MembershipType, Price, StartDate, EndDate)
            VALUES (@MemberID, @MembershipType, @Price, @StartDate, @EndDate)";

                        using (SqlCommand membershipCommand = new SqlCommand(insertMembershipQuery, connection))
                        {
                            membershipCommand.Parameters.AddWithValue("@MemberID", memberId);
                            membershipCommand.Parameters.AddWithValue("@MembershipType", membershipTypeComboBox.SelectedItem.ToString());
                            membershipCommand.Parameters.AddWithValue("@Price", membershipPrice);
                            membershipCommand.Parameters.AddWithValue("@StartDate", startDate);
                            membershipCommand.Parameters.AddWithValue("@EndDate", endDate);

                            membershipCommand.ExecuteNonQuery(); // Add Membership data
                        }

                        // Insert data into userAuth table (username and password)
                        string username = $"{firstNameTextBox.Text.ToLower()}{memberId}";
                        string password = username; // Password is set to username for simplicity

                        string insertAuthQuery = @"
            INSERT INTO userAuth (Username, Password, MemberID)
            VALUES (@Username, @Password, @MemberID)";

                        using (SqlCommand authCommand = new SqlCommand(insertAuthQuery, connection))
                        {
                            authCommand.Parameters.AddWithValue("@Username", username);
                            authCommand.Parameters.AddWithValue("@Password", password);
                            authCommand.Parameters.AddWithValue("@MemberID", memberId);

                            authCommand.ExecuteNonQuery(); // Add userAuth data
                        }

                        // Create Payment form and pass the required data
                        string fullName = $"{firstNameTextBox.Text} {lastNameTextBox.Text}";
                        string email = emailTextBox.Text;
                        string membershipType = membershipTypeComboBox.SelectedItem.ToString();

                        Payment paymentForm = new Payment(memberId, membershipPrice, fullName, email, membershipType);
                        paymentForm.MembershipAmount = membershipPrice; // Pass price
                        paymentForm.Show();
                        this.Hide(); // Hide NewMember form
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

      

        private void NewMember_Load(object sender, EventArgs e)
        {
        
        }
    }
}
