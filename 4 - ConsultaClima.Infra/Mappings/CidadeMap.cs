using ConsultaClima.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaClima.Infra.Mappings
{
   public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("INT");

            builder.Property(x => x.EstadoId)
                 .HasColumnName("EstadoId")
                 .HasColumnType("INT");

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR(200)");
        }         
    }
}
