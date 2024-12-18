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
            string query = @"
        SELECT 
            C.Name AS ClassName,
            C.Schedule,
            C.ClassType,
            CONCAT(T.FirstName, ' ', T.LastName) AS TrainerFullName
        FROM 
            Attendance A
        INNER JOIN 
            Class C ON A.ClassID = C.ClassID
        INNER JOIN 
            Trainer T ON C.TrainerID = T.TrainerID
        WHERE 
            A.MemberID = @MemberID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", memberId); // Giriş yapan üyenin ID'si
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // DataGridView'e verileri yükle
                    dataGridViewMemberClasses.DataSource = dt;

                    dataGridViewMemberClasses.Columns["ClassName"].HeaderText = "Sınıf Adı";
                    dataGridViewMemberClasses.Columns["Schedule"].HeaderText = "Program";
                    dataGridViewMemberClasses.Columns["ClassType"].HeaderText = "Sınıf Türü";
                    dataGridViewMemberClasses.Columns["TrainerFullName"].HeaderText = "Eğitmen";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

    }
}
