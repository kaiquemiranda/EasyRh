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
using System.Reflection.Emit;

namespace EasyRH
{
    public partial class Salario : Form
    {
        public Salario()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\MeuColaboradorDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Colab_Endereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home inicio = new Home();
            inicio.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home inicio = new Home();
            inicio.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buscarDadosColab()
        {
            if (id_input.Text == "")
            {
                MessageBox.Show("Digite um ID de funcionario!");
            }
            else
            {
                Con.Open();
                string query = "select * from ColaboradorTbl where Colab_ID = '" + id_input.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    nome_input.Text = dr["Colab_Nome"].ToString();
                    funcao_input.Text = dr["Colab_Funcao"].ToString();
                   
                }
                Con.Close();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buscarDadosColab();
        }
        double baseDia, baseTotal, imposto, salReal;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("\n======DEMONSTRATIVO=====\n===========DE============\n=======PAGAMENTO========\n==========================", new Font("Century Gothic", 30, FontStyle.Bold), Brushes.Black, new Point(80));
            e.Graphics.DrawString("\nID Funcionario:_____" + id_input.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 250));
            e.Graphics.DrawString("\nNome:____________" + nome_input.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 350));
            e.Graphics.DrawString("\nFução:____________" + funcao_input.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 450));
            e.Graphics.DrawString("\nDias trabalhados:____" + trabalhados_input.Text, new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 550));
            e.Graphics.DrawString("\nSalario bruto:_______R$ " + baseTotal+",00", new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 650));
            e.Graphics.DrawString("\nImposto de renda:___R$" + imposto+",00", new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 750));
            e.Graphics.DrawString("\nSalario liquido:______R$" + salReal+",00", new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(40, 850));
            e.Graphics.DrawString("\nAssinatura do colaborador__________________", new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(20, 950));
            e.Graphics.DrawString("\n=====EASY RECURSOS HUMANOS LTDA=====", new Font("Century Gothic", 25, FontStyle.Regular), Brushes.Black, new Point(20, 1050));
 
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (funcao_input.Text == "")
            {
                MessageBox.Show("Selecione um funcionario");
            }else if(trabalhados_input.Text == "" || Convert.ToInt32(trabalhados_input.Text) > 28)
            {
                MessageBox.Show("Digite um numero valido de dias trabalhados!");
            }
            else
            {
                if(funcao_input.Text == "Gerente")
                {
                    baseDia = 400;
                }else if(funcao_input.Text == "Analista de dados")
                {
                    baseDia = 350;
                }
                else if (funcao_input.Text == "Desenvolvedor senior")
                {
                    baseDia = 300;
                }
                else if (funcao_input.Text == "Desenvolvedor pleno")
                {
                    baseDia = 200;
                }
                else if (funcao_input.Text == "Desenvolvedor jr")
                {
                    baseDia = 120;
                }
                baseTotal = baseDia * Convert.ToInt32(trabalhados_input.Text);
                imposto = baseTotal * 0.15;
                salReal = baseTotal - imposto;
                holerite.Text = "=====================================\r\n====DEMONSTRATIVO DE PAGAMENTO====\r\n=====================================\r\n\n  ID:______________" + id_input.Text + "\n  Nome:___________" + nome_input.Text + "\n  Cargo:___________"+ funcao_input.Text + "\n  Dias trabalhador:___"+ trabalhados_input.Text + "\n  Salario bruto:______R$ " + baseTotal + ",00" + "\n  Imposto de renda:__R$ " + imposto+",00" + "\n  Salario liquido_____R$ "+ salReal+",00" + "\n\nAssinatura do colaborador__________________\n=====================================";
            }
        }
    }
}
