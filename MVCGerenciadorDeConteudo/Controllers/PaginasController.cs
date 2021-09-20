using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Paginas = new Pagina().Lista();

            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public void Criar()
        {
            try { 
                DateTime data;
                DateTime.TryParse(Request["data"], out data);
                DateTime dataA;
                DateTime.TryParse(Request["dataA"], out dataA);

                var pagina = new Pagina();
                pagina.Data = data;
                pagina.Nome = Request["nome"];
                pagina.Fantasia = Request["fantasia"];
                pagina.Cnpj = Request["cnpj"];
                pagina.DataA = dataA;
                pagina.Cep = Request["cep"];
                pagina.Rua = Request["rua"];
                pagina.Numero = Request["numero"];
                pagina.Bairro = Request["bairro"];
                pagina.Telefone = Request["telefone"];
                pagina.Email = Request["email"];
                pagina.Save();

                TempData["Sucesso"] = "Cadastro incluido com sucesso";

            }
            catch
            {
                TempData["Erro"] = "Cadastro não pode ser incluido";
            }
            Response.Redirect("/paginas");

        }

    

        public void Excluir(int id)
        {
            Pagina.Excluir(id);           
            Response.Redirect("/paginas");
        }


        public ActionResult Editar(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }

        [HttpPost]
        public void Alterar(int id)
        {
            try
            {
                var pagina = Pagina.BuscaPorId(id);

                DateTime data;
                DateTime.TryParse(Request["data"], out data);
                DateTime dataA;
                DateTime.TryParse(Request["dataA"], out data);

                pagina.Data = data;
                pagina.Nome = Request["nome"];
                pagina.Fantasia = Request["fantasia"];
                pagina.Cnpj = Request["cnpj"];
                pagina.Cep = Request["cep"];
                pagina.Rua = Request["rua"];
                pagina.Numero = Request["numero"];
                pagina.Bairro = Request["bairro"];
                pagina.Telefone = Request["telefone"];
                pagina.Email = Request["email"];
                pagina.Save();

                TempData["Sucesso"] = "Cadastro alterado com sucesso";

            }
            catch
            {
                TempData["Erro"] = "Cadastro não pode ser alterado";
            }
            Response.Redirect("/paginas");

        }
    }
}