using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GYMProject
{
    public partial class ClassMembers : Form
    {
        private int classID;

        public ClassMembers(int classID)
        {
            InitializeComponent();
            this.classID = classID;
        }

        private void ClassMembers_Load(object sender, EventArgs e)
        {
            LoadMembersData();
        }

        private void LoadMembersData()
        {
            try
            {
                string connectionString = GlobalVariables.ConnectionString;
                string query = @"
            SELECT m.MemberID, m.FirstName + ' ' + m.LastName AS FullName, m.Email, a.Date AS AttendanceDate
            FROM Member m
            INNER JOIN Attendance a ON m.MemberID = a.MemberID
            WHERE a.ClassID = @ClassID";  // ClassID ile filtrele

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@ClassID", classID);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Veriyi bir DataGridView'e yükleyin
                    dataGridViewMembers.DataSource = dataTable;

                    // DataGridView ayarlarını düzenle
                    dataGridViewMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunları yatay doldur
                    dataGridViewMembers.Dock = DockStyle.Fill; // DataGridView'i formu kaplayacak şekilde ayarla
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
