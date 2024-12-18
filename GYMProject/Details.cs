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
    public partial class Details : Form
    {
        private int activeMembers = 0;
        private int trainerCount = 0;
        private decimal totalIncome = 0;
        private int classCount = 0;

        public Details()
        {
            InitializeComponent();
        }

        private void showIncomesButton_Click(object sender, EventArgs e)
        {

            // Yeni formu aç ve gelir ile üye sayısını göster
            ClassDetails incomeForm = new ClassDetails();
            incomeForm.Show();
        }



        private void expirationButton_Click(object sender, EventArgs e)
        {
            ExpiringMembershipsForm expiringForm = new ExpiringMembershipsForm();
            expiringForm.Show();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            // Veritabanı bağlantı dizesi
            string connectionString = GlobalVariables.ConnectionString;


            // SQL sorgusunu oluştur
            string activeMembersQuery = "SELECT COUNT(*) AS ActiveMembers FROM Membership WHERE MONTH(StartDate) = MONTH(GETDATE()) AND YEAR(StartDate) = YEAR(GETDATE())";
            string trainerCountQuery = "SELECT COUNT(*) AS TrainerCount FROM Trainer";
            string totalIncomeQuery = @"
                SELECT 
                    SUM(M.Price) AS TotalIncome,
                    (SELECT SUM(P.Quantity * Pr.Price) 
                     FROM Purchase P
                     JOIN Product Pr ON P.ProductID = Pr.ProductID
                     WHERE MONTH(P.PurchaseDate) = MONTH(GETDATE()) 
                     AND YEAR(P.PurchaseDate) = YEAR(GETDATE())) AS TotalPurchaseIncome
                FROM Membership M
                WHERE MONTH(M.StartDate) = MONTH(GETDATE()) 
                AND YEAR(M.StartDate) = YEAR(GETDATE())";
            string classCountQuery = "SELECT COUNT(*) AS ClassCount FROM Class";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Aktif üyeler sorgusunu çalıştır
                    SqlCommand cmdActiveMembers = new SqlCommand(activeMembersQuery, conn);
                    SqlDataReader readerActiveMembers = cmdActiveMembers.ExecuteReader();
                    if (readerActiveMembers.Read())
                    {
                        activeMembers = readerActiveMembers.IsDBNull(0) ? 0 : readerActiveMembers.GetInt32(0);  // Aktif üye sayısı
                    }
                    readerActiveMembers.Close();

                    // Eğitmen sayısı sorgusunu çalıştır
                    SqlCommand cmdTrainerCount = new SqlCommand(trainerCountQuery, conn);
                    SqlDataReader readerTrainerCount = cmdTrainerCount.ExecuteReader();
                    if (readerTrainerCount.Read())
                    {
                        trainerCount = readerTrainerCount.IsDBNull(0) ? 0 : readerTrainerCount.GetInt32(0);  // Eğitmen sayısı
                    }
                    readerTrainerCount.Close();

                    // Toplam gelir sorgusunu çalıştır
                    SqlCommand cmdTotalIncome = new SqlCommand(totalIncomeQuery, conn);
                    SqlDataReader readerTotalIncome = cmdTotalIncome.ExecuteReader();
                    if (readerTotalIncome.Read())
                    {
                        decimal membershipIncome = readerTotalIncome.IsDBNull(0) ? 0 : readerTotalIncome.GetDecimal(0);  // Üyelik gelirleri
                        decimal purchaseIncome = readerTotalIncome.IsDBNull(1) ? 0 : readerTotalIncome.GetDecimal(1);  // Ürün harcamaları
                        totalIncome = membershipIncome + purchaseIncome;  // Üyelik ve ürün harcamalarını toplama
                    }
                    readerTotalIncome.Close();

                    // Sınıf sayısı sorgusunu çalıştır
                    SqlCommand cmdClassCount = new SqlCommand(classCountQuery, conn);
                    SqlDataReader readerClassCount = cmdClassCount.ExecuteReader();
                    if (readerClassCount.Read())
                    {
                        classCount = readerClassCount.IsDBNull(0) ? 0 : readerClassCount.GetInt32(0);  // Sınıf sayısı
                    }
                    readerClassCount.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }

            // Sonuçları formda göster
            activeMembersLabel.Text = activeMembers.ToString();
            trainerCountLabel.Text = trainerCount.ToString();
            totalIncomeLabel.Text = totalIncome.ToString("C");  // C formatıyla toplam gelir, para birimi ile gösteriliyor
            classCountLabel.Text = classCount.ToString();
        }

        private void ıncomesButton_Click(object sender, EventArgs e)
        {
            Incomes incomeForm = new Incomes();
            incomeForm.Show();
        }
    }

}
