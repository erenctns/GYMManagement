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
    public partial class Payment : Form
    {
        public int MemberID { get; set; } // MemberID'yi tutacak özellik

        public decimal? MembershipAmount { get; set; } // MembershipAmount'u decimal olarak tutalım

        // Yapıcı metot, MemberID'yi alacak
        public Payment(int memberId, decimal? membershipAmount)
        {
            InitializeComponent();
            this.MemberID = memberId; // MemberID'yi al ve property'ye ata
            this.MembershipAmount = membershipAmount; // MembershipAmount değerini al ve property'ye ata
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            
        }
        private void Payment_Load_1(object sender, EventArgs e)
        {
            // MembershipAmount değeri varsa label'a yazdır
            if (MembershipAmount.HasValue)
            {
                amountLabel1.Text = $"Membership Amount: {MembershipAmount.Value} TL";
            }
            else
            {
                amountLabel1.Text = "Membership Amount: 0 TL"; // Eğer değer yoksa, varsayılan bir değer göster
            }
        }

        private void tickButton_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL bağlantısı ve komutları
                using (var connection = new SqlConnection("Data Source=DESKTOP-M4M4Q6P;Initial Catalog=GymDB;Integrated Security=True;Encrypt=False"))
                {
                    connection.Open();

                    // Payment tablosuna veri ekleme
                    string insertPaymentQuery = "INSERT INTO Payment (MemberID, Amount, PaymentDate, PaymentStatus) " +
                                                 "VALUES (@MemberID, @Amount, @PaymentDate, @PaymentStatus)";

                    using (var command = new SqlCommand(insertPaymentQuery, connection))
                    {
                        // MemberID ve Amount değerlerini burada belirleyin
                        int memberId = this.MemberID; // Payment formundan gelen MemberID
                        decimal amount = this.MembershipAmount.HasValue ? this.MembershipAmount.Value : 0; // MembershipAmount varsa kullan, yoksa 0

                        command.Parameters.AddWithValue("@MemberID", memberId);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                        command.Parameters.AddWithValue("@PaymentStatus", true); // Ödeme yapıldı

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Payment successfully recorded!");
                    this.Close();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

      
    }
}