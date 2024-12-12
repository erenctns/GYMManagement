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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
            this.Load += new EventHandler(Equipment_Load);
        }
        private void Equipment_Load(object sender, EventArgs e)
        {
            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GymDB;Integrated Security=True;Encrypt=False";

            // SQL sorgusu
            string query = "SELECT EquipmentID, EquipmentName, Quantity, Condition FROM Equipment";

            try
            {
                // Veritabanı bağlantısı
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Bağlantıyı açmayı deneyin
                    MessageBox.Show("Bağlantı başarılı!");
                    // Veri çekme işlemi
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // DataGridView yerine label'lara veri yükleme
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string equipmentName = row["EquipmentName"].ToString();
                        string quantity = row["Quantity"].ToString();
                        string condition = row["Condition"].ToString();

                        // Null kontrolü yaparak güvenli bir şekilde veri atayabilirsiniz
                        if (string.IsNullOrEmpty(equipmentName) || string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(condition))
                        {
                            continue;  // Eğer herhangi biri boşsa, o satırı atla
                        }

                        // Ekipman ismine göre Label'lara veri atama
                        if (equipmentName == "Dumbbell")
                        {
                            dumbbellName.Text = equipmentName;
                            dumbbellQuantity.Text = quantity;
                            dumbbellCondition.Text = condition;
                        }
                        else if (equipmentName == "Treadmill")
                        {
                            treadmillName.Text = equipmentName;
                            treadmillQuantity.Text = quantity;
                            treadmillCondition.Text = condition;
                        }
                        // Diğer ekipmanlar için de aynı şekilde devam edebilirsiniz
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
