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
using ScottPlot;
using ScottPlot.Plottables;


namespace GYMProject
{
    public partial class Incomes : Form
    {
        private decimal monthlyIncome = 0;
        private decimal yearlyIncome = 0;
        private decimal productIncome = 0;

        public Incomes()
        {
            InitializeComponent();
        }

        private void Incomes_Load(object sender, EventArgs e)
        {
            // Veritabanı bağlantı dizesi
            string connectionString = GlobalVariables.ConnectionString;

            // SQL sorgularını oluştur
            string monthlyIncomeQuery = @"
                SELECT SUM(Price) AS MonthlyIncome 
                FROM Membership 
                WHERE MONTH(StartDate) = MONTH(GETDATE()) 
                AND YEAR(StartDate) = YEAR(GETDATE()) 
                AND MembershipType = 'Month'"; // Aylık abonelik gelirini al

            string yearlyIncomeQuery = @"
                SELECT SUM(Price) AS YearlyIncome 
                FROM Membership 
                WHERE MONTH(StartDate) = MONTH(GETDATE()) 
                AND YEAR(StartDate) = YEAR(GETDATE()) 
                AND MembershipType = 'Year'";  // Yıllık abonelik gelirini al

            string productIncomeQuery = @"
                SELECT SUM(P.Quantity * Pr.Price) AS ProductIncome
                FROM Purchase P
                JOIN Product Pr ON P.ProductID = Pr.ProductID
                WHERE MONTH(P.PurchaseDate) = MONTH(GETDATE()) 
                AND YEAR(P.PurchaseDate) = YEAR(GETDATE())";  // Ürün satışlarını al

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Aylık gelir sorgusunu çalıştır
                    SqlCommand cmdMonthlyIncome = new SqlCommand(monthlyIncomeQuery, conn);
                    SqlDataReader readerMonthlyIncome = cmdMonthlyIncome.ExecuteReader();
                    if (readerMonthlyIncome.Read())
                    {
                        monthlyIncome = readerMonthlyIncome.IsDBNull(0) ? 0 : readerMonthlyIncome.GetDecimal(0); // Aylık abonelik geliri
                    }
                    readerMonthlyIncome.Close();

                    // Yıllık gelir sorgusunu çalıştır
                    SqlCommand cmdYearlyIncome = new SqlCommand(yearlyIncomeQuery, conn);
                    SqlDataReader readerYearlyIncome = cmdYearlyIncome.ExecuteReader();
                    if (readerYearlyIncome.Read())
                    {
                        yearlyIncome = readerYearlyIncome.IsDBNull(0) ? 0 : readerYearlyIncome.GetDecimal(0); // Yıllık abonelik geliri
                    }
                    readerYearlyIncome.Close();

                    // Ürün satış gelirini sorgula
                    SqlCommand cmdProductIncome = new SqlCommand(productIncomeQuery, conn);
                    SqlDataReader readerProductIncome = cmdProductIncome.ExecuteReader();
                    if (readerProductIncome.Read())
                    {
                        productIncome = readerProductIncome.IsDBNull(0) ? 0 : readerProductIncome.GetDecimal(0); // Ürün satış geliri
                    }
                    readerProductIncome.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }



            PlotPieChart();
        }

        private void PlotPieChart()
        {

            // Yeni bir ScottPlot nesnesi oluştur
            var myPlot = formsPlot2.Plot;

            // Pie chart için değerler
            double[] values = { (double)monthlyIncome, (double)yearlyIncome, (double)productIncome };

            // Pie chart'ı ekle
            var pie = myPlot.Add.Pie(values);
            pie.ExplodeFraction = 0.1;
            pie.SliceLabelDistance = 0.5;

            // Pie dilimleri için etiketler ve efsane metinlerini ayarla
            double total = pie.Slices.Select(x => x.Value).Sum();
            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].LabelFontSize = 20;
                pie.Slices[i].Label = $"{pie.Slices[i].Value}"; // Dilim etiketlerini ayarla
                pie.Slices[i].LegendText = $"{pie.Slices[i].Value} " +
                    $"({pie.Slices[i].Value / total:p1})"; // Efsane metni ayarla
            }

            // Başlık ve diğer ayarları yap
            myPlot.Title("Gelir Dağılımı");
            myPlot.ShowLegend();

            // Gereksiz grafik bileşenlerini gizle
            myPlot.Axes.Frameless();
            myPlot.HideGrid();

            // Grafiği yenile
            formsPlot2.Refresh();
        }

      

       
    }
}
