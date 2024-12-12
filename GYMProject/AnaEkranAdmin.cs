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
    }
}
