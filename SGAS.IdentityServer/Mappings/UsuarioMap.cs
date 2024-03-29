using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGAS.IdSvr.Entidade;

namespace SGAS.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.Property(x => x.Id).HasColumnName("USUA_ID");

            builder.HasKey(x => x.Id).HasName("PK_USUA");

            builder.Property(x => x.ConcurrencyStamp).HasColumnName("USUA_CONCURRENCY_TEMP");

            builder.Property(x => x.AccessFailedCount).HasColumnName("USUA_ACCESS_FAILED_COUNT");

            builder.Property(x => x.DataAlteracao).HasColumnName("USUA_DATA_ALTERACAO");

            builder.Property(x => x.DataCriacao).HasColumnName("USUA_DATA_CRIACAO");

            builder.Property(x => x.DataNascimento).HasColumnName("USUA_DATA_NASCIMENTO");

            builder.Property(x => x.Email).HasColumnName("USUA_EMAIL");

            builder.Property(x => x.EmailConfirmed).HasColumnName("USUA_EMAIL_CONFIRMED");

            builder.Property(x => x.Genero).HasColumnName("USUA_GENERO");

            builder.Property(x => x.LockoutEnabled).HasColumnName("USUA_LOCKOUT_ENABLED");

            builder.Property(x => x.LockoutEnd).HasColumnName("USUA_LOCKOUT_END");

            builder.Property(x => x.Nome).HasColumnName("USUA_NOME");

            builder.Property(x => x.NormalizedEmail).HasColumnName("USUA_NORMALIZED_EMAIL");

            builder.Property(x => x.NormalizedUserName).HasColumnName("USUA_NORMALIZED_NAME");

            builder.Property(x => x.PasswordHash).HasColumnName("USUA_PASSWORD_HASH");

            builder.Property(x => x.PhoneNumber).HasColumnName("USUA_PHONUMBER");

            builder.Property(x => x.PhoneNumberConfirmed).HasColumnName("USUA_PHONENUMBER_CONFIRMED");

            builder.Property(x => x.SecurityStamp).HasColumnName("USUA_SECURITY_TEMP");

            builder.Property(x => x.TwoFactorEnabled).HasColumnName("USUA_TWOFACTOR_ENABELD");

            builder.Property(x => x.UserName).HasColumnName("USUA_USERNAME");

            //builder.HasOne(x => x.Pessoa)
            //    .WithOne(f => f.Usuario);

            //builder.HasOne(x => x.Pessoa)
            //        .WithOne(p => p.Usuario)
            //        .HasForeignKey<Pessoa>(f => f.IdUsuario);

            builder.HasMany(x => x.FuncoesUsuarios)
                    .WithOne(r => r.User)
                    .HasForeignKey(x => x.UserId);


            //.HasConstraintName("FK_USUARIO");

            //builder.HasOne(x => x.Pessoa)
            //    .WithOne(x => x.Usuario)
            //    .HasForeignKey<Pessoa>(x => x.IdUsuario);

            builder.Ignore(x => x.Password);
            builder.Ignore(x => x.FuncoesUsuarios);
  
        }
    }
}
