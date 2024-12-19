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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GYMProject
{
    public partial class Payment : Form
    {
        public int MemberID { get; set; } // Property to hold MemberID
        public decimal? MembershipAmount { get; set; } // Property to hold MembershipAmount as decimal
        public string FullName { get; set; } // Property for Full Name
        public string Email { get; set; } // Property for Email
        public string MembershipType { get; set; } // Property for Membership Type
        public DateTime PaymentDate { get; set; } // Property to hold today's date

        // Constructor that takes MemberID
        public Payment(int memberId, decimal? membershipAmount, string fullName, string email, string membershipType)
        {
            InitializeComponent();
            this.MemberID = memberId;
            this.MembershipAmount = membershipAmount;
            this.FullName = fullName;
            this.Email = email;
            this.MembershipType = membershipType;
            this.PaymentDate = DateTime.Now;
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void Payment_Load_1(object sender, EventArgs e)
        {
            fullNameLabel.Text = "Full Name:";
            fullnameLabelValue.Text = FullName;

            emailLabel.Text = "Email:";
            emailValueLabel.Text = Email;

            membershipTypeLabel.Text = "Membership Type:";
            membershipTypeLabelValue.Text = MembershipType;

            paymentDateLabel.Text = "Date:";
            string todayDate = DateTime.Now.ToString("dd/MM/yyyy");
            paymentDateLabelValue.Text = todayDate;

            // Align all labels' text to the left
            fullNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            fullnameLabelValue.TextAlign = ContentAlignment.MiddleLeft;
            emailLabel.TextAlign = ContentAlignment.MiddleLeft;
            emailValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            membershipTypeLabel.TextAlign = ContentAlignment.MiddleLeft;
            membershipTypeLabelValue.TextAlign = ContentAlignment.MiddleLeft;
            amountLabel1.TextAlign = ContentAlignment.MiddleLeft;
            paymentDateLabelValue.TextAlign = ContentAlignment.MiddleLeft;

            // If MembershipAmount has a value, display it in the label
            if (MembershipAmount.HasValue)
            {
                amountLabel1.Text = "Total Amount:";
                amountLabelVaule1.Text = MembershipAmount.Value + "TL";
            }
            else
            {
                amountLabel1.Text = "Total Amount:"; // If no value, show a default value
                amountLabelVaule1.Text = "0 TL";
            }
        }

        private void tickButton_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL connection and commands
                using (var connection = new SqlConnection(GlobalVariables.ConnectionString))
                {
                    connection.Open();

                    // Inserting data into the Payment table
                    string insertPaymentQuery = "INSERT INTO Payment (MemberID, Amount, PaymentDate, PaymentStatus) " +
                                                 "VALUES (@MemberID, @Amount, @PaymentDate, @PaymentStatus)";

                    using (var command = new SqlCommand(insertPaymentQuery, connection))
                    {
                        // Define MemberID and Amount values here
                        int memberId = this.MemberID; // MemberID from Payment form
                        decimal amount = this.MembershipAmount.HasValue ? this.MembershipAmount.Value : 0; // Use MembershipAmount if available, otherwise 0

                        command.Parameters.AddWithValue("@MemberID", memberId);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                        command.Parameters.AddWithValue("@PaymentStatus", true); // Payment made

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Payment successfully recorded!");
                    this.Close(); // Close the form after successful payment

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
