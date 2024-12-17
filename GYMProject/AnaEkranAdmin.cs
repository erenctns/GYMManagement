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

        private void productButton_Click(object sender, EventArgs e)
        {
            Product productForm = new Product();
            productForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PurchaseProduct purchaseProductForm = new PurchaseProduct();
            purchaseProductForm.Show();
        private void detailsButton_Click(object sender, EventArgs e)
        {
            Details detailsForm = new Details();
            detailsForm.Show();
        }
    }
}
