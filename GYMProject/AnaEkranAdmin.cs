using System.Data.SqlClient;
namespace GYMProject
{
    public partial class AnaEkranAdmin : Form
    {
        public AnaEkranAdmin()
        {
            InitializeComponent();
        }

        private void newMemberButton_Click(object sender, EventArgs e)
        {
            NewMember newMemberForm = new NewMember();
            newMemberForm.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            Equipment equipmentForm = new Equipment();
            equipmentForm.Show();

        }

        private void AnaEkranAdmin_Load(object sender, EventArgs e)
        {

        }

        private void memberList_Click(object sender, EventArgs e)
        {
            MemberList memberListForm = new MemberList();
            memberListForm.Show();

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            Giris girisForm = new Giris();
            this.Hide();
            girisForm.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newTrainerButton_Click(object sender, EventArgs e)
        {
            NewTrainer newTrainerForm = new NewTrainer();
            newTrainerForm.Show();
        }

        private void viewTrainersButton_Click(object sender, EventArgs e)
        {
            TrainerList trainerListForm = new TrainerList();
            trainerListForm.Show();
        }

        private void classesButton_Click(object sender, EventArgs e)
        {
            Class classForm = new Class();
            classForm.Show();
        }

        private void showIncomeButton_Click(object sender, EventArgs e)
        {
            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=EMREEROGLU\\SQLEXPRESS;Initial Catalog=GYMNEW;Integrated Security=True;Encrypt=False";

            // SQL sorgusunu oluştur
            string query = "SELECT SUM(Price) AS TotalIncome, COUNT(*) AS ActiveMembers FROM Membership WHERE MONTH(StartDate) = MONTH(GETDATE()) AND YEAR(StartDate) = YEAR(GETDATE())";

            decimal totalIncome = 0;
            int activeMembers = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL komutunu oluştur
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Sorguyu çalıştır ve sonucu al
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Veriyi oku
                    if (reader.Read())
                    {
                        totalIncome = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);  // Toplam gelir
                        activeMembers = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);  // Aktif üye sayısı
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }

            // Yeni formu aç ve gelir ile üye sayısını göster
            CustomerIncomeForm incomeForm = new CustomerIncomeForm();
            incomeForm.DisplayTotalIncome(totalIncome, activeMembers);
            incomeForm.Show();

        }
    }
}
