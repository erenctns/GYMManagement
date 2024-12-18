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
                    cmd.Parameters.AddWithValue("@MemberID", memberId); // ID of the logged-in member
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Load the data into DataGridView
                    dataGridViewMemberClasses.DataSource = dt;

                    dataGridViewMemberClasses.Columns["ClassName"].HeaderText = "Class Name";
                    dataGridViewMemberClasses.Columns["Schedule"].HeaderText = "Schedule";
                    dataGridViewMemberClasses.Columns["ClassType"].HeaderText = "Class Type";
                    dataGridViewMemberClasses.Columns["TrainerFullName"].HeaderText = "Trainer";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

    }
}
