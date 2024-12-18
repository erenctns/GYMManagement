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
            string connectionString = GlobalVariables.ConnectionString;
            // Get the username and password
            string username = userNameTextBox.Text;  // Username textBox
            string password = passwordTextBox.Text;  // Password textBox

            // Database connection string


            // SQL query: Get the user's role
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
                            int memberId = reader.GetInt32(0); // First column: MemberID
                            string role = reader.GetString(1).Trim(); // Second column: Role

                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Check the role
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
                            MessageBox.Show("Incorrect username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(204, 255, 255, 255);

            int cornerRadius = 60;


            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Top left corner
            path.AddArc(panel1.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Top right corner
            path.AddArc(panel1.Width - cornerRadius, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bottom right corner
            path.AddArc(0, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bottom left corner
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

            // Set the initial state of the eye icon
            eyePictureBox.Image = Properties.Resources.hide;
            eyePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void eyePictureBox_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Hide the password
                passwordTextBox.PasswordChar = '*';
                eyePictureBox.Image = Properties.Resources.hide;  // Closed eye icon
            }
            else
            {
                // Show the password
                passwordTextBox.PasswordChar = '\0';  // Shows the password
                eyePictureBox.Image = Properties.Resources.eye;  // Open eye icon
            }

            // Toggle the state
            isPasswordVisible = !isPasswordVisible;
        }
    }
}
