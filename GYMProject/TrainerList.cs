using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GYMProject
{
    public partial class TrainerList : Form
    {
        public TrainerList()
        {
            InitializeComponent();
            this.Load += new EventHandler(TrainerList_Load); // Attach the TrainerList_Load method to the Load event
        }

        private void TrainerList_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 600);

            // If the event is already attached, don't attach it again
            dataGridView1.CellContentClick -= dataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            // Load data from the database and bind it to the DataGridView
            LoadTrainerData();
            AddActionButtons();

            // Apply DataGridView styles
            StyleDataGridView();
        }

        private void AddActionButtons()
        {
            // Add delete button
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(deleteButtonColumn);

            // Add view button
            DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn
            {
                Name = "View",
                HeaderText = "View",
                Text = "View",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(viewButtonColumn);
        }

        private void LoadTrainerData()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

                string query = @"
                    SELECT 
                        TrainerID, FirstName, LastName, Gender, Age, PhoneNumber, Email, Specialization
                    FROM 
                        Trainer";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void DeleteTrainer(int trainerId)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

                string query = "DELETE FROM Trainer WHERE TrainerID = @TrainerID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Trainer deleted successfully.");
                            LoadTrainerData();
                        }
                        else
                        {
                            MessageBox.Show("Delete operation failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int trainerId = Convert.ToInt32(selectedRow.Cells["TrainerID"].Value);
                    DeleteTrainer(trainerId);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "View")
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    int trainerId = Convert.ToInt32(selectedRow.Cells["TrainerID"].Value);

                    // Open the TrainerSchedule form
                    TrainerSchedule scheduleForm = new TrainerSchedule(trainerId);
                    scheduleForm.Show(); // Open the form once
                }
            }
        }

        private void StyleDataGridView()
        {
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 45, 53);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 45, 53);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Expand columns to fill space

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (column.Name == "Email") // Set minimum width for specific columns
                {
                    column.MinimumWidth = 200;
                }
                else if (column.Name == "PhoneNumber")
                {
                    column.MinimumWidth = 150;
                }
            }

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.GridColor = Color.Gray;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }
    }
}
