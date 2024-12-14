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


        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void AnaEkranAdmin_Load(object sender, EventArgs e)
        {

        }

        private void memberListButton_Click(object sender, EventArgs e)
        {
            MemberList memberListForm = new MemberList();
            memberListForm.Show();

        }

        private void equipmentButton_Click(object sender, EventArgs e)
        {
            Equipment equipmentForm = new Equipment();
            equipmentForm.Show();
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
    }
}
