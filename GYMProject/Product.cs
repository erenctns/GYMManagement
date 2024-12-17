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
    public partial class Product : Form
    {
        string connectionString = GlobalVariables.ConnectionString;


        public Product()
        {
            InitializeComponent();
            this.Load += new EventHandler(Product_Load);
        }

        private void Product_Load(object sender, EventArgs e)
        {
            string query = "SELECT ProductName, Price, Stock FROM Product";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string productName = row["ProductName"].ToString();
                        string price = row["Price"].ToString();
                        string stock = row["Stock"].ToString();


                        if (productName == "Protein Bar")
                        {
                            proteinBarName.Text = productName;
                            proteinBarPrice.Text = price;
                            proteinBarStock.Text = stock;
                        }
                        else if (productName == "Whey Protein")
                        {
                            wheyProteinName.Text = productName;
                            wheyProteinPrice.Text = price;
                            wheyProteinStock.Text = stock;
                        }
                        else if (productName == "Workout Gloves")
                        {
                            workoutGlovesName.Text = productName;
                            workoutGlovesPrice.Text = price;
                            workoutGlovesStock.Text = stock;
                        }
                        else if (productName == "Water Bottle")
                        {
                            waterBottleName.Text = productName;
                            waterBottlePrice.Text = price;
                            waterBottleStock.Text = stock;
                        }
                        else if (productName == "BCAA Powder")
                        {
                            bcaaPowderName.Text = productName;
                            bcaaPowderPrice.Text = price;
                            bcaaPowderStock.Text = stock;
                        }
                        else if (productName == "Yoga Mat")
                        {
                            yogaMatName.Text = productName;
                            yogaMatPrice.Text = price;
                            yogaMatStock.Text = stock;
                        }
                        else if (productName == "Resistance Band")
                        {
                            resistanceBandName.Text = productName;
                            resistanceBandPrice.Text = price;
                            resistanceBandStock.Text = stock;
                        }
                        else if (productName == "Energy Drink")
                        {
                            energyDrinkName.Text = productName;
                            energyDrinkPrice.Text = price;
                            energyDrinkStock.Text = stock;
                        }
                        else if (productName == "Towel")
                        {
                            towelName.Text = productName;
                            towelPrice.Text = price;
                            towelStock.Text = stock;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void updateButton_Click_1(object sender, EventArgs e)
        {

            UpdateProduct updateProductForm = new UpdateProduct();
            updateProductForm.Show();
        }

        private void refreshDatabase_Click(object sender, EventArgs e)
        {
            Product_Load(sender, e);
            MessageBox.Show("Database Refreshed");
        }
    }
}
