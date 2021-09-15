using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Cadastro
{
    class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public Cliente(){}
        public Cliente(int id, string nome, string tel)
        {
            IdCliente = id;
            Nome = nome;
            Telefone = tel;
        }

        public bool SalvarDados(List<Cliente> cliente, string path)
        {
            var strJson = JsonConvert.SerializeObject(cliente, Formatting.Indented);
            return SalvarArquivo(strJson, path);
        }

        public bool SalvarArquivo(string strJson, string path)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(strJson);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha"+ ex.Message);
                return false;
            }
        }
    }
}
