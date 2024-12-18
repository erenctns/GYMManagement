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
    public partial class MyItemsForm : Form
    {
        private int currentMemberId;

        public MyItemsForm(int memberId)
        {
            InitializeComponent();
            currentMemberId = memberId;
        }

        private void MyItemsForm_Load(object sender, EventArgs e)
        {
            LoadMemberProducts();
        }

        private void LoadMemberProducts()
        {
            string connectionString = GlobalVariables.ConnectionString;
            string query = @"
        SELECT 
            p.ProductName, 
            SUM(pur.Quantity) AS TotalQuantity, 
            p.Price, 
            SUM(pur.Quantity * p.Price) AS TotalSpent
        FROM Product p
        JOIN Purchase pur ON p.ProductID = pur.ProductID
        WHERE pur.MemberID = @MemberID
        GROUP BY p.ProductName, p.Price";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", currentMemberId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Load the data into DataGridView
                    dataGridViewProducts.DataSource = dt;

                    // Update column headers
                    dataGridViewProducts.Columns["ProductName"].HeaderText = "Product Name";
                    dataGridViewProducts.Columns["TotalQuantity"].HeaderText = "Total Quantity";
                    dataGridViewProducts.Columns["Price"].HeaderText = "Unit Price";
                    dataGridViewProducts.Columns["TotalSpent"].HeaderText = "Total Spent";

                    // Calculate total spending
                    decimal totalSpent = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalSpent += row.IsNull("TotalSpent") ? 0 : Convert.ToDecimal(row["TotalSpent"]);
                    }

                    totalSpentLabel.Location = new Point(10, dataGridViewProducts.Bottom + 10); // You can leave 10px of space
                    totalSpentLabel.Size = new Size(200, 30); // Adjust the size
                    // Display the total spending in the label
                    totalSpentLabel.Text = $"Total Spending: {totalSpent:C}";
                    totalSpentLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
