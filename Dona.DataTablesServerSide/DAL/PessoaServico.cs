using Dona.DataTablesServerSide.ViewModel.DataTables;
using Dona.DataTablesServerSide.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dona.DataTablesServerSide.DAL
{
    public class PessoaServico
    {
        private StubDB _db = null;

        public PessoaServico()
        {
            _db = new StubDB();
        }

        public List<ListarPessoaViewModel> PegarPessoas(JQueryDataTablesParamViewModel Params, out int TotalPessoas, out int TotalPessoasFiltradas)
        {
            List<ListarPessoaViewModel> Pessoas = new List<ListarPessoaViewModel>();

            TotalPessoas = _db.Pessoas.Count();
            TotalPessoasFiltradas = Pessoas.Count();

            return Pessoas;
        }
    }
}