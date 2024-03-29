using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGAS.IdentityServer.Entidades;
using SGAS.IdSvr.Entidade;

namespace SGAS.IdentityServer.Mappings
{
    public class ConfigMap : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable("CONFIG");

            builder.HasKey(x => x.ConfigId);

            builder.Property(x => x.ConfigId).HasColumnName("CONFIG_ID");

            builder.Property(x => x.Projeto).HasColumnName("PROJETO");

            builder.Property(x => x.Chave).HasColumnName("CHAVE");

            builder.Property(x => x.Valor).HasColumnName("VALOR");
        }
    }
}
