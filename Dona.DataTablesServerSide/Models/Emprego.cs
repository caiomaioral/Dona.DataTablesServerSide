using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dona.DataTablesServerSide.Models
{
    public class Emprego
    {
        public Emprego()
        {
            Pessoas = new List<Pessoa>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}