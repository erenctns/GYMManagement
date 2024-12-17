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
    public partial class ExpiringMembershipsForm : Form
    {
        public ExpiringMembershipsForm()
        {
            InitializeComponent();
        }

        private void ExpiringMembershipsForm_Load(object sender, EventArgs e)
        {
            // Üyelik süresi dolmak üzere olan üyeleri kontrol et
            LoadMembershipExpirationData();
        }

        private void LoadMembershipExpirationData()
        {
            string connectionString = GlobalVariables.ConnectionString;
            string query = @"
                SELECT m.FirstName, m.LastName, ms.EndDate 
                FROM Member m
                JOIN Membership ms ON m.MemberID = ms.MemberID
                WHERE DATEDIFF(DAY, GETDATE(), ms.EndDate) <= 27
                ORDER BY ms.EndDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // DataGridView'e verileri yükle
                    dataGridViewExpiringMemberships.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dataGridViewExpiringMemberships_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Bitiş tarihi sütunu (ExpirationDate) varsayılan olarak 3. sütun
                if (dataGridViewExpiringMemberships.Columns[e.ColumnIndex].Name == "EndDate")
                {
                    DateTime EndDate = Convert.ToDateTime(dataGridViewExpiringMemberships.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (EndDate <= DateTime.Now.AddDays(27))
                    {
                        e.CellStyle.BackColor = Color.Red; // Yaklaşan tarihler kırmızı
                        e.CellStyle.ForeColor = Color.White; // Yazıyı beyaz yap
                    }
                }
            }
        }
    }
}
