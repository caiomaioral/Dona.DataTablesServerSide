using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dona.DataTablesServerSide.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtAniversario { get; set; }
        public Emprego Emprego { get; set; }
        public int EmpregoId { get; set; }
    }
}