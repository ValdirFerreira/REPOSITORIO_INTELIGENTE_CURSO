using Dominio.Endidades;
using Dominio.InserfaceServico;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiDevNetCore.Controllers
{

    [Route("api/[controller]")]
    public class ApiProduto : Controller
    {

        private readonly IProduto _IProduto;
        private readonly IProdutoServico _IProdutoServico;        

        public ApiProduto(IProduto IProduto, IProdutoServico IProdutoServico )
        {
            _IProduto = IProduto;
            _IProdutoServico = IProdutoServico;
        }

        [HttpPost("/api/AdicionarComValidacao")]
        public async Task<List<Notifica>> AdicionaNoticia(Produto produto)
        {
            await _IProdutoServico.AdicionarComValidacao(produto);

            return produto.Notificacoes;
        }

        [HttpPost("/api/Atualizar")]
        public async Task<List<Notifica>> Atualizar(Produto produto)
        {
            await _IProduto.Atualizar(produto);

            return produto.Notificacoes;
        }

        [HttpPost("/api/Excluir")]
        public async Task<List<Notifica>> Excluir(Produto produto)
        {
            await _IProduto.Excluir(produto);

            return produto.Notificacoes;
        }

        [HttpPost("/api/BuscaPorCodigo")]
        public async Task<Produto> BuscaPorCodigo(int codigo)
        {
            return await _IProduto.BuscaPorCodigo(codigo);
        }

        [HttpPost("/api/ListarProdutosPorNome")]
        public async Task<List<Produto>> ListarProdutosPorNome(string nome)
        {
            return await _IProdutoServico.ListarProdutosPorNome(nome);
        }

        [HttpPost("/api/ListarTudo")]
        public async Task<List<Produto>> ListarTudo()
        {
            return await _IProduto.ListarTudo();
        }


    }
}
