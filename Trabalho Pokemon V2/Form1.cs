using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Trabalho_Pokemon_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // faz a ligaçao com o banco de dados a partir da string de conexao feita pelo app config
            string conn = ConfigurationManager.ConnectionStrings["MySQLconnectionString"].ToString();
            //criaçao da variavel de conexao
            MySqlConnection conexao = new MySqlConnection(conn);
            // tenta abrir a conexao e exibe a mensagem 
            try
            {
                conexao.Open();
                MySqlCommand comando = new MySqlCommand();
                comando = conexao.CreateCommand();
                
                // faz a string de pesquisa 
                comando.CommandText = "select treinador from pokemon_table;";
                MySqlDataReader reader = comando.ExecuteReader();
                // enquanto nao for nulo o campo "treinador" e ira mostrar por mensagebox
                while (reader.Read())
                {
                    if(reader["Treinador"] != null)
                    {
                        MessageBox.Show(reader["Treinador"].ToString());
                    }
                }
            }
            // se nao conseguir realizar a conexao com o banco ira aparecer a mensagem de erro
            catch (MySqlException msqle)
            {
                MessageBox.Show("Erro de acesso ao mysql: " + msqle.Message, "Erro");
            }
            // finalmente ira fechar a conexao com o banco de dados
            finally
            {
                conexao.Close();
            }
        }

        
    }
}
