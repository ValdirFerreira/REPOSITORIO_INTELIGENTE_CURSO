using Dominio.Endidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Configuracoes
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opcoesBuilder)
        {
            if (!opcoesBuilder.IsConfigured)
            {
                opcoesBuilder.UseSqlServer("Data Source=192.168.0.101,1433;Initial Catalog=REPOSITORIO_INTELIGENTE_TESTE;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            }
        }

    }
}
