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
    public partial class MyClassesForm : Form
    {
        private int memberId;
        public MyClassesForm(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId;
        }

        private void MyClassesForm_Load(object sender, EventArgs e)
        {
            LoadMemberClasses(memberId);
        }

        private void LoadMemberClasses(int memberId)
        {
            string connectionString = GlobalVariables.ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetMemberClasses", conn);
                    cmd.CommandType = CommandType.StoredProcedure; // Call hide prosedure
                    cmd.Parameters.AddWithValue("@MemberID", memberId); // UserID that tries to log on

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // DataGridView'e verileri yükle
                    dataGridViewMemberClasses.DataSource = dt;

                    // Sütun başlıklarını Türkçeleştir
                    dataGridViewMemberClasses.Columns["ClassName"].HeaderText = "Class Name";
                    dataGridViewMemberClasses.Columns["Schedule"].HeaderText = "Program";
                    dataGridViewMemberClasses.Columns["ClassType"].HeaderText = "Class Type";
                    dataGridViewMemberClasses.Columns["TrainerFullName"].HeaderText = "Trainer";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

    }
}
