using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Pagina
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }
        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from paginas";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adpter = new SqlDataAdapter();
                adpter.SelectCommand = command;

                DataTable table = new DataTable();
                adpter.Fill(table);
                return table;
            }
        }

        public void Salvar(int id, DateTime data, string nome, string fantasia, string cnpj, DateTime dataA, string cep, string rua, string numero, string bairro, string telefone, string email)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into paginas(data, nome, fantasia, cnpj, dataa, cep, rua, numero, bairro, telefone, email) values('" + data.ToString("yyyy-MM-dd") + "', '" + nome + "','" + fantasia + "', '" + cnpj + "','" + dataA.ToString("yyyy-MM-dd") + "','" + cep + "', '" + rua + "', '" + numero + "', '" + bairro + "', '" + telefone + "', '" + email + "')";
                if (id != 0)
                {
                    queryString = "update paginas set data='" + data.ToString("yyyy-MM-dd") + "', nome='" + nome + "', fantasia='" + fantasia + "', cnpj='" + cnpj + "', dataa='" + dataA + "', cep='" + cep + "', rua='" + rua + "', numero='" + numero + "', bairro='" + bairro + "', telefone='" + telefone + "', email='" + email + "' where id=" + id;
                }
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "delete from paginas where id=" + id;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public DataTable BuscaPorId(int id)
         {
            using (SqlConnection connection = new SqlConnection(sqlConn()))

            {
                string queryString = "select * from paginas where id=" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adpter = new SqlDataAdapter();
                adpter.SelectCommand = command;

                DataTable table = new DataTable();
                adpter.Fill(table);
                return table;
            }
        }
    }
}