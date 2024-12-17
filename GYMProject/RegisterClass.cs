using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GYMProject
{
    public partial class RegisterClass : Form
    {
        private int memberId; // İlgili üyenin ID'si
        private CheckedListBox checkedListBoxClasses; // Çoklu seçim için CheckedListBox
        private Button btnRegister; // Sınıfa kayıt butonu

        public RegisterClass(int memberId)
        {
            this.memberId = memberId;
            InitializeComponent();
            InitializeFormControls();
            LoadClasses();
        }

        private void InitializeFormControls()
        {
            // Form ayarları
            this.Size = new Size(400, 450);
            this.Text = "Register Class";

            // CheckedListBox kontrolü
            checkedListBoxClasses = new CheckedListBox
            {
                Name = "checkedListBoxClasses",
                Size = new Size(300, 250),
                Location = new Point(50, 20),
                CheckOnClick = true // Tek tıklamayla seçim
            };
            this.Controls.Add(checkedListBoxClasses);

            // Buton kontrolü
            btnRegister = new Button
            {
                Name = "btnRegister",
                Text = "Sınıfa Kayıt Ol",
                Size = new Size(150, 40),
                Location = new Point(125, 300)
            };
            btnRegister.Click += BtnRegister_Click;
            this.Controls.Add(btnRegister);
        }

        private void LoadClasses()
        {
            try
            {
                string connectionString = GlobalVariables.ConnectionString;

                string query = "SELECT ClassID, Name FROM Class"; // Sınıf bilgilerini çek

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        checkedListBoxClasses.Items.Clear(); // Listeyi temizle

                        while (reader.Read())
                        {
                            // ClassID ve sınıf adını CheckedListBox'a ekle
                            checkedListBoxClasses.Items.Add($"{reader["ClassID"]}: {reader["Name"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (checkedListBoxClasses.CheckedItems.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir sınıf seçiniz.");
                return;
            }

            bool isAnyRegistrationSuccessful = false; // Başarılı kayıt durumu kontrolü

            foreach (var item in checkedListBoxClasses.CheckedItems)
            {
                try
                {
                    // Seçilen sınıftan ClassID'yi al
                    string selectedClass = item.ToString();
                    int classId = Convert.ToInt32(selectedClass.Split(':')[0]);

                    // Aynı üyeyi aynı sınıfa kaydetmeye çalışıyorsa uyarı ver
                    if (IsMemberAlreadyRegistered(memberId, classId))
                    {
                        MessageBox.Show($"Üye zaten {selectedClass.Split(':')[1]} sınıfına kayıtlı.");
                        continue; // Aynı sınıfa kayıt işlemine devam etme
                    }

                    // Kayıt işlemini gerçekleştir
                    RegisterMemberToClass(memberId, classId);
                    isAnyRegistrationSuccessful = true; // En az bir kayıt başarılı oldu
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }

            // Başarıyla kayıt edilen sınıf varsa genel bir mesaj göster
            if (isAnyRegistrationSuccessful)
            {
                MessageBox.Show("Seçilen sınıflara kayıt işlemi başarıyla tamamlandı.");
                this.Close();
            }
        }

        private bool IsMemberAlreadyRegistered(int memberId, int classId)
        {
            try
            {
                string connectionString = GlobalVariables.ConnectionString;

                string query = @"
                    SELECT COUNT(*) 
                    FROM Attendance 
                    WHERE MemberID = @MemberID AND ClassID = @ClassID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberID", memberId);
                        command.Parameters.AddWithValue("@ClassID", classId);

                        int count = (int)command.ExecuteScalar();
                        return count > 0; // Eğer kayıt varsa true döner
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kontrol sırasında hata: {ex.Message}");
                return true; // Hata durumunda tekrar kayıtı engellemek için true dönüyoruz
            }
        }

        private void RegisterMemberToClass(int memberId, int classId)
        {
            try
            {
                string connectionString = GlobalVariables.ConnectionString;

                string query = @"
                    INSERT INTO Attendance (MemberID, ClassID, Date)
                    VALUES (@MemberID, @ClassID, @Date)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberID", memberId);
                        command.Parameters.AddWithValue("@ClassID", classId);
                        command.Parameters.AddWithValue("@Date", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sınıfa kayıt sırasında hata: {ex.Message}");
            }
        }
    }
}
