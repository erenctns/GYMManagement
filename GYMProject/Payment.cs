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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GYMProject
{
    public partial class Payment : Form
    {
        public int MemberID { get; set; } // MemberID'yi tutacak özellik
        public decimal? MembershipAmount { get; set; } // MembershipAmount'u decimal olarak tutalım
        public string FullName { get; set; } // Full Name özelliği
        public string Email { get; set; } // Email özelliği
        public string MembershipType { get; set; } // Membership Type özelliği
        public DateTime PaymentDate { get; set; } // Bugünün tarihini tutacak özellik


        // Yapıcı metot, MemberID'yi alacak
        public Payment(int memberId, decimal? membershipAmount, string fullName, string email, string membershipType)
        {
            InitializeComponent();
            this.MemberID = memberId;
            this.MembershipAmount = membershipAmount;
            this.FullName = fullName;
            this.Email = email;
            this.MembershipType = membershipType;
            this.PaymentDate = DateTime.Now;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            
        }
        private void Payment_Load_1(object sender, EventArgs e)
        {
            fullNameLabel.Text = "Full Name:";
            fullnameLabelValue.Text = FullName;

            emailLabel.Text = "Email:";
            emailValueLabel.Text = Email;

            membershipTypeLabel.Text = "Membership Type:";
            membershipTypeLabelValue.Text = MembershipType;

            paymentDateLabel.Text = "Date:";
            string todayDate = DateTime.Now.ToString("dd/MM/yyyy"); 
            paymentDateLabelValue.Text = todayDate;

            // Tüm label'ların yazılarını sola hizalamak için
            fullNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            fullnameLabelValue.TextAlign = ContentAlignment.MiddleLeft;
            emailLabel.TextAlign = ContentAlignment.MiddleLeft;
            emailValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            membershipTypeLabel.TextAlign = ContentAlignment.MiddleLeft;
            membershipTypeLabelValue.TextAlign = ContentAlignment.MiddleLeft;
            amountLabel1.TextAlign = ContentAlignment.MiddleLeft;
            paymentDateLabelValue.TextAlign = ContentAlignment.MiddleLeft;
        

            // MembershipAmount değeri varsa label'a yazdır
            if (MembershipAmount.HasValue)
            {
                amountLabel1.Text = "Total Amount:";
                amountLabelVaule1.Text = MembershipAmount.Value + "TL";
            }
            else
            {
                amountLabel1.Text = "Total Amount:"; // Eğer değer yoksa, varsayılan bir değer göster
                amountLabelVaule1.Text = "0 TL";
            }
        }

        private void tickButton_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL bağlantısı ve komutları
                using (var connection = new SqlConnection("Data Source=DESKTOP-FAT5F5N\\SQLEXPRESS01;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False"))
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