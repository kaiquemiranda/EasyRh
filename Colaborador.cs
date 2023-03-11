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
    public partial class Colaborador : Form
    {
        public Colaborador()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\MeuColaboradorDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if (Colab_ID.Text == "" || Colab_Nome.Text == "" || Colab_Endereco.Text == "" || Colab_Funcao.Text == "" || Colab_Nasc.Text == "" || Colab_Telefone.Text == "" || Colab_Ensino.Text == "" || Colab_Genero.Text == "")
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "INSERT INTO ColaboradorTbl VALUES ('" + Colab_ID.Text + "','" + Colab_Nome.Text + "','" + Colab_Endereco.Text + "','" + Colab_Funcao.SelectedItem.ToString() + "','" + Colab_Nasc.Value.Date + "','" + Colab_Telefone.Text + "','" + Colab_Ensino.SelectedItem.ToString() + "','" + Colab_Genero.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Funcionario Registrado com Sucesso!");
                    Con.Close();
                    Preencher();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home inicio = new Home();
            inicio.Show();
            this.Hide();
        }

        private void Preencher()
        {
            Con.Open();
            string query = "select * from ColaboradorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder construtor = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ColabDGV.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void Colaborador_Load(object sender, EventArgs e)
        {
            Preencher();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Colab_ID.Text == "")
            {
                MessageBox.Show("Digite o id do funcionario: ");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from ColaboradorTbl where Colab_ID = '" + Colab_ID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Funcionario excluido com sucesso!");
                    Con.Close();
                    Preencher();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ColabDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Colab_ID.Text = ColabDGV.SelectedRows[0].Cells[0].Value.ToString();
            Colab_Nome.Text = ColabDGV.SelectedRows[0].Cells[1].Value.ToString();
            Colab_Endereco.Text = ColabDGV.SelectedRows[0].Cells[2].Value.ToString();
            Colab_Ensino.Text = ColabDGV.SelectedRows[0].Cells[6].Value.ToString();
            Colab_Funcao.Text = ColabDGV.SelectedRows[0].Cells[3].Value.ToString();
            Colab_Telefone.Text = ColabDGV.SelectedRows[0].Cells[5].Value.ToString();
            Colab_Genero.Text = ColabDGV.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Colab_ID.Text == "" || Colab_Nome.Text == "" || Colab_Endereco.Text == "" || Colab_Funcao.Text == "" || Colab_Nasc.Text == "" || Colab_Telefone.Text == "" || Colab_Ensino.Text == "" || Colab_Genero.Text == "")
            {
                MessageBox.Show("Todos os campos precisam ser preenchidos!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update ColaboradorTbl set Colab_Nome = '"+ Colab_Nome.Text + "',Colab_Endereco = '"+ Colab_Endereco .Text+ "', Colab_Funcao = '"+ Colab_Funcao.SelectedItem.ToString()+"', Colab_Nasc = '"+ Colab_Nasc.Value.Date+"', Colab_Telefone = '"+ Colab_Telefone.Text+ "', Colab_Ensino = '"+ Colab_Ensino.SelectedItem.ToString()+"', Colab_Genero = '"+ Colab_Genero.SelectedItem.ToString()+ "' where Colab_ID = '"+Colab_ID.Text+"'; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Funcionario alterado com sucesso!");
                    Con.Close();
                    Preencher();

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
