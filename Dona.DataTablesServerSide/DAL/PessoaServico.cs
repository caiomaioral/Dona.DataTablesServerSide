using Dona.DataTablesServerSide.Models;
using Dona.DataTablesServerSide.ViewModel.DataTables;
using Dona.DataTablesServerSide.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
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
            //apenas pegando a referência aos dados que vamos lidar (não executa query nenhuma ainda)
            IQueryable<Pessoa> Pessoas = _db.Pessoas.AsQueryable();

            //se houver um filtro, vamos aplicá-lo (MAS AINDA SEM EXECUTAR A CONSULTA NO BANCO!)
            if(!string.IsNullOrWhiteSpace(Params.sSearch))
            {
                string search = Params.sSearch;

                bool isDate = false;
                DateTime dateValue = DateTime.Now;

                bool isDecimal = false;
                decimal decimalValue = 0;

                //é uma data?
                isDate = DateTime.TryParse(search, out dateValue);

                //é valor decimal?
                isDecimal = decimal.TryParse(search, out decimalValue);

                //aplique o filtro em todas as colunas visíveis da tabela
                //eu optei por filtrar as colunas decimais e de data apenas quando o usuário inserir um valor compatível
                Pessoas = Pessoas.Where(x =>
                    x.Nome.Contains(search)
                    ||
                    x.Emprego.Nome.Contains(search)
                    ||
                    (isDate && x.DtAniversario.Equals(dateValue))
                    ||
                    (isDecimal && x.Emprego.Salario.Equals(decimalValue))
                );
            }

            //fazemos um acesso ao banco para dizer quantas pessoas existem no DB
            TotalPessoas = _db.Pessoas.Count();

            //mais um acesso para dizer quantas pessoas existem com os filtros aplicados
            TotalPessoasFiltradas = Pessoas.Count();

            //fazendo a ordenação pelo que foi informado na interface
            string ColunaOrdenada = Params.sColumns.Split(',')[Params.iSortCol_0];
            Pessoas = Pessoas.OrderBy(ColunaOrdenada + " " + Params.sSortDir_0);

            //pegando apenas os resultados relativos a página atual
            Pessoas = Pessoas.Skip(Params.iDisplayStart).Take(Params.iDisplayLength);

            //fazendo a query e retornando a viewmodel...
            return Pessoas.Select(x => new ListarPessoaViewModel() 
            { 
                Id = x.Id,
                Nome = x.Nome,
                DtAniversario = x.DtAniversario,
                EmpregoId = x.EmpregoId,
                EmpregoNome = x.Emprego.Nome,
                EmpregoSalario = x.Emprego.Salario,
            }).ToList();
        }
    }
}