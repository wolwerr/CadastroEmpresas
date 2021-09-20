using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Pagina
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataA { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


        public List<Pagina> Lista()
        {
            var lista = new List<Pagina>();
            var paginasDb = new Database.Pagina();
            foreach(DataRow row in paginasDb.Lista().Rows)
            {
                var pagina = new Pagina();
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Data = Convert.ToDateTime(row["data"]);
                pagina.Nome = row["nome"].ToString();
                pagina.Fantasia = row["fantasia"].ToString();
                pagina.Cnpj = row["cnpj"].ToString();
                pagina.DataA = Convert.ToDateTime(row["dataA"]);
                pagina.Cep = row["cep"].ToString();
                pagina.Rua = row["rua"].ToString();
                pagina.Numero = row["numero"].ToString();
                pagina.Bairro = row["bairro"].ToString();
                pagina.Telefone = row["telefone"].ToString();
                pagina.Email = row["email"].ToString();


                lista.Add(pagina);
            }
            return lista;
        }

       
        public static Pagina BuscaPorId(int id)
        {
            var pagina = new Pagina();
            var paginasDb = new Database.Pagina();
            foreach (DataRow row in paginasDb.BuscaPorId(id).Rows)
            {
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Data = Convert.ToDateTime(row["data"]);
                pagina.Nome = row["nome"].ToString();
                pagina.Fantasia = row["fantasia"].ToString();
                pagina.Cnpj = row["cnpj"].ToString();
                pagina.DataA = Convert.ToDateTime(row["dataA"]);
                pagina.Cep = row["cep"].ToString();
                pagina.Rua = row["rua"].ToString();
                pagina.Numero = row["numero"].ToString();
                pagina.Bairro = row["bairro"].ToString();
                pagina.Telefone = row["telefone"].ToString();
                pagina.Email = row["email"].ToString();
            }
                return pagina;
        }

        public void Save()
        {
            new Database.Pagina().Salvar(this.Id, this.Data, this.Nome, this.Fantasia, this.Cnpj, this.DataA, this.Cep, this.Rua, this.Numero, this.Bairro, this.Telefone, this.Email);
        }

        public static void Excluir(int id)
        {
            new Database.Pagina().Excluir(id);
        }

    }
}


