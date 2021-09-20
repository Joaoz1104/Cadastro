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
        List<Cliente> listarClientes = new List<Cliente>();
        public Form1()
        {
            InitializeComponent();
            ExibirDados();
        }
        private void CarregarDados()
        {
            var MaxId = 0;
            MaxId = listarClientes.Max(x => x.IdCliente);
            cliente.IdCliente = MaxId + 1;
            cliente.Nome = txtNome.Text;
            cliente.Telefone = txtTel.Text;
            listarClientes.Add(cliente);

            dataGridDados.DataSource = null;
            dataGridDados.DataSource = listarClientes;
        }

        private void ExibirDados()
        {
            if (listarClientes.Count == 0)
            {
                var MaxId = listarClientes.Max(x => x.IdCliente);
                cliente.IdCliente = MaxId + 1;
                cliente.Nome = "Admin";
                cliente.Telefone = "27 981212525";
                listarClientes.Add(cliente);
            }
            else
            {
                listarClientes = cliente.carregarCliente( @"C:\Bd\BdCliente.json");
                dataGridDados.DataSource = listarClientes;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CarregarDados();

            if (cliente.SalvarDados(listarClientes, @"C:\Bd\BdCliente.json"))
            {
                MessageBox.Show("Dados Cadastrados com sucesso!");
            }
            txtNome.Text = "";
            txtTel.Text = "";
        }

        private void Editar(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow gridViewRow = dataGridDados.Rows[e.RowIndex];
                txtIdCliente.Text = gridViewRow.Cells[0].Value.ToString();
                txtNome.Text = gridViewRow.Cells[1].Value.ToString();
                txtTel.Text = gridViewRow.Cells[2].Value.ToString();

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIdCliente.Text);
            var elem = listarClientes.Where<Cliente>(x => x.IdCliente == id).FirstOrDefault();
            int index = listarClientes.IndexOf(elem);

            listarClientes[index].Nome = txtNome.Text;
            listarClientes[index].Telefone = txtTel.Text;
            if (cliente.SalvarListClientes(listarClientes, @"C:\Bd\BdCliente.json"))
            {
                MessageBox.Show("Dados Salvos");
            }
            ExibirDados();
            txtNome.Text = "";
            txtTel.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIdCliente.Text);
            var elem = listarClientes.Where<Cliente>(x => x.IdCliente == id).FirstOrDefault();
            int index = listarClientes.IndexOf(elem);

            listarClientes[index].Nome = txtNome.Text;
            listarClientes[index].Telefone = txtTel.Text;
            if (cliente.SalvarListClientes(listarClientes, @"C:\Bd\BdCliente.json"))
            {
                MessageBox.Show("Dados Salvos");
            }
            ExibirDados();
        }
    }
}
