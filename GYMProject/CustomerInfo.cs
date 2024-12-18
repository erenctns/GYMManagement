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
    public partial class CustomerInfo : Form
    {
        private int currentMemberId; // MemberID of the logged-in user

        public CustomerInfo(int memberId)
        {
            InitializeComponent();
            currentMemberId = memberId; // Retrieve the MemberID of the logged-in user
            InitializeDataGridView(); // Initialize the DataGridView
            LoadUserInfo(memberId); // Load user information
        }

        private void InitializeDataGridView()
        {
            // Add columns to the DataGridView programmatically
            dataGridViewUserInfo.Columns.Clear(); // Clear any predefined columns

            // Add new columns
            dataGridViewUserInfo.Columns.Add("FirstName", "First Name");
            dataGridViewUserInfo.Columns.Add("LastName", "Last Name");
            dataGridViewUserInfo.Columns.Add("StartDate", "Start Date");
            dataGridViewUserInfo.Columns.Add("EndDate", "End Date");
            dataGridViewUserInfo.Columns.Add("Price", "Price");
            dataGridViewUserInfo.Columns.Add("Username", "Username");
            dataGridViewUserInfo.Columns.Add("Password", "Password");

            // Data can be added later
        }

        private void LoadUserInfo(int memberId)
        {
            // Database connection string
            string connectionString = GlobalVariables.ConnectionString;

            // SQL query
            string query = @"
                SELECT 
                    mem.FirstName, mem.LastName, m.StartDate, m.EndDate, m.Price, 
                    u.Username, u.Password
                FROM 
                    UserAuth u
                INNER JOIN 
                    Membership m ON u.MemberID = m.MemberID
                INNER JOIN 
                    Member mem ON m.MemberID = mem.MemberID
                WHERE 
                    u.MemberID = @MemberID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // Create the SQL command
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", memberId);

                    // Execute the query
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Add data to the DataGridView
                        dataGridViewUserInfo.Rows.Clear(); // Clear any existing rows
                        dataGridViewUserInfo.Rows.Add(
                            reader["FirstName"],
                            reader["LastName"],
                            Convert.ToDateTime(reader["StartDate"]).ToString("yyyy-MM-dd"),
                            Convert.ToDateTime(reader["EndDate"]).ToString("yyyy-MM-dd"),
                            reader["Price"],
                            reader["Username"],
                            reader["Password"]
                        );
                    }
                    else
                    {
                        MessageBox.Show("User information could not be found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
