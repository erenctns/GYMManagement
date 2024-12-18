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

        private List<Label> targetLabels;

        private void Equipment_Load(object sender, EventArgs e)
        {
            string connectionString = GlobalVariables.ConnectionString;

            // SQL query
            string query = "SELECT EquipmentID, EquipmentName, Quantity, Condition FROM Equipment";

            try
            {
                // Database connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Attempt to open the connection

                    // Data retrieval
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Loading data into labels instead of a DataGridView
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string equipmentName = row["EquipmentName"].ToString();
                        string quantity = row["Quantity"].ToString();
                        string condition = row["Condition"].ToString();

                        // Safely assign data with null checks
                        if (string.IsNullOrEmpty(equipmentName) || string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(condition))
                        {
                            continue;  // Skip this row if any field is empty
                        }

                        // Assigning data to labels based on equipment name
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
                        // You can continue the same way for other equipment
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message);
            }

            targetLabels = new List<Label> { dumbbellCondition, treadmillCondition, stationaryBikeCondition, ellipticalTrainerCondition, smithMachineCondition, rowingMachineCondition, dumbbellSetCondition, kettlebellSetCondition, latpullDownMachineCondition };
            UpdateTargetLabelColors();
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

        private void dumbbellSetQuantity_Click(object sender, EventArgs e)
        {

        }
        private void UpdateTargetLabelColors()
        {
            foreach (Label label in targetLabels)
            {
                if (label.Text == "Good")
                {
                    label.ForeColor = Color.Green; // Text color green
                }
                else if (label.Text == "Needs Repair")
                {
                    label.ForeColor = Color.Gold; // Text color yellow
                }
                else if (label.Text == "Broken")
                {
                    label.ForeColor = Color.Red; // Text color red
                }
            }
        }

        private void dumbbellSetCondition_Click(object sender, EventArgs e)
        {

        }
    }
}
