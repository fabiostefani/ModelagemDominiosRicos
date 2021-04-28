using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain.Categorias;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)")
                .HasMaxLength(250);

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);

            builder.ToTable("Categorias");

        }
    }
}