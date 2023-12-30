using DM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.Infrastructure.Data.CommandDb.EntitiesConfigutations
{
    public class DoadorConfiguration : IEntityTypeConfiguration<Doador>
    {
        public void Configure(EntityTypeBuilder<Doador> builder)
        {
            builder.Property(d => d.Id);

            builder.Property(d => d.Peso)
                .IsRequired();

            builder.Property(d => d.NomeCompleto)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(d => d.Email)
               .IsRequired()
               .HasMaxLength(150);

            builder.Property(d => d.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder.OwnsOne(d => d.Endereco, p =>
            {
                p.Property(x => x.Cep)
                    .HasColumnName("Cep")
                    .HasMaxLength(8);
                p.Property(x => x.Cidade)
                    .HasColumnName("Cidade")
                    .HasMaxLength(50);
                p.Property(x => x.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasMaxLength(100); 
                p.Property(x => x.Estado)
                    .HasColumnName("Estado")
                    .HasMaxLength(2);
            });

            builder.HasIndex(d => d.Email);
        }
    }
}
