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
    public partial class NewTrainer : Form
    {
        public NewTrainer()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Kullanıcı girişlerini al
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string gender = genderComboBox.SelectedItem?.ToString();
            int age = (int)ageCounter.Value;
            string phoneNumber = phoneNumberTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string specialization = specializationComboBox.SelectedItem?.ToString();

            // Validasyon kontrolü
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(specialization))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL bağlantısı
            string connectionString = "Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

            // Yeni kayıt ekleme sorgusu
            string insertQuery = @"INSERT INTO Trainer (FirstName, LastName, Gender, Age, PhoneNumber, Email, Specialization)
                                   VALUES (@FirstName, @LastName, @Gender, @Age, @PhoneNumber, @Email, @Specialization)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // SQL parametrelerini ekle
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Age", age);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Specialization", specialization);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Eğitmen başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm(); // Formu temizle
                        }
                        else
                        {
                            MessageBox.Show("Kayıt sırasında bir sorun oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ClearForm()
        {
            // Form alanlarını trainer eklendikten sonra temizle
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            genderComboBox.SelectedIndex = -1;
            ageCounter.Value = ageCounter.Minimum;
            phoneNumberTextBox.Clear();
            emailTextBox.Clear();
            specializationComboBox.SelectedIndex = -1;
        }



    }
    
}
