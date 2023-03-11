using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyRH
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "admin" && textBox2.Text != "admin")
            {
                MessageBox.Show("Login invalido, tente novamente!");
            }
            else
            {
                try
                {
                    Home inicio = new Home();
                    MessageBox.Show("Logado com sucesso!");
                    inicio.Show();
                    this.Hide();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
                
            }
        }
    }
}
