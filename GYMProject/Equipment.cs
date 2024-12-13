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
            
            string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

            // SQL sorgu
            string query = "SELECT EquipmentID, EquipmentName, Quantity, Condition FROM Equipment";

            try
            {
                // Veritabanı bağlantısı
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Bağlantıyı açmayı deneyin
                    
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
                        else if (equipmentName == "Stationary Bike")
                        {
                            stationaryBikeName.Text = equipmentName;
                            stationaryBikeQuantity.Text = quantity;
                            stationaryBikeCondition.Text = condition;
                        }
                        else if (equipmentName == "Rowing Machine")
                        {
                            rowingMachineName.Text = equipmentName;
                            rowingMachineQuantity.Text = quantity;
                            rowingMachineCondition.Text = condition;
                        }
                        else if (equipmentName == "Elliptical Trainer")
                        {
                            ellipticalTrainerName.Text = equipmentName;
                            ellipticalTrainerQuantity.Text = quantity;
                            ellipticalTrainerCondition.Text = condition;
                        }
                        else if (equipmentName == "Smith Machine")
                        {
                            smitchMachineName.Text = equipmentName;
                            smithMachineQuantity.Text = quantity;
                            smithMachineCondition.Text = condition;
                        }
                        else if (equipmentName == "Dumbbell Set")
                        {
                            dumbbellSetName.Text = equipmentName;
                            dumbbellSetQuantity.Text = quantity;
                            dumbbellSetCondition.Text = condition;
                        }
                        else if (equipmentName == "Kettlebell Set")
                        {
                            kettlebellSetName.Text = equipmentName;
                            kettlebellSetQuantity.Text = quantity;
                            kettlebellSetCondition.Text = condition;
                        }
                        else if (equipmentName == "Lat Pulldown Machine")
                        {
                            latpullDownMachineName.Text = equipmentName;
                            latpullDownMachineQuantity.Text = quantity;
                            latpullDownMachineCondition.Text = condition;
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

        private void updateEquipmentsButton_Click(object sender, EventArgs e)
        {
            UpdateEquipmentForm updateEquipment = new UpdateEquipmentForm();
            updateEquipment.Show();
        }

        private void refreshDbButton_Click(object sender, EventArgs e)
        {
            Equipment_Load(sender, e);
            MessageBox.Show("Database Refreshed");
        }
    }
}
