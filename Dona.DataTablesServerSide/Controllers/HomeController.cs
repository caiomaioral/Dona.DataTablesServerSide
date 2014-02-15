using Dona.DataTablesServerSide.DAL;
using Dona.DataTablesServerSide.ViewModel.DataTables;
using Dona.DataTablesServerSide.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dona.DataTablesServerSide.Controllers
{
    public class HomeController : Controller
    {
        private PessoaServico _servico = null;

        public HomeController()
        {
            _servico = new PessoaServico();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BuscaAssincrona(JQueryDataTablesParamViewModel Params)
        {
            int TotalPessoas = 0;
            int TotalPessoasFiltradas = 0;

            List<ListarPessoaViewModel> Pessoas = _servico.PegarPessoas(Params, out TotalPessoas, out TotalPessoasFiltradas);

            var Resultado = new
            {
                sEcho = Params.sEcho,
                iTotalRecords = TotalPessoas,
                iTotalDisplayRecords = TotalPessoasFiltradas,
                aaData = Pessoas
            };

            return Json(Resultado, JsonRequestBehavior.AllowGet);
        }
    }
}