using System.Drawing.Drawing2D;
using Microsoft.Data.SqlClient;

namespace GYMProject
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Giris_KeyDown);
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            PerformLogin();

        }

        private void PerformLogin()
        {
            string connectionString = GlobalVariables.ConnectionString;
            // Retrieve username and password
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;

            // SQL query to retrieve user's role
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
                            int memberId = reader.GetInt32(0); // MemberID from first column
                            string role = reader.GetString(1).Trim(); // Role from second column

                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Check role
                            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                            {
                                AnaEkranAdmin adminForm = new AnaEkranAdmin();
                                adminForm.Show();
                            }
                            else if (role.Equals("Customer", StringComparison.OrdinalIgnoreCase))
                            {
                                AnaEkranCustomer customerForm = new AnaEkranCustomer(memberId); // Pass MemberID
                                customerForm.Show();
                            }

                            this.Hide(); // Hide the login form
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Giris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
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
