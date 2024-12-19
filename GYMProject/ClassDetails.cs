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
            // Fetch data from the database
            (string[] classNames, double[] attendanceCounts) = GetClassAttendanceData();

            // Display data on the graph
            PlotGraph(classNames, attendanceCounts);
        }

        private (string[] classNames, double[] attendanceCounts) GetClassAttendanceData()
        {
            // Database connection string
            string connectionString = GlobalVariables.ConnectionString;

            // SQL query: Retrieve the number of participants for each class
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
                    // Show a message to the user in case of an error
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return (classNames.ToArray(), attendanceCounts.ToArray());
        }

        private void PlotGraph(string[] classNames, double[] attendanceCounts)
        {
            // Create a new ScottPlot Plot object
            var plt = formsPlot1.Plot;

            // Add a bar chart
            plt.Add.Bars(attendanceCounts);  // AddBar is used

            // Set title and axis labels
            plt.Title("Attendance Count by Class");
            plt.YLabel("Attendance Count");
            plt.XLabel("Classes");

            // Set X-axis labels
            double[] xPositions = System.Linq.Enumerable.Range(0, classNames.Length).Select(i => (double)i).ToArray();
            plt.Axes.Bottom.SetTicks(xPositions, classNames);

            // Refresh the graph
            formsPlot1.Refresh();
        }
    }
}
