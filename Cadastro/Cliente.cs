using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Cadastro
{
    public class Cliente
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

        public static List<Cliente> CarregarCliente(string path)
        {
            var strJson = OpenFileCliente(path);
            if (strJson.Substring(0,5) != "Falha")
            {
                return JsonConvert.DeserializeObject<List<Cliente>>(strJson);
            }
            else
            {
                var listClientes = new List<Cliente>();
                var cliente = new Cliente();
                cliente.Nome = strJson;
                listClientes.Add(cliente);
                cliente.Nome = strJson;
                return listClientes;
            }
        }

        public static List<Cliente> ListarCliente(string path)
        {
            var strJson = OpenFileCliente(path);
            if (strJson.Substring(0,5) != "Falha")
            {
                return JsonConvert.DeserializeObject<List<Cliente>>(strJson);
            }
            else
            {
                var listClientes = new List<Cliente>();
                var cliente = new Cliente();
                cliente.Nome = strJson;
                listClientes.Add(cliente);
                cliente.Nome = strJson;
                return listClientes;
            }
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

        private static string OpenFileCliente(string path)
        {
            try
            {
                var strJson = "";
                using(StreamReader sr = new StreamReader(path))
                {
                    strJson = sr.ReadToEnd();
                }
                return strJson;
            }
            catch (Exception ex)
            {
                return "Falha" + ex.Message;
            }
        }
    }
}
