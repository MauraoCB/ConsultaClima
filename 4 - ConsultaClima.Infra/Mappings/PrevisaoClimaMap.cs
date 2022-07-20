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
                .HasColumnName("CidadeId")
                 .HasColumnType("INT");

            builder.Property(x => x.DataPrevisao)
                .HasColumnName("DataPrevisao")
                .HasColumnType("DATE");

            builder.Property(x => x.Clima)
               .HasMaxLength(15)
               .HasColumnName("Clima")
               .HasColumnType("NVARCHAR(15)");

            builder.Property(x => x.TemperaturaMinima)
               .HasColumnName("TemperaturaMinima")
                .HasColumnType("NUMERIC(3,1)");

            builder.Property(x => x.TemperaturaMaxima)
           .HasColumnName("TemperaturaMaxima")
            .HasColumnType("NUMERIC(3,1)");
        }
    }
}
