namespace Loteria.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LoteriaEntity : DbContext
    {
        public LoteriaEntity()
            : base("name=LoteriaEntity")
        {
        }

        public virtual DbSet<Acerto> Acerto { get; set; }
        public virtual DbSet<Aposta> Aposta { get; set; }
        public virtual DbSet<Apostador> Apostador { get; set; }
        public virtual DbSet<ItemAposta> ItemAposta { get; set; }
        public virtual DbSet<ItemSorteio> ItemSorteio { get; set; }
        public virtual DbSet<Sorteio> Sorteio { get; set; }
        public virtual DbSet<StatusSorteio> StatusSorteio { get; set; }
        public virtual DbSet<TipoAcerto> TipoAcerto { get; set; }
        public virtual DbSet<TipoSorteio> TipoSorteio { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aposta>()
                .HasMany(e => e.Acerto)
                .WithRequired(e => e.Aposta)
                .HasForeignKey(e => e.IdAposta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aposta>()
                .HasMany(e => e.ItemAposta)
                .WithRequired(e => e.Aposta)
                .HasForeignKey(e => e.IdAposta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apostador>()
                .HasMany(e => e.Aposta)
                .WithRequired(e => e.Apostador)
                .HasForeignKey(e => e.IdApostador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sorteio>()
                .HasMany(e => e.Acerto)
                .WithRequired(e => e.Sorteio)
                .HasForeignKey(e => e.IdSorteio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sorteio>()
                .HasMany(e => e.Aposta)
                .WithRequired(e => e.Sorteio)
                .HasForeignKey(e => e.IdSorteio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sorteio>()
                .HasMany(e => e.ItemSorteio)
                .WithRequired(e => e.Sorteio)
                .HasForeignKey(e => e.IdSorteio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusSorteio>()
                .HasMany(e => e.Sorteio)
                .WithRequired(e => e.StatusSorteio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoAcerto>()
                .HasMany(e => e.Aposta)
                .WithOptional(e => e.TipoAcerto)
                .HasForeignKey(e => e.IdTipoAcerto);

            modelBuilder.Entity<TipoSorteio>()
                .HasMany(e => e.Sorteio)
                .WithRequired(e => e.TipoSorteio)
                .HasForeignKey(e => e.IdTipo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoSorteio>()
                .HasMany(e => e.TipoAcerto)
                .WithRequired(e => e.TipoSorteio)
                .HasForeignKey(e => e.IdTipo)
                .WillCascadeOnDelete(false);
        }
    }
}
