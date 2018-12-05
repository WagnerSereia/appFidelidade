using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppFidelidade.Data.Models
{
    public partial class DatabaseFidelidadeContext : DbContext
    {
        public DatabaseFidelidadeContext()
        {
        }

        public DatabaseFidelidadeContext(DbContextOptions<DatabaseFidelidadeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConfiguracaoUsuario> ConfiguracaoUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=fidelidade13net.database.windows.net;Database=DatabaseFidelidade;Trusted_Connection=False;user id=UsrFide13Net;password=PwdFide13Net;MultipleActiveResultSets=True;");
                optionsBuilder.UseSqlServer("Server=.;Database=DatabaseFidelidade;Trusted_Connection=False;user id=UsrFide13Net;password=PwdFide13Net;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfiguracaoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
