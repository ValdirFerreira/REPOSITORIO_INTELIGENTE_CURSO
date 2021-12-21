using Dominio.Endidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositorio.Configuracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class RepositorioProduto : RepositorioGenerico<Produto>, IProduto
    {

        //private readonly DbContextOptions<Contexto> _opcoesBulder;

        //public RepositorioProduto()
        //{
        //    _opcoesBulder = new DbContextOptions<Contexto>();
        //}

    }
}
