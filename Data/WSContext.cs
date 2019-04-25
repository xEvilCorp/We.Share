using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WeShare.Web.Data
{
    public partial class WSContext : DbContext
    {
        public WSContext()
        {
        }

        public WSContext(DbContextOptions<WSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcessoCanalUser> AcessoCanalUser { get; set; }
        public virtual DbSet<Anuncio> Anuncio { get; set; }
        public virtual DbSet<Bairros> Bairros { get; set; }
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Canal> Canal { get; set; }
        public virtual DbSet<CanalUser> CanalUser { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cidades> Cidades { get; set; }
        public virtual DbSet<Comunidade> Comunidade { get; set; }
        public virtual DbSet<ComunidadeVideo> ComunidadeVideo { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<InscritosCanal> InscritosCanal { get; set; }
        public virtual DbSet<InscritosComunidade> InscritosComunidade { get; set; }
        public virtual DbSet<Logradouros> Logradouros { get; set; }
        public virtual DbSet<NextId> NextId { get; set; }
        public virtual DbSet<Pagamento> Pagamento { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<TipoLogradouro> TipoLogradouro { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserRoleClaim> UserRoleClaim { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<VideoComments> VideoComments { get; set; }
        public virtual DbSet<VideoRatings> VideoRatings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=WS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcessoCanalUser>(entity =>
            {
                entity.ToTable("Acesso_Canal_User");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bairros>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CidadeNavigation)
                    .WithMany(p => p.Bairros)
                    .HasForeignKey(d => d.Cidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bairros_Cidades");
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.Property(e => e.Nome)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Canal>(entity =>
            {
                entity.Property(e => e.Banner)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Noime)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CanalUser>(entity =>
            {
                entity.ToTable("Canal_User");

                entity.Property(e => e.User).HasMaxLength(450);

                entity.HasOne(d => d.AcessoNavigation)
                    .WithMany(p => p.CanalUser)
                    .HasForeignKey(d => d.Acesso)
                    .HasConstraintName("FK_Canal_User_Acesso_Canal_User");

                entity.HasOne(d => d.CanalNavigation)
                    .WithMany(p => p.CanalUser)
                    .HasForeignKey(d => d.Canal)
                    .HasConstraintName("FK_Canal_User_Canal");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.CanalUser)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("FK_Canal_User_User");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.Property(e => e.Acesso)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnType("money");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icone)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cidades>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidades_Estados");
            });

            modelBuilder.Entity<Comunidade>(entity =>
            {
                entity.Property(e => e.Banner)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComunidadeVideo>(entity =>
            {
                entity.ToTable("Comunidade_Video");

                entity.Property(e => e.PostDate).HasColumnType("date");

                entity.Property(e => e.Usuario).HasMaxLength(450);

                entity.HasOne(d => d.ComunidadeNavigation)
                    .WithMany(p => p.ComunidadeVideo)
                    .HasForeignKey(d => d.Comunidade)
                    .HasConstraintName("FK_Comunidade_Video_Comunidade");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.ComunidadeVideo)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK_Comunidade_Video_User");

                entity.HasOne(d => d.VideoNavigation)
                    .WithMany(p => p.ComunidadeVideo)
                    .HasForeignKey(d => d.Video)
                    .HasConstraintName("FK_Comunidade_Video_Video");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.CepNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.Cep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Logradouros");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.Property(e => e.Celular)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastro).HasColumnType("date");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CargoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.Cargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionarios_Cargo");

                entity.HasOne(d => d.EnderecoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.Endereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionarios_Endereco");

            

                entity.HasOne(d => d.PagamentoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.Pagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionarios_Pagamento");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InscritosCanal>(entity =>
            {
                entity.Property(e => e.User).HasMaxLength(450);

                entity.HasOne(d => d.CanalNavigation)
                    .WithMany(p => p.InscritosCanal)
                    .HasForeignKey(d => d.Canal)
                    .HasConstraintName("FK_InscritosCanal_Canal");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.InscritosCanal)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("FK_InscritosCanal_User");
            });

            modelBuilder.Entity<InscritosComunidade>(entity =>
            {
                entity.Property(e => e.Since).HasColumnType("date");

                entity.Property(e => e.User).HasMaxLength(450);

                entity.HasOne(d => d.ComunidadeNavigation)
                    .WithMany(p => p.InscritosComunidade)
                    .HasForeignKey(d => d.Comunidade)
                    .HasConstraintName("FK_InscritosComunidade_Comunidade");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.InscritosComunidade)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("FK_InscritosComunidade_User");
            });

            modelBuilder.Entity<Logradouros>(entity =>
            {
                entity.HasKey(e => e.Cep);

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BairroNavigation)
                    .WithMany(p => p.Logradouros)
                    .HasForeignKey(d => d.Bairro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Logradouros_Bairros");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.Logradouros)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Logradouros_TipoLogradouro");
            });

            modelBuilder.Entity<NextId>(entity =>
            {
                entity.Property(e => e.NextId1).HasColumnName("NextId");

                entity.Property(e => e.Tabela)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.Property(e => e.Agencia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Conta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.BancoNavigation)
                    .WithMany(p => p.Pagamento)
                    .HasForeignKey(d => d.Banco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagamento_Banco");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<TipoLogradouro>(entity =>
            {
                entity.Property(e => e.Nome)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaim)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoleClaim)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserToken)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostDate).HasColumnType("date");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario).HasMaxLength(450);

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Video)
                    .HasForeignKey(d => d.Categoria)
                    .HasConstraintName("FK_Video_Categoria");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Video)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK_Video_User");
            });

            modelBuilder.Entity<VideoComments>(entity =>
            {
                entity.Property(e => e.Comentario)
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.PostDate).HasColumnType("date");

                entity.Property(e => e.Usuario).HasMaxLength(450);

                entity.HasOne(d => d.RelatedToNavigation)
                    .WithMany(p => p.InverseRelatedToNavigation)
                    .HasForeignKey(d => d.RelatedTo)
                    .HasConstraintName("FK_VideoComments_VideoComments");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.VideoComments)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK_VideoComments_User");

                entity.HasOne(d => d.VideoNavigation)
                    .WithMany(p => p.VideoComments)
                    .HasForeignKey(d => d.Video)
                    .HasConstraintName("FK_VideoComments_Video");
            });

            modelBuilder.Entity<VideoRatings>(entity =>
            {
                entity.Property(e => e.User).HasMaxLength(450);

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.VideoRatings)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("FK_VideoRatings_User");

                entity.HasOne(d => d.VideoNavigation)
                    .WithMany(p => p.VideoRatings)
                    .HasForeignKey(d => d.Video)
                    .HasConstraintName("FK_VideoRatings_Video");
            });
        }
    }
}
