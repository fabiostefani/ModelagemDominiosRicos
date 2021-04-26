using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Entidades
{
    public class Categoria : Entity
    {
        const string ValidacaoNome = "O campo Nome da Categoria não pode estar vazio";
        const string ValidacaoCodigo = "O campo Código não pode ser 0 (zero)";
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, ValidacaoNome);
            Validacoes.ValidarSeIgual(Codigo, 0, ValidacaoCodigo);
        }
    }
}