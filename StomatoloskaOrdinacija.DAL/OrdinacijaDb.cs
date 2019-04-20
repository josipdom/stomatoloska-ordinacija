namespace StomatoloskaOrdinacija.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OrdinacijaDb : DbContext
    {
        public OrdinacijaDb()
            : base("name=OrdinacijaDb")
        {
        }

        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<Pacijent> Pacijent { get; set; }
        public virtual DbSet<Zahvat> Zahvat { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Narudzba>()
                .Property(e => e.NazivNarudzbe)
                .IsUnicode(false);

            modelBuilder.Entity<Narudzba>()
                .Property(e => e.OpisNarudzbe)
                .IsUnicode(false);

            modelBuilder.Entity<Narudzba>()
                .Property(e => e.NazivPacijenta)
                .IsUnicode(false);

            modelBuilder.Entity<Pacijent>()
                .Property(e => e.ImePacijenta)
                .IsUnicode(false);

            modelBuilder.Entity<Pacijent>()
                .Property(e => e.PrezimePacijenta)
                .IsUnicode(false);

            modelBuilder.Entity<Pacijent>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<Pacijent>()
                .Property(e => e.Adresa)
                .IsUnicode(false);

            modelBuilder.Entity<Pacijent>()
                .HasMany(e => e.Zahvat)
                .WithRequired(e => e.Pacijent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zahvat>()
                .Property(e => e.Naziv)
                .IsUnicode(false);
        }
    }
}
