using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GYMProject
{
    public partial class UpdateProduct : Form
    {
        string connectionString = GlobalVariables.ConnectionString;

        public UpdateProduct()
        {
            InitializeComponent();
            this.Load += new EventHandler(UpdateProduct_Load);
        }

        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            // Load ProductName values into ComboBox
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ProductName FROM Product", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productNameComboBox.Items.Add(reader["ProductName"].ToString());
                }
                reader.Close();
            }

            // Reset NumericUpDown values and set maximum value to unlimited
            productPriceCounter.Value = 0;
            productStockCounter.Value = 0;

            productPriceCounter.Maximum = decimal.MaxValue;
            productStockCounter.Maximum = decimal.MaxValue;
        }

        private void saveChangesButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Get selected product details
                string selectedProduct = productNameComboBox.SelectedItem?.ToString();
                decimal newPrice = productPriceCounter.Value;
                int newStock = (int)productStockCounter.Value;

                // Input validation
                if (string.IsNullOrEmpty(selectedProduct))
                {
                    MessageBox.Show("Please select a product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (newPrice <= 0)
                {
                    MessageBox.Show("Please enter a valid price!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (newStock < 0)
                {
                    MessageBox.Show("Please enter a valid stock quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update database operation
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Product SET Price = @Price, Stock = @Stock WHERE ProductName = @ProductName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Price", newPrice);
                    command.Parameters.AddWithValue("@Stock", newStock);
                    command.Parameters.AddWithValue("@ProductName", selectedProduct);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product successfully updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void productNameComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Retrieve price and stock information for the selected product
            string selectedProduct = productNameComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedProduct)) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Price, Stock FROM Product WHERE ProductName = @ProductName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName", selectedProduct);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Load price and stock values into NumericUpDown controls
                        productPriceCounter.Value = Convert.ToDecimal(reader["Price"]);
                        productStockCounter.Value = Convert.ToInt32(reader["Stock"]);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
