using ConsultaClima.Domain.Entities;
using ConsultaClima.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ConsultaClima.Infra.Context{
    public class ConsultaClimaContext : DbContext{
        public ConsultaClimaContext()
        {}

        public ConsultaClimaContext(DbContextOptions<ConsultaClimaContext> options) : base(options)
        {}

        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<PrevisaoClima> PrevisaoClima { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EstadoMap());
            builder.ApplyConfiguration(new CidadeMap());
            builder.ApplyConfiguration(new PrevisaoClimaMap());

            builder.Entity<Estado>()
           .HasMany(e => e.Cidades)
           .WithOne(c => c.Estado)
            .HasForeignKey(c => c.EstadoId);

            builder.Entity<Cidade>()
            .HasMany(c => c.PrevisaoClima)
            .WithOne(p => p.Cidade)
            .HasForeignKey(p=> p.CidadeId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer();
    }
}