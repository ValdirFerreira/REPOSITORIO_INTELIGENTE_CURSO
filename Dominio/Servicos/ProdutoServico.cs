using Dominio.Endidades;
using Dominio.InserfaceServico;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ProdutoServico : IProdutoServico
    {

        private readonly IProduto _IProduto;
        public ProdutoServico(IProduto IProduto)
        {
            _IProduto = IProduto;
        }

        public async Task AdicionarComValidacao(Produto produto)
        {
            if (produto.ValidapropriedadeString(produto.Nome, "Nome"))
            {
                await _IProduto.Adicionar(produto);
            }
        }

        public async Task<List<Produto>> ListarProdutosComExpression(Expression<Func<Produto, bool>> exProduto)
        {
           return await  _IProduto.ListarComExpression(exProduto);
        }

        public async Task<List<Produto>> ListarProdutosPorNome(string nome)
        {
            return await ListarProdutosComExpression(p => p.Nome.Contains(nome));
        }


    }
}
