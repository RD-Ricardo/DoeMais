using DM.Domain.Entities;
using DM.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.Infrastructure.Data.CommandDb.EntitiesConfigutations
{
    public class EstoqueSangueConfiguration : IEntityTypeConfiguration<EstoqueSangue>
    {
        public void Configure(EntityTypeBuilder<EstoqueSangue> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.QuantidadeML)
                .IsRequired();

            builder.HasData(
                new EstoqueSangue(TipoSanguineo.O, FatorRh.Positivo, 0.00),
                new EstoqueSangue(TipoSanguineo.O, FatorRh.Negativo, 0.00),
                new EstoqueSangue(TipoSanguineo.A, FatorRh.Positivo, 0.00),
                new EstoqueSangue(TipoSanguineo.A, FatorRh.Negativo, 0.00),
                new EstoqueSangue(TipoSanguineo.B, FatorRh.Positivo, 0.00),
                new EstoqueSangue(TipoSanguineo.B, FatorRh.Negativo, 0.00),
                new EstoqueSangue(TipoSanguineo.AB, FatorRh.Positivo, 0.00),
                new EstoqueSangue(TipoSanguineo.AB, FatorRh.Negativo, 0.00));
        }
    }
}
