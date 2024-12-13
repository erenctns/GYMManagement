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
    public partial class UpdateEquipmentForm : Form
    {
        // Veritabanı bağlantı dizesi
        private string connectionString = "Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

        public UpdateEquipmentForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(UpdateEquipmentForm_Load);
        }

        private void UpdateEquipmentForm_Load(object sender, EventArgs e)
        {
            // ComboBox'a EquipmentName değerlerini yükle
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT EquipmentName FROM Equipment", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EquipmentNameComboBox.Items.Add(reader["EquipmentName"].ToString());
                }
                reader.Close();
            }

            // conditionNameComboBox'a sabit değerleri yükle
            ConditionNameComboBox.Items.AddRange(new string[] { "Good", "Needs Repair", "Broken" });
        }
        private void saveButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Formdaki değerleri al
                string selectedEquipment = EquipmentNameComboBox.SelectedItem?.ToString();
                int newQuantity = (int)quantityCounter.Value;
                string newCondition = ConditionNameComboBox.SelectedItem?.ToString();

                // Girdi kontrolü
                if (string.IsNullOrEmpty(selectedEquipment))
                {
                    MessageBox.Show("Lütfen ekipman seçin!");
                    return;
                }
                if (newQuantity <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir miktar girin!");
                    return;
                }
                if (string.IsNullOrEmpty(newCondition))
                {
                    MessageBox.Show("Lütfen durum seçin!");
                    return;
                }

                // Veritabanını güncelle
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Equipment SET Quantity = @Quantity, Condition = @Condition WHERE EquipmentName = @EquipmentName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Quantity", newQuantity);
                    command.Parameters.AddWithValue("@Condition", newCondition);
                    command.Parameters.AddWithValue("@EquipmentName", selectedEquipment);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Güncelleme başarılı, önce mesaj göster, sonra formu kapat
                        MessageBox.Show("Ekipman başarıyla güncellendi!");
                        this.Close(); // Formu kapat
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız oldu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }        

        private void EquipmentNameComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Seçilen EquipmentName'e ait Quantity ve Condition bilgilerini getir
            string selectedEquipment = EquipmentNameComboBox.SelectedItem?.ToString();

            // Eğer seçili öğe yoksa, işlem yapma
            if (string.IsNullOrEmpty(selectedEquipment)) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Quantity, Condition FROM Equipment WHERE EquipmentName = @EquipmentName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EquipmentName", selectedEquipment);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // NumericUpDown ve ComboBox'ları doldur
                        quantityCounter.Value = Convert.ToInt32(reader["Quantity"]);
                        ConditionNameComboBox.SelectedItem = reader["Condition"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }

    }
}