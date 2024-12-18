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
using ScottPlot;





namespace GYMProject
{


    public partial class ClassDetails : Form
    {

        public ClassDetails()
        {
            InitializeComponent();


        }



        private void CustomerIncomeForm_Load(object sender, EventArgs e)
        {
            // Veritabanından verileri çek
            (string[] classNames, double[] attendanceCounts) = GetClassAttendanceData();

            // Verileri grafikle
            PlotGraph(classNames, attendanceCounts);
        }

        private (string[] classNames, double[] attendanceCounts) GetClassAttendanceData()
        {
            // Veritabanı bağlantı dizesi
            string connectionString = GlobalVariables.ConnectionString;

            // SQL sorgusu: Her sınıftaki katılımcı sayısını getir
            string query = @"
                SELECT c.Name, COUNT(a.AttendanceID) AS AttendanceCount
                FROM Class c
                LEFT JOIN Attendance a ON c.ClassID = a.ClassID
                GROUP BY c.Name";

            List<string> classNames = new List<string>();
            List<double> attendanceCounts = new List<double>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        classNames.Add(reader["Name"].ToString());
                        attendanceCounts.Add(Convert.ToDouble(reader["AttendanceCount"]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            return (classNames.ToArray(), attendanceCounts.ToArray());
        }

        private void PlotGraph(string[] classNames, double[] attendanceCounts)
        {
            // Yeni bir ScottPlot Plot nesnesi oluştur
            var plt = formsPlot1.Plot;

            // Çubuk grafik ekle
            plt.Add.Bars(attendanceCounts);  // AddBar kullanılır

            // Başlık ve eksen isimleri
            plt.Title("Sınıflara Göre Katılım Sayısı");
            plt.YLabel("Katılım Sayısı");
            plt.XLabel("Sınıflar");

            // X ekseni etiketlerini ayarla
            double[] xPositions = System.Linq.Enumerable.Range(0, classNames.Length).Select(i => (double)i).ToArray();
            plt.Axes.Bottom.SetTicks(xPositions, classNames);

            // Grafik yenile
            formsPlot1.Refresh();
        }

    } 
    
}


