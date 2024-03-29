using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGAS.IdSvr.Entidade;

namespace SGAS.Infra.Mappings
{
    public class FuncaoUsuarioMap : IEntityTypeConfiguration<FuncaoUsuario>
    {
        public void Configure(EntityTypeBuilder<FuncaoUsuario> builder)
        {
            builder.ToTable("FUNCAO_USUARIO");

            builder.HasKey(x => new { x.RoleId, x.UserId });

            builder.Property(x => x.RoleId).HasColumnName("FNUS_ID_FUNCAO");

            builder.Property(x => x.UserId).HasColumnName("FNUS_ID_USUARIO");

           // builder.HasNoKey();

           // builder.HasKey(x => new { x.RoleId, x.UserId }).HasName("PK_FNUS");

            builder.Property(x => x.DataInicio).HasColumnName("FUNC_DT_INICIO");

            builder.Property(x => x.DataFim).HasColumnName("FUNC_DT_FIM");


            //builder.HasOne<Usuario>(x => x.User)
            //    .WithMany(f => f.FuncoesUsuarios)
            //    .HasPrincipalKey("FNUS_ID_USUARIO");

            //builder.HasOne(x => x.Role)
            //    .WithMany(f => f.FuncoesUsuarios)
            //    .HasForeignKey(x => x.RoleId);

            //builder.HasOne(x => x.User)
            //   .WithMany(f => f.FuncoesUsuarios)
            //   .HasForeignKey(x => x.User);


            builder.Ignore(x => x.Role);
            builder.Ignore(x => x.User);
        }
    }
}
