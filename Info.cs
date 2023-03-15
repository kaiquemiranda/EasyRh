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

namespace EasyRH
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\MeuColaboradorDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void buscarDadosColab()
        {
            Con.Open();
            string query = "select * from ColaboradorTbl where Colab_ID = '"+idBuscar.Text+ "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                IdLabel.Text = dr["Colab_ID"].ToString();
                enderecoLabel.Text = dr["Colab_Endereco"].ToString();
                funcaoLabel.Text = dr["Colab_Funcao"].ToString();
                ensinoLabel.Text = dr["Colab_Ensino"].ToString();
                nomeLabel.Text = dr["Colab_Nome"].ToString();
                generoLabel.Text = dr["Colab_Genero"].ToString();
                nascLabel.Text = dr["Colab_Nasc"].ToString();
                telefoneLabel.Text = dr["Colab_Telefone"].ToString();
            }
            Con.Close();
            
        }
        private void Info_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarDadosColab();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home inicio = new Home();
            inicio.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home inicio = new Home();
            inicio.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("\n=======INFORMAÇÕES======\n===========DO============\n=======FUNCIONARIO=======\n==========================", new Font("Century Gothic", 30,FontStyle.Bold),Brushes.Black,new Point(80));
            e.Graphics.DrawString("\nID Funcionario:___"+ IdLabel.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40,250 ));
            e.Graphics.DrawString("\nNome:__________" + nomeLabel.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 350));
            e.Graphics.DrawString("\nEndereço:_______" + enderecoLabel.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 450));
            e.Graphics.DrawString("\nGenero:_________" + generoLabel.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 550));
            e.Graphics.DrawString("\nCargo:__________" + funcaoLabel.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 650));
            e.Graphics.DrawString("\nNascimento:_____" + nascLabel.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 750));
            e.Graphics.DrawString("\nNivel de Ensino:__" + ensinoLabel.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 850));
            e.Graphics.DrawString("\nTelefone:_______" + telefoneLabel.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 950));
            e.Graphics.DrawString("\n=====EASY RECURSOS HUMANOS LTDA=====", new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(20, 1050));


        }
    }
}
