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
        private int currentMemberId; // Giriş yapan kullanıcının MemberID'si

        public CustomerInfo(int memberId)
        {
            InitializeComponent();
            currentMemberId = memberId; // Giriş yapan kullanıcının MemberID'sini al
            InitializeDataGridView(); // DataGridView'i başlat
            LoadUserInfo(memberId); // Kullanıcı bilgilerini yükle
        }

        private void InitializeDataGridView()
        {
            // DataGridView'e sütunları programla ekliyoruz
            dataGridViewUserInfo.Columns.Clear(); // Önceden tanımlı sütunları temizle

            // Yeni sütunlar ekleyelim
            dataGridViewUserInfo.Columns.Add("FirstName", "First Name");
            dataGridViewUserInfo.Columns.Add("LastName", "Last Name");
            dataGridViewUserInfo.Columns.Add("StartDate", "Start Date");
            dataGridViewUserInfo.Columns.Add("EndDate", "End Date");
            dataGridViewUserInfo.Columns.Add("Price", "Price");
            dataGridViewUserInfo.Columns.Add("Username", "Username");
            dataGridViewUserInfo.Columns.Add("Password", "Password");

            // Daha sonra verileri ekleyebiliriz
        }

        private void LoadUserInfo(int memberId)
        {
            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=EMREEROGLU\\SQLEXPRESS;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

            // SQL sorgusu
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
                    // Bağlantıyı aç
                    conn.Open();

                    // SQL komutunu oluştur
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", memberId);

                    // Veriyi al
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // DataGridView'e verileri ekle
                        dataGridViewUserInfo.Rows.Clear(); // Var olanları temizle
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
                        MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
