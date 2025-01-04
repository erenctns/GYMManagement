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
    public partial class AnaEkranCustomer : Form
    {
        private int memberId; // To store the MemberID of the user
        private int currentMemberId;
        public AnaEkranCustomer(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId; // Store the MemberID coming from the constructor
            currentMemberId = memberId;
        }

        private void AnaEkranCustomer_Load(object sender, EventArgs e)
        {
            CheckMembershipExpiration();
            GetMemberName();
            welcomeLabel.BackColor = Color.Transparent;
        }

        private void CheckMembershipExpiration()
        {
            string connectionString = GlobalVariables.ConnectionString;
            string query = "SELECT EndDate FROM Membership WHERE MemberID = @MemberID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", currentMemberId); // ID of the logged-in member
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DateTime EndDate = reader.GetDateTime(0);
                        TimeSpan remainingDays = EndDate - DateTime.Now;

                        // If the membership expiration date is 27 days or closer, show a pop-up
                        if (remainingDays.Days <= 27)
                        {
                            MessageBox.Show($"Your membership will expire in {remainingDays.Days} days! Please renew it.");
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void GetMemberName()
        {
            string connectionString = GlobalVariables.ConnectionString;
            string query = "SELECT FirstName, LastName FROM Member WHERE MemberID = @MemberID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", currentMemberId); // ID of the logged-in member
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string firstName = reader.GetString(0);
                        string lastName = reader.GetString(1);

                        // Write "Welcome customer_name" on the label
                        welcomeLabel.Text = $"Welcome {firstName} {lastName}";
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void customerInfo_Click(object sender, EventArgs e)
        {
            CustomerInfo userInfoForm = new CustomerInfo(currentMemberId);
            userInfoForm.Show();
        }

        private void exitbuttonCustomer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogOutButtonCustomer_Click(object sender, EventArgs e)
        {
            Giris girisForm = new Giris();
            this.Hide();
            girisForm.Show();
        }

        private void myClassesButton_Click(object sender, EventArgs e)
        {
            MyClassesForm myClassesForm = new MyClassesForm(currentMemberId);
            myClassesForm.Show();
        }

        private void myItemsButton_Click(object sender, EventArgs e)
        {
            MyItemsForm myItemsForm = new MyItemsForm(currentMemberId);
            myItemsForm.Show();
        }
    }
}
