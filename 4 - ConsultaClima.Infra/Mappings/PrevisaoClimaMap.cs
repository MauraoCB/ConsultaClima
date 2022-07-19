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
    public class PrevisaoClimaMap : IEntityTypeConfiguration<PrevisaoClima>
    {
        public void Configure(EntityTypeBuilder<PrevisaoClima> builder)
        {
            builder.ToTable("PrevisaoClima");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("INT");

            builder.Property(x => x.CidadeId)
                 .HasColumnType("INT");

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR(200)");
        }
    }
}
