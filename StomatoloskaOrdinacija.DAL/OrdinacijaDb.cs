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
            modelBuilder.Entity<Pacijent>()
                .HasMany(e => e.Narudzba)
                .WithRequired(e => e.Pacijent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pacijent>()
                .HasMany(e => e.Zahvat)
                .WithRequired(e => e.Pacijent)
                .WillCascadeOnDelete(false);
        }
    }
}
