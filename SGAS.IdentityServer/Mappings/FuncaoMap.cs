using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGAS.IdSvr.Entidade;

namespace SGAS.Infra.Mappings
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.ToTable("FUNCAO");

            builder.Property(x => x.Id).HasColumnName("FUNC_ID");

            builder.HasKey(x => x.Id).HasName("PK_FUNC");

            builder.Property(x => x.ConcurrencyStamp).HasColumnName("FUNC_CONCURRENCY_TEMP");

            builder.Property(x => x.Name).HasColumnName("FUNC_NOME");

            builder.Property(x => x.NormalizedName).HasColumnName("FUNC_NORMALIZED_NAME");

            //builder.HasMany(x => x.FuncoesUsuarios)
            //        .WithOne(r => r.Role);
            //        .HasConstraintName("FK_FUNCAO"); 

            builder.HasMany(x => x.FuncoesUsuarios)
                   .WithOne(r => r.Role)
                   .HasForeignKey(x => x.RoleId);

            builder.Ignore(x => x.FuncoesUsuarios);


        }
    }
}
