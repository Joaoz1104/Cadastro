using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class Form1 : Form
    {
        Cliente cliente = new Cliente();
        List<Cliente> ListarClientes = new List<Cliente>();
        public Form1()
        {
            InitializeComponent();
        }
        public void CarregarDados()
        {
            cliente.IdCliente = int.Parse(txtIdCliente.Text);
            cliente.Nome = txtNome.Text;
            cliente.Telefone = txtTel.Text;
            ListarClientes.Add(cliente);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListarClientes;
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CarregarDados();

            if (cliente.SalvarDados(ListarClientes, @"C:/BdCliente.json"))
            {
                MessageBox.Show("Dados Cadastrados com sucesso!");
            }
            txtIdCliente.Text = "";
            txtNome.Text = "";
            txtTel.Text = "";
        }
    }
}
