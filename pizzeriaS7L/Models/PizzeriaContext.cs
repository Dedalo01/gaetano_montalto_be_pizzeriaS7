using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace pizzeriaS7L.Models
{
    public partial class PizzeriaContext : DbContext
    {
        public PizzeriaContext()
            : base("name=PizzeriaContext")
        {
        }

        public virtual DbSet<Articoli> Articoli { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<OrdiniArticoli> OrdiniArticoli { get; set; }
        public virtual DbSet<Ruoli> Ruoli { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articoli>()
                .Property(e => e.Prezzo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Articoli>()
                .Property(e => e.TempoConsegna)
                .IsFixedLength();

            modelBuilder.Entity<Articoli>()
                .Property(e => e.Ingredienti)
                .IsFixedLength();

            modelBuilder.Entity<Articoli>()
                .HasMany(e => e.OrdiniArticoli)
                .WithRequired(e => e.Articoli)
                .HasForeignKey(e => e.ArticoloId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordini>()
                .Property(e => e.IsCompleto)
                .IsFixedLength();

            modelBuilder.Entity<Ordini>()
                .HasMany(e => e.OrdiniArticoli)
                .WithRequired(e => e.Ordini)
                .HasForeignKey(e => e.OrdineId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ruoli>()
                .HasMany(e => e.Utenti)
                .WithRequired(e => e.Ruoli)
                .HasForeignKey(e => e.RuoloId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Utenti)
                .HasForeignKey(e => e.UtenteId)
                .WillCascadeOnDelete(false);
        }
    }
}
