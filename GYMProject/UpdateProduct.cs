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
    public partial class UpdateProduct : Form
    {
        private string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

        public UpdateProduct()
        {
            InitializeComponent();
            this.Load += new EventHandler(UpdateProduct_Load);
        }

        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            // ComboBox'a ProductName değerlerini yükle
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

            // NumericUpDown'ları sıfırla
            productPriceCounter.Value = 0;
            productStockCounter.Value = 0;
        }


        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen ürün bilgilerini al
                string selectedProduct = productNameComboBox.SelectedItem?.ToString();
                decimal newPrice = productPriceCounter.Value;
                int newStock = (int)productStockCounter.Value;

                // Girdi kontrolü
                if (string.IsNullOrEmpty(selectedProduct))
                {
                    MessageBox.Show("Lütfen bir ürün seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (newPrice <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir fiyat girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (newStock < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir stok miktarı girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Veritabanını güncelleme işlemi
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
                        // Güncelleme başarılı
                        MessageBox.Show("Ürün başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Formu kapat
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız oldu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }
        private void productNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen ürüne ait fiyat ve stok bilgilerini getir
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
                        // Fiyat ve stok bilgilerini NumericUpDown'lara yükle
                        productPriceCounter.Value = Convert.ToDecimal(reader["Price"]);
                        productStockCounter.Value = Convert.ToInt32(reader["Stock"]);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
