namespace EasyRH
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int start = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}