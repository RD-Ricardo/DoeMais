using DM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.Infrastructure.Data.CommandDb.EntitiesConfigutations
{
    public class DoacaoConfiguration : IEntityTypeConfiguration<Doacao>
    {
        public void Configure(EntityTypeBuilder<Doacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(d => d.DataDoacao)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(d => d.QuantidadeML)
              .IsRequired();

            builder.Property(d => d.DoadorId)
                .IsRequired();
        }
    }
}
