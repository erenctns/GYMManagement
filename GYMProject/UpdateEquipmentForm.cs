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
        // Database connection string
        string connectionString = GlobalVariables.ConnectionString;


        public UpdateEquipmentForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(UpdateEquipmentForm_Load);
        }

        private void UpdateEquipmentForm_Load(object sender, EventArgs e)
        {
            // Load EquipmentName values into ComboBox
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

            // Load fixed values into conditionNameComboBox
            ConditionNameComboBox.Items.AddRange(new string[] { "Good", "Needs Repair", "Broken" });
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Get values from the form
                string selectedEquipment = EquipmentNameComboBox.SelectedItem?.ToString();
                int newQuantity = (int)quantityCounter.Value;
                string newCondition = ConditionNameComboBox.SelectedItem?.ToString();

                // Input validation
                if (string.IsNullOrEmpty(selectedEquipment))
                {
                    MessageBox.Show("Please select equipment!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (newQuantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(newCondition))
                {
                    MessageBox.Show("Please select a condition!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update the database
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
                        // Successful update, show message first, then close the form
                        MessageBox.Show("Equipment updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Close the form
                    }
                    else
                    {
                        MessageBox.Show("Update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void EquipmentNameComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Retrieve Quantity and Condition information for the selected EquipmentName
            string selectedEquipment = EquipmentNameComboBox.SelectedItem?.ToString();

            // If no item is selected, do nothing
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
                        // Fill NumericUpDown and ComboBox controls
                        quantityCounter.Value = Convert.ToInt32(reader["Quantity"]);
                        ConditionNameComboBox.SelectedItem = reader["Condition"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
