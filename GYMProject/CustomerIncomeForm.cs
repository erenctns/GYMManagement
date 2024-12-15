using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMProject
{
    public partial class CustomerIncomeForm : Form
    {
        public CustomerIncomeForm()
        {
            InitializeComponent();
        }

        public void DisplayTotalIncome(decimal totalIncome, int activeMembers)
        {
            totalIncomeLabel.Text = "Bu Ayki Toplam Gelir: " + totalIncome.ToString("C");
            activeMembersLabel.Text = "Aktif Üye Sayısı: " + activeMembers.ToString();
        }

        private void CustomerIncomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
