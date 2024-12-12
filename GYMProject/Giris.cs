using Microsoft.Data.SqlClient;

namespace GYMProject
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Kullanýcý adý ve þifreyi alýn
            string username = userNameTextBox.Text;  // Kullanýcý adý textBox'ý
            string password = passwordTextBox.Text;  // Þifre textBox'ý

            // Veritabaný baðlantý dizesi (Deðiþtirin: sunucu, veritabaný adý vb.)
            string connectionString = "Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GymDB;Integrated Security=True;Encrypt=False";

            // SQL sorgusu
            string query = "SELECT COUNT(1) FROM UserAuth WHERE Username = @username AND Password = @password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Baðlantýyý aç
                    conn.Open();

                    // SQL komutunu oluþtur
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); // Þifrenin güvenliði için hashing önerilir

                    // Sonucu kontrol et
                    int result = Convert.ToInt32(cmd.ExecuteScalar());

                    // Giriþ baþarýlýysa
                    if (result > 0)
                    {
                        MessageBox.Show("Giriþ baþarýlý!");

                        // AnaEkranAdmin formuna yönlendir
                        AnaEkranAdmin adminForm = new AnaEkranAdmin();
                        adminForm.Show();
                        this.Hide();  // Giriþ ekranýný gizle
                    }
                    else
                    {
                        MessageBox.Show("Kullanýcý adý veya þifre hatalý.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluþtu: " + ex.Message);
                }
            }
        }
    }
}
