using Dona.DataTablesServerSide.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Dona.DataTablesServerSide.DAL
{
    public class StubDB : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Emprego> Empregos { get; set; }

        public StubDB() : base("ConexaoPadrao")
        {
            Database.SetInitializer(new Inicializador());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Inicializador: DropCreateDatabaseIfModelChanges<StubDB>
    {
        protected override void Seed(StubDB context)
        {
            #region Preenchendo os dados... =(
            List<Emprego> Empregos = new List<Emprego>()
            {
                new Emprego{ Id = 1, Nome = "Desenvolvedor PHP Senior", Salario = 5000.25M},
                new Emprego{ Id = 2, Nome = "Desenvolvedor PHP Pleno", Salario = 3250M},
                new Emprego{ Id = 3, Nome = "Analista de Sistemas", Salario = 4450M},
                new Emprego{ Id = 4, Nome = "Desenvolvedor FrontEnd", Salario = 4000M},
                new Emprego{ Id = 5, Nome = "Técnico de Informática", Salario = 2250M},
                new Emprego{ Id = 6, Nome = "Analista de Testes", Salario = 3350M},
                new Emprego{ Id = 6, Nome = "DBA Oracle", Salario = 6000M},
                new Emprego{ Id = 7, Nome = "DBA SQL Server", Salario = 5500M}
            };

            List<Pessoa> Pessoas = new List<Pessoa>()
            {
                new Pessoa { Id = 1, Nome = "Arnaldo Antunes", Emprego = Empregos[0], DtAniversario = new DateTime(1989, 11, 12)},
                new Pessoa { Id = 2, Nome = "Rodrigo Oliveira", Emprego = Empregos[1], DtAniversario = new DateTime(1959, 1, 20)},
                new Pessoa { Id = 3, Nome = "Magno Alberto", Emprego = Empregos[2], DtAniversario = new DateTime(1978, 3, 22)},
                new Pessoa { Id = 4, Nome = "Ronaldo Fagundes", Emprego = Empregos[3], DtAniversario = new DateTime(1991, 11, 11)},
                new Pessoa { Id = 5, Nome = "Carlos Augusto", Emprego = Empregos[4], DtAniversario = new DateTime(1986, 4, 20)},
                new Pessoa { Id = 6, Nome = "Wagner Silva", Emprego = Empregos[5], DtAniversario = new DateTime(1974, 7, 13)},
                new Pessoa { Id = 7, Nome = "Solange Silva", Emprego = Empregos[6], DtAniversario = new DateTime(1992, 2, 22)},
                new Pessoa { Id = 8, Nome = "Carla Enes", Emprego = Empregos[1], DtAniversario = new DateTime(1991, 4, 4)},
                new Pessoa { Id = 9, Nome = "Takaro Natrave", Emprego = Empregos[1], DtAniversario = new DateTime(1950, 7, 8)},
                new Pessoa { Id = 10, Nome = "Shijima Ingi", Emprego = Empregos[2], DtAniversario = new DateTime(1900, 2, 18)},
                new Pessoa { Id = 11, Nome = "Albafica Jones", Emprego = Empregos[3], DtAniversario = new DateTime(1910, 12, 20)},
                new Pessoa { Id = 12, Nome = "Scarlet Red", Emprego = Empregos[3], DtAniversario = new DateTime(1993, 3, 20)},
                new Pessoa { Id = 13, Nome = "Sonny Son", Emprego = Empregos[4], DtAniversario = new DateTime(1986, 6, 22)},
                new Pessoa { Id = 14, Nome = "John Doe", Emprego = Empregos[2], DtAniversario = new DateTime(1990, 4, 16)},
                new Pessoa { Id = 15, Nome = "Silvio Santos", Emprego = Empregos[5], DtAniversario = new DateTime(1979, 7, 2)},
                new Pessoa { Id = 16, Nome = "Ratinho", Emprego = Empregos[2], DtAniversario = new DateTime(1980, 5, 5)},
                new Pessoa { Id = 17, Nome = "Cansei De Nomes", Emprego = Empregos[6], DtAniversario = new DateTime(1992, 9, 6)},
                new Pessoa { Id = 18, Nome = "Zelda Hyrule", Emprego = Empregos[4], DtAniversario = new DateTime(1978, 8, 2)},
                new Pessoa { Id = 19, Nome = "Annita Poderosa", Emprego = Empregos[3], DtAniversario = new DateTime(1963, 2, 25)},
                new Pessoa { Id = 20, Nome = "Link Hyrule", Emprego = Empregos[1], DtAniversario = new DateTime(1986, 8, 30)},
                new Pessoa { Id = 21, Nome = "Gannon Demon", Emprego = Empregos[6], DtAniversario = new DateTime(1973, 2, 26)},
                new Pessoa { Id = 22, Nome = "Jéssica Carvalho", Emprego = Empregos[2], DtAniversario = new DateTime(1988, 2, 15)},
                new Pessoa { Id = 23, Nome = "Minion Atrevido", Emprego = Empregos[5], DtAniversario = new DateTime(1978, 8, 19)},
                new Pessoa { Id = 24, Nome = "Jéssica Tarvos", Emprego = Empregos[1], DtAniversario = new DateTime(1990, 9, 11)}
            };
            #endregion

            context.Empregos.AddRange(Empregos);
            context.Pessoas.AddRange(Pessoas);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}