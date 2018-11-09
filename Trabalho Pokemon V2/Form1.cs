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
            string conn = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
            MySqlConnection conexao = new MySqlConnection(conn);

            try
            {
                conexao.Open();
                MessageBox.Show("conexão criada com sucesso");
            }
            catch(MySqlException msqle)
            {
                MessageBox.Show("Erro de acesso a Conexão: " + msqle.Message, "Erro");
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
