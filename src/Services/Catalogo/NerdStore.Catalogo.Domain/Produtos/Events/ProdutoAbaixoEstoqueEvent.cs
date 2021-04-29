using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Produtos.Events
{
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {

        public int QuantidadeRestante { get; private set; }
        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
        
    }
}