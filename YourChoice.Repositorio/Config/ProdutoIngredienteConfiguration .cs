using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YourChoice.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourChoice.Repositorio.Config
{
    public class ProdutoIngredienteConfiguration : IEntityTypeConfiguration<ProdutoIngrediente>
    {
        public void Configure(EntityTypeBuilder<ProdutoIngrediente> builder)
        {
            builder.HasKey(x => new { x.ProdutoId, x.IngredienteId });
            builder.HasOne(bc => bc.Produto)
                   .WithMany(b => b.ProdutoIngrediente)
                   .HasForeignKey(bc => bc.ProdutoId);
            builder.HasOne(bc => bc.Ingrediente)
                   .WithMany(c => c.ProdutoIngrediente)
                   .HasForeignKey(bc => bc.IngredienteId);
        }
    }
}
