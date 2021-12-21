using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Repositorio.Configuracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class RepositorioGenerico<T> : IGenerica<T>, IDisposable where T : class
    {

        private readonly DbContextOptions<Contexto> _opcoesBuilder;

        public RepositorioGenerico()
        {
            _opcoesBuilder = new DbContextOptions<Contexto>();
        }

        public async Task Adicionar(T Objeto)
        {
            using (var data = new Contexto(_opcoesBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T Objeto)
        {
            using (var data = new Contexto(_opcoesBuilder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> BuscaPorCodigo(int Id)
        {
            using (var data = new Contexto(_opcoesBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task Excluir(T Objeto)
        {
            using (var data = new Contexto(_opcoesBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> ListarTudo()
        {
            using (var data = new Contexto(_opcoesBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }


        public async Task<List<T>> ListarComExpression(Expression<Func<T, bool>> expression)
        {
            using (var banco = new Contexto(_opcoesBuilder))
            {
                return await banco.Set<T>().Where(expression).AsNoTracking().ToListAsync();
            }
        }


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion


    }
}
