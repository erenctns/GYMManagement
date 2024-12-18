using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GYMProject
{
    public partial class RegisterClass : Form
    {
        private int memberId; // The ID of the related member
        private CheckedListBox checkedListBoxClasses; // CheckedListBox for multiple selections
        private Button btnRegister; // Button to register for a class

        public RegisterClass(int memberId)
        {
            this.memberId = memberId;
            InitializeComponent();
            InitializeFormControls();
            LoadClasses();
        }

        private void InitializeFormControls()
        {
            // Form settings
            this.Size = new Size(400, 450);
            this.Text = "Register Class";

            // CheckedListBox control
            checkedListBoxClasses = new CheckedListBox
            {
                Name = "checkedListBoxClasses",
                Size = new Size(300, 250),
                Location = new Point(50, 20),
                CheckOnClick = true // Select on single click
            };
            this.Controls.Add(checkedListBoxClasses);

            // Button control
            btnRegister = new Button
            {
                Name = "btnRegister",
                Text = "Register for Class",
                Size = new Size(150, 40),
                Location = new Point(125, 300)
            };
            btnRegister.Click += BtnRegister_Click;
            this.Controls.Add(btnRegister);
        }

        private void LoadClasses()
        {
            try
            {
                string connectionString = GlobalVariables.ConnectionString;

                string query = "SELECT ClassID, Name FROM Class"; // Get class details

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        checkedListBoxClasses.Items.Clear(); // Clear the list

                        while (reader.Read())
                        {
                            // Add ClassID and class name to the CheckedListBox
                            checkedListBoxClasses.Items.Add($"{reader["ClassID"]}: {reader["Name"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (checkedListBoxClasses.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one class.");
                return;
            }

            bool isAnyRegistrationSuccessful = false; // Check if any registration was successful

            foreach (var item in checkedListBoxClasses.CheckedItems)
            {
                try
                {
                    // Get the ClassID from the selected class
                    string selectedClass = item.ToString();
                    int classId = Convert.ToInt32(selectedClass.Split(':')[0]);

                    // Warn if the member is already registered for the class
                    if (IsMemberAlreadyRegistered(memberId, classId))
                    {
                        MessageBox.Show($"The member is already registered for the {selectedClass.Split(':')[1]} class.");
                        continue; // Skip the registration process for the same class
                    }

                    // Perform the registration process
                    RegisterMemberToClass(memberId, classId);
                    isAnyRegistrationSuccessful = true; // At least one registration was successful
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            // If any class was registered successfully, show a success message
            if (isAnyRegistrationSuccessful)
            {
                MessageBox.Show("The registration process for the selected classes was completed successfully.");
                this.Close();
            }
        }

        private bool IsMemberAlreadyRegistered(int memberId, int classId)
        {
            try
            {
                string connectionString = GlobalVariables.ConnectionString;

                string query = @"
                    SELECT COUNT(*) 
                    FROM Attendance 
                    WHERE MemberID = @MemberID AND ClassID = @ClassID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberID", memberId);
                        command.Parameters.AddWithValue("@ClassID", classId);

                        int count = (int)command.ExecuteScalar();
                        return count > 0; // If there's an existing registration, return true
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during check: {ex.Message}");
                return true; // Return true to prevent registration if there's an error
            }
        }

        private void RegisterMemberToClass(int memberId, int classId)
        {
            try
            {
                string connectionString = GlobalVariables.ConnectionString;

                string query = @"
                    INSERT INTO Attendance (MemberID, ClassID, Date)
                    VALUES (@MemberID, @ClassID, @Date)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberID", memberId);
                        command.Parameters.AddWithValue("@ClassID", classId);
                        command.Parameters.AddWithValue("@Date", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during class registration: {ex.Message}");
            }
        }
    }
}
