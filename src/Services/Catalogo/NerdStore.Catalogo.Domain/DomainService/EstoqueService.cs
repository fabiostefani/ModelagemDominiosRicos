using System;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain.Produtos;
using NerdStore.Catalogo.Domain.Produtos.Events;
using NerdStore.Core.Bus;

namespace NerdStore.Catalogo.Domain.DomainService
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;

        public EstoqueService(IProdutoRepository produtoRepository, 
                              IMediatrHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;

        }
        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);
            
            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            //TODO: Parametrizar a quantidade de estoque baixo
            if (produto.QuantidadeEstoque < 10)
            {
                //Fazer alguma coisa, enviar e-mail, abrir chamado ou realizar nova compra
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }
            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);
            if (produto == null) return false;

            produto.ReporEstoque(quantidade);
            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}