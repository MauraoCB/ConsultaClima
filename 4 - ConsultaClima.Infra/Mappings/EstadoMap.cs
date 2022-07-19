using ConsultaClima.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultaClima.Infra.Mappings{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("INT");

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR(200)");

            builder.Property(x => x.UF)
       .HasMaxLength(2)
       .HasColumnName("UF")
       .HasColumnType("NVARCHAR(2)");


        }
    }
}