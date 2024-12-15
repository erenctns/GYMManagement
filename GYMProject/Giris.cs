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

            // Veritabaný baðlantý dizesi
            string connectionString = "Data Source=EMREEROGLU\\SQLEXPRESS;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

            // SQL sorgusu: Kullanýcýnýn rolünü al
            string query = @"
                SELECT m.MemberID, m.Role
                FROM UserAuth u
                JOIN Member m ON u.MemberID = m.MemberID
                WHERE u.Username = @username AND u.Password = @password";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int memberId = reader.GetInt32(0); // Ýlk sütun MemberID
                            string role = reader.GetString(1).Trim(); // Ýkinci sütun Role

                            MessageBox.Show("Giriþ baþarýlý!", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Rolü kontrol et
                            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                            {
                                AnaEkranAdmin adminForm = new AnaEkranAdmin();
                                adminForm.Show();
                            }
                            else if (role.Equals("Customer", StringComparison.OrdinalIgnoreCase))
                            {
                                AnaEkranCustomer customerForm = new AnaEkranCustomer(memberId); // MemberID'yi geçir
                                customerForm.Show();
                            }

                            this.Hide(); // Giriþ ekranýný gizle
                        }
                        else
                        {
                            MessageBox.Show("Kullanýcý adý veya þifre hatalý!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
