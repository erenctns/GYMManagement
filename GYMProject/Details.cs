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
    public partial class Details : Form
    {
        private int activeMembers = 0; // Number of active members
        private int trainerCount = 0; // Number of trainers
        private decimal totalIncome = 0; // Total income
        private int classCount = 0; // Number of classes

        public Details()
        {
            InitializeComponent();
        }

        private void showIncomesButton_Click(object sender, EventArgs e)
        {
            // Open a new form to display income and member count
            ClassDetails incomeForm = new ClassDetails();
            incomeForm.Show();
        }

        private void expirationButton_Click(object sender, EventArgs e)
        {
            ExpiringMembershipsForm expiringForm = new ExpiringMembershipsForm();
            expiringForm.Show();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            // Database connection string
            string connectionString = GlobalVariables.ConnectionString;

            // Define SQL queries
            string activeMembersQuery = "SELECT COUNT(*) AS ActiveMembers \r\nFROM Membership \r\nWHERE StartDate >= DATEADD(MONTH, -1, GETDATE());";
            string trainerCountQuery = "SELECT COUNT(*) AS TrainerCount FROM Trainer";
            string totalIncomeQuery = @"
                    SELECT 
                     SUM(M.Price) AS TotalIncome,
                     (SELECT SUM(P.Quantity * Pr.Price) 
                    FROM Purchase P
                    JOIN Product Pr ON P.ProductID = Pr.ProductID
                    WHERE P.PurchaseDate >= DATEADD(YEAR, -1, GETDATE())) AS TotalPurchaseIncome
                    FROM Membership M
                    WHERE M.StartDate >= DATEADD(YEAR, -1, GETDATE());";
            string classCountQuery = "SELECT COUNT(*) AS ClassCount FROM Class";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Execute query for active members
                    SqlCommand cmdActiveMembers = new SqlCommand(activeMembersQuery, conn);
                    SqlDataReader readerActiveMembers = cmdActiveMembers.ExecuteReader();
                    if (readerActiveMembers.Read())
                    {
                        activeMembers = readerActiveMembers.IsDBNull(0) ? 0 : readerActiveMembers.GetInt32(0); // Active member count
                    }
                    readerActiveMembers.Close();

                    // Execute query for trainer count
                    SqlCommand cmdTrainerCount = new SqlCommand(trainerCountQuery, conn);
                    SqlDataReader readerTrainerCount = cmdTrainerCount.ExecuteReader();
                    if (readerTrainerCount.Read())
                    {
                        trainerCount = readerTrainerCount.IsDBNull(0) ? 0 : readerTrainerCount.GetInt32(0); // Trainer count
                    }
                    readerTrainerCount.Close();

                    // Execute query for total income
                    SqlCommand cmdTotalIncome = new SqlCommand(totalIncomeQuery, conn);
                    SqlDataReader readerTotalIncome = cmdTotalIncome.ExecuteReader();
                    if (readerTotalIncome.Read())
                    {
                        decimal membershipIncome = readerTotalIncome.IsDBNull(0) ? 0 : readerTotalIncome.GetDecimal(0); // Membership income
                        decimal purchaseIncome = readerTotalIncome.IsDBNull(1) ? 0 : readerTotalIncome.GetDecimal(1); // Product purchases income
                        totalIncome = membershipIncome + purchaseIncome; // Total of membership and product purchases
                    }
                    readerTotalIncome.Close();

                    // Execute query for class count
                    SqlCommand cmdClassCount = new SqlCommand(classCountQuery, conn);
                    SqlDataReader readerClassCount = cmdClassCount.ExecuteReader();
                    if (readerClassCount.Read())
                    {
                        classCount = readerClassCount.IsDBNull(0) ? 0 : readerClassCount.GetInt32(0); // Class count
                    }
                    readerClassCount.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            // Display results on the form
            activeMembersLabel.Text = activeMembers.ToString();
            trainerCountLabel.Text = trainerCount.ToString();
            totalIncomeLabel.Text = totalIncome.ToString("C"); // Display total income with currency formatting
            classCountLabel.Text = classCount.ToString();
        }

        private void ıncomesButton_Click(object sender, EventArgs e)
        {
            // Open the "Incomes" form
            Incomes incomeForm = new Incomes();
            incomeForm.Show();
        }
    }
}
