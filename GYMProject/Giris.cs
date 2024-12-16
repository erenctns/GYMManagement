using System.Drawing.Drawing2D;
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
            string connectionString = GlobalVariables.ConnectionString;

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
                        MessageBox.Show("Giriþ baþarýlý!", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        // AnaEkranAdmin formuna yönlendir
                        AnaEkranAdmin adminForm = new AnaEkranAdmin();
                        adminForm.Show();
                        this.Hide();  // Giriþ ekranýný gizle
                    }
                    else
                    {
                        MessageBox.Show("Kullanýcý adý veya þifre hatalý!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluþtu: " + ex.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(204, 255, 255, 255);

            int cornerRadius = 60;


            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Sol üst
            path.AddArc(panel1.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Sað üst
            path.AddArc(panel1.Width - cornerRadius, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Sað alt
            path.AddArc(0, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Sol alt
            path.CloseFigure();
            panel1.Region = new Region(path);
        }

        private bool isPasswordVisible = false;
        private void Giris_Load(object sender, EventArgs e)
        {
            userNameLabel.BackColor = Color.Transparent;
            passwordLabel.BackColor = Color.Transparent;
            logoBox.BackColor = Color.Transparent;
            logoName1.BackColor = Color.Transparent;
            logoName2.BackColor = Color.Transparent;


            passwordTextBox.PasswordChar = '*';

            // Göz simgesinin ilk halini ayarlama
            eyePictureBox.Image = Properties.Resources.hide;
            eyePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void eyePictureBox_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Þifreyi gizle
                passwordTextBox.PasswordChar = '*';
                eyePictureBox.Image = Properties.Resources.hide;  // Göz kapalý simgesi
            }
            else
            {
                // Þifreyi göster
                passwordTextBox.PasswordChar = '\0';  // Þifreyi gösterir
                eyePictureBox.Image = Properties.Resources.eye;  // Göz açýk simgesi
            }

            // Durum deðiþtir
            isPasswordVisible = !isPasswordVisible;
        }
    }
}
