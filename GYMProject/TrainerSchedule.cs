using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GYMProject
{
    public partial class TrainerSchedule : Form
    {
        private int trainerId; // Seçili eğitmenin ID'si

        public TrainerSchedule(int trainerId)
        {
            InitializeComponent();
            this.trainerId = trainerId; // Eğitmen ID'sini al
            this.Load += TrainerSchedule_Load;
        }

        private void TrainerSchedule_Load(object sender, EventArgs e)
        {
            this.Text = "Trainer Ders Programı";
            this.Size = new Size(800, 500);

            // DataGridView oluştur ve ayarla
            DataGridView dataGridViewSchedule = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };

            // Stil ayarlarını uygula
            StyleDataGridView(dataGridViewSchedule);

            // Veriyi yükle
            LoadTrainerSchedule(dataGridViewSchedule);

            // Form'a DataGridView ekle
            this.Controls.Add(dataGridViewSchedule);
        }

        private void LoadTrainerSchedule(DataGridView gridView)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

                string query = @"
                    SELECT 
                        ClassID AS [ID], 
                        Name AS [Ders Adı], 
                        Schedule AS [Program], 
                        ClassType AS [Ders Tipi]
                    FROM 
                        Class
                    WHERE 
                        TrainerID = @TrainerID
                    ORDER BY 
                        Schedule";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        gridView.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ders programı yüklenirken hata oluştu: {ex.Message}");
            }
        }

        private void StyleDataGridView(DataGridView gridView)
        {
            gridView.DefaultCellStyle.BackColor = Color.White;
            gridView.DefaultCellStyle.ForeColor = Color.Black;
            gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 45, 53);
            gridView.DefaultCellStyle.SelectionForeColor = Color.White;
            gridView.DefaultCellStyle.Font = new Font("Arial", 10);

            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 45, 53);
            gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            gridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridView.RowHeadersVisible = false;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }
    }
}
