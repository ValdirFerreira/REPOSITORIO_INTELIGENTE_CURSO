using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IGenerica<T> where T : class
    {
        Task Adicionar(T Objeto);
        Task Atualizar(T Objeto);
        Task Excluir(T Objeto);
        Task<T> BuscaPorCodigo(int Id);
        Task<List<T>> ListarTudo();
        Task<List<T>> ListarComExpression(Expression<Func<T, bool>> expression);

    }
}
