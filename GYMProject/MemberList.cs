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
            this.Load += new EventHandler(MemberList_Load); // Load olayına MemberList_Load metodunu bağlama

            // DataGridView stillerini uygula
            StyleDataGridView();
        }

        private void MemberList_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 600);
            // Veritabanından verileri yükle ve DataGridView'e bağla
            LoadMemberData();
            AddDeleteButtonColumn();
            AddRegisterClassButtonColumn(); // Register Class butonunu ekle


            // Form boyutunu DataGridView'e göre ayarla
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
                // Veritabanı bağlantı dizesi
                string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

                // SQL sorgusu
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

                // Veritabanı bağlantısı
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQLDataAdapter kullanarak verileri al
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable(); // Verileri tutacak DataTable

                    // Verileri al ve DataTable'a doldur
                    adapter.Fill(dataTable);

                    // Verileri DataGridView'e aktar
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

       
        private void DeleteMember(int memberId)
        {
            try
            {
                // Veritabanı bağlantı dizesi
                string connectionString = "Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

                // Silme sorgusu
                string query = "DELETE FROM Member WHERE MemberID = @MemberID";

                // Veritabanı bağlantısı
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreyi ekle
                        command.Parameters.AddWithValue("@MemberID", memberId);

                        // Silme işlemini gerçekleştir
                        int rowsAffected = command.ExecuteNonQuery();

                        // Eğer herhangi bir satır silindiyse, başarılı olundu
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Üye başarıyla silindi.");
                            // Verileri yeniden yükle
                            LoadMemberData();
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
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
                    // İlgili MemberID'yi al
                    int memberId = Convert.ToInt32(selectedRow.Cells["MemberID"].Value);

                    // Yeni RegisterClass formunu aç ve MemberID'yi ilet
                    RegisterClass registerForm = new RegisterClass(memberId);
                    registerForm.ShowDialog();
                }
            }
        }
        private void AddDeleteButtonColumn()
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.HeaderText = "Sil";
            deleteButtonColumn.Text = "Sil";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButtonColumn);
        }
        private void StyleDataGridView()
        {

            // DataGridView'i formun tamamını kaplamasını sağlamak
            dataGridView1.Dock = DockStyle.Fill; // DataGridView'in formu tamamen doldurmasını sağlar

            // Diğer stil ayarları
            dataGridView1.AutoGenerateColumns = true;  // Kolonları otomatik oluşturur
            dataGridView1.AllowUserToAddRows = false;  // Kullanıcı yeni satır ekleyemez
            dataGridView1.AllowUserToDeleteRows = false;  // Kullanıcı satır silemez
            dataGridView1.ReadOnly = true;  // Veriler sadece okunabilir

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // vertical kaydırma

            // Hücre ve yazı tipi stilleri
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 45, 53);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            // Başlık satırı stili
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 45, 53);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            // Kolon hizalamaları
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Kenarlık stilleri
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.GridColor = Color.Gray;

            // Satır seçimi stilini ayarlama
            dataGridView1.RowHeadersVisible = false;  // Satır başlıklarını gizle
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  // Satır seçimini yap

            // Alternatif satır renkleri
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void AdjustFormSizeToDataGridView()
        {
            // DataGridView'in toplam boyutunu al
            int totalWidth = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            int totalHeight = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

            // DataGridView'e biraz padding eklemek (isteğe bağlı)
            totalWidth += 30; // Genişlik için biraz padding
            totalHeight += 80; // Yükseklik için biraz padding

            // Form boyutunu ayarlayın
            this.ClientSize = new Size(totalWidth, totalHeight);
        }

    }
}
