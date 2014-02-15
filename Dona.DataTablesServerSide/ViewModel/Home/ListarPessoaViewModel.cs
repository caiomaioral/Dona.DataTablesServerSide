using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dona.DataTablesServerSide.ViewModel.Home
{
    public class ListarPessoaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtAniversario { get; set; }
        public int EmpregoId { get; set; }
        public string EmpregoNome { get; set; }
        public decimal EmpregoSalario { get; set; }

    }
}