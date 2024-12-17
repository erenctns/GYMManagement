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
            CheckMembershipExpiration();
            GetMemberName();
            welcomeLabel.BackColor = Color.Transparent;
        }

        private void CheckMembershipExpiration()
        {
            string connectionString = "Data Source=EMREEROGLU\\SQLEXPRESS;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
            string query = "SELECT EndDate FROM Membership WHERE MemberID = @MemberID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", currentMemberId); // Giriş yapan üyenin ID'si
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DateTime EndDate = reader.GetDateTime(0);
                        TimeSpan remainingDays = EndDate - DateTime.Now;

                        // Eğer üyelik bitiş tarihi 7 gün veya daha yakınsa pop-up göster
                        if (remainingDays.Days <= 27)
                        {
                            MessageBox.Show($"Üyeliğinizin bitmesine {remainingDays.Days} gün kaldı! Lütfen yenileyin.");
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void GetMemberName()
        {
            string connectionString = "Data Source=EMREEROGLU\\SQLEXPRESS;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";
            string query = "SELECT FirstName, LastName FROM Member WHERE MemberID = @MemberID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", currentMemberId); // Giriş yapan üyenin ID'si
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string firstName = reader.GetString(0);
                        string lastName = reader.GetString(1);

                        // Label'a "Welcome customer_name" yaz
                        welcomeLabel.Text = $"Welcome {firstName} {lastName}";
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
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
    }
}
