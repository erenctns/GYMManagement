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
        private int memberId; // Kullanıcının MemberID'sini tutmak için
        private int currentMemberId;
        public AnaEkranCustomer(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId; // Constructor'dan gelen MemberID'yi sakla
            currentMemberId = memberId;
        }

        private void AnaEkranCustomer_Load(object sender, EventArgs e)
        {
            ShowRemainingMembershipDays();
        }

        private async void ShowRemainingMembershipDays()
        {
            await Task.Delay(500); // Form tamamen yüklendikten sonra 500 ms gecikme (isteğe bağlı)

            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=EMREEROGLU\\SQLEXPRESS;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

            // Kullanıcının EndDate bilgisini almak için SQL sorgusu
            string query = "SELECT EndDate FROM Membership WHERE MemberID = @memberId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@memberId", memberId); // MemberID'yi sorguya ekle

                    object result = cmd.ExecuteScalar();

                    if (result != null && DateTime.TryParse(result.ToString(), out DateTime endDate))
                    {
                        // Kalan gün sayısını hesapla
                        int remainingDays = (endDate - DateTime.Now).Days;

                        // Kullanıcıya bilgi ver
                        if (remainingDays > 0)
                        {
                            MessageBox.Show($"Üyeliğinizin bitmesine {remainingDays} gün kaldı.", "Üyelik Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Üyelik süreniz sona ermiştir.", "Üyelik Durumu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Üyelik bilgisi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void customerInfo_Click(object sender, EventArgs e)
        {
            CustomerInfo userInfoForm = new CustomerInfo(currentMemberId);
            userInfoForm.Show();
        }
    }
}
