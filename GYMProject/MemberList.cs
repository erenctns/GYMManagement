using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace GYMProject
{
    public partial class MemberList : Form
    {
        public MemberList()
        {
            InitializeComponent();
            this.Load += new EventHandler(MemberList_Load); // Bind the MemberList_Load method to the Load event

            // Apply DataGridView styles
            StyleDataGridView();
        }

        private void MemberList_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 600);
            // Load data from the database and bind it to the DataGridView
            LoadMemberData();
            AddDeleteButtonColumn();
            AddRegisterClassButtonColumn(); // Add Register Class button


            // Adjust the form size according to the DataGridView
            //AdjustFormSizeToDataGridView();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void AddRegisterClassButtonColumn()
        {
            DataGridViewButtonColumn registerClassButton = new DataGridViewButtonColumn();
            registerClassButton.Name = "RegisterClass";
            registerClassButton.HeaderText = "Register Class";
            registerClassButton.Text = "Register";
            registerClassButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(registerClassButton);
        }


        private void LoadMemberData()
        {
            try
            {
                // Database connection string
                string connectionString = GlobalVariables.ConnectionString;

                // SQL query
                string query = @"
            SELECT 
                m.MemberID, m.FirstName, m.LastName, m.Age, m.PhoneNumber, m.Email, 
                ms.MembershipType, ms.StartDate, ms.EndDate, 
                ua.Username, ua.Password
            FROM 
                Member m
            LEFT JOIN 
                Membership ms ON m.MemberID = ms.MemberID
            LEFT JOIN 
                UserAuth ua ON m.MemberID = ua.MemberID";

                // Database connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Use SQLDataAdapter to retrieve data
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable(); // DataTable to store data

                    // Retrieve data and fill the DataTable
                    adapter.Fill(dataTable);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void DeleteMember(int memberId)
        {
            try
            {
                // Database connection string
                string connectionString = GlobalVariables.ConnectionString;

                // Delete query
                string query = "DELETE FROM Member WHERE MemberID = @MemberID";

                // Database connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter
                        command.Parameters.AddWithValue("@MemberID", memberId);

                        // Execute delete operation
                        int rowsAffected = command.ExecuteNonQuery();

                        // If any rows are affected, the operation was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member deleted successfully.");
                            // Reload the data
                            LoadMemberData();
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
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    int memberId = Convert.ToInt32(selectedRow.Cells["MemberID"].Value);
                    DeleteMember(memberId);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "RegisterClass")
                {
                    // Get the related MemberID
                    int memberId = Convert.ToInt32(selectedRow.Cells["MemberID"].Value);

                    // Open the new RegisterClass form and pass the MemberID
                    RegisterClass registerForm = new RegisterClass(memberId);
                    registerForm.ShowDialog();
                }
            }
        }
        private void AddDeleteButtonColumn()
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButtonColumn);
        }
        private void StyleDataGridView()
        {

            // Make the DataGridView fill the entire form
            dataGridView1.Dock = DockStyle.Fill; // Ensures DataGridView takes up the entire form

            // Other styling
            dataGridView1.AutoGenerateColumns = true;  // Automatically generate columns
            dataGridView1.AllowUserToAddRows = false;  // User cannot add rows
            dataGridView1.AllowUserToDeleteRows = false;  // User cannot delete rows
            dataGridView1.ReadOnly = true;  // Data is read-only

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // vertical scrolling

            // Cell and font styling
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 45, 53);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            // Header row styling
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 45, 53);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            // Column alignments
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Border styles
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.GridColor = Color.Gray;

            // Row selection style
            dataGridView1.RowHeadersVisible = false;  // Hide row headers
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  // Select entire rows

            // Alternate row colors
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void AdjustFormSizeToDataGridView()
        {
            // Get the total width of the DataGridView
            int totalWidth = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            int totalHeight = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

            // Add some padding to the DataGridView (optional)
            totalWidth += 30; // Add padding to the width
            totalHeight += 80; // Add padding to the height

            // Adjust the form size
            this.ClientSize = new Size(totalWidth, totalHeight);
        }

    }
}
