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

                    // DataGridView'e verileri yükle
                    dataGridViewProducts.DataSource = dt;

                    // Başlıkları güncelle
                    dataGridViewProducts.Columns["ProductName"].HeaderText = "Ürün Adı";
                    dataGridViewProducts.Columns["TotalQuantity"].HeaderText = "Toplam Miktar";
                    dataGridViewProducts.Columns["Price"].HeaderText = "Birim Fiyat";
                    dataGridViewProducts.Columns["TotalSpent"].HeaderText = "Toplam Harcama";

                    // Genel toplam harcamayı hesapla
                    decimal totalSpent = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalSpent += row.IsNull("TotalSpent") ? 0 : Convert.ToDecimal(row["TotalSpent"]);
                    }


                    totalSpentLabel.Location = new Point(10, dataGridViewProducts.Bottom + 10); // 10px boşluk bırakabilirsiniz
                    totalSpentLabel.Size = new Size(200, 30); // Boyutları ayarlayın
                    // Toplam harcamayı label'a yazdır
                    totalSpentLabel.Text = $"Toplam Harcama: {totalSpent:C}";
                    totalSpentLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
