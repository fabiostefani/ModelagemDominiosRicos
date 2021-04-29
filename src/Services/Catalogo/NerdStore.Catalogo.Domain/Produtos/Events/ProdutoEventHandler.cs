using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NerdStore.Catalogo.Domain.Produtos;

namespace NerdStore.Catalogo.Domain.Produtos.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);
            //Enviar um e-mail para aquisição de mais produtos.
            //bla bla bla
        }
    }
}