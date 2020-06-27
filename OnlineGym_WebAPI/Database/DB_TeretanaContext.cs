using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineGym_WebAPI.Database
{
    public partial class DB_TeretanaContext : DbContext
    {
        public DB_TeretanaContext()
        {
        }

        public DB_TeretanaContext(DbContextOptions<DB_TeretanaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clan> Clan { get; set; }
        public virtual DbSet<ClanTeretana> ClanTeretana { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<KategorijaProizvoda> KategorijaProizvoda { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Narudzbe> Narudzbe { get; set; }
        public virtual DbSet<Izlazi> Izlazi { get; set; }
        public virtual DbSet<NarudzbeStavke> NarudzbeStavke { get; set; }
        public virtual DbSet<Obavijest> Obavijest { get; set; }
        public virtual DbSet<PlacanjeClanarine> PlacanjeClanarine { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<RecenzijeProizvoda> RecenzijeProizvoda { get; set; }
        public virtual DbSet<RecenzijeTeretane> RecenzijeTeretane { get; set; }
        public virtual DbSet<Teretana> Teretana { get; set; }
        public virtual DbSet<TipClanarine> TipClanarine { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<VrstaProizvoda> VrstaProizvoda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=.;initial catalog=160158;integrated security = True");
                //a.data source =.; initial catalog = brojIndeksa; integrated security = True;
                //optionsBuilder.UseSqlServer("Server=.;Database=160158;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clan>(entity =>
            {
                entity.Property(e => e.ClanId).HasColumnName("ClanID");
                entity.HasIndex(e => e.GradId);
            });

            modelBuilder.Entity<ClanTeretana>(entity =>
            {
                entity.HasIndex(e => e.ClanId);

                entity.HasIndex(e => e.TeretanaId);

                entity.Property(e => e.ClanTeretanaId).HasColumnName("ClanTeretanaID");

                entity.Property(e => e.ClanId).HasColumnName("ClanID");

                entity.Property(e => e.TeretanaId).HasColumnName("TeretanaID");

                entity.HasOne(d => d.Clan)
                    .WithMany(p => p.ClanTeretana)
                    .HasForeignKey(d => d.ClanId);

                entity.HasOne(d => d.Teretana)
                    .WithMany(p => p.ClanTeretana)
                    .HasForeignKey(d => d.TeretanaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.HasIndex(e => e.DrzavaId);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grad)
                    .HasForeignKey(d => d.DrzavaId);
            });

            modelBuilder.Entity<Izlazi>(entity =>
            {
                entity.HasKey(e => e.IzlazId);
                entity.Property(e => e.IznosSaPdv).HasColumnType("decimal(18, 0)");
    

                entity.Property(e => e.NarudzbaId).HasColumnName("NarudzbaId");
                entity.Property(e => e.Zakljucen).HasColumnName("Zakljucen");

                entity.Property(e => e.Datum).HasColumnType("datetime");
         
            });






            modelBuilder.Entity<KategorijaProizvoda>(entity =>
            {
                entity.Property(e => e.KategorijaProizvodaId).ValueGeneratedNever();

                entity.Property(e => e.Naziv).HasMaxLength(30);

                entity.Property(e => e.Opis).HasMaxLength(200);
            });

            modelBuilder.Entity<KorisniciUloge>(entity =>
            {
                entity.Property(e => e.KorisniciUlogeId).HasColumnName("KorisniciUlogeId");
      

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Korisnici__Koris__0880433F");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Korisnici__Uloga__09746778");
            });

    

            modelBuilder.Entity<Narudzbe>(entity =>
            {
                entity.HasKey(e => e.NarudzbaId);

                entity.Property(e => e.NarudzbaId).ValueGeneratedNever();

                entity.Property(e => e.BrojNarudzbe).HasMaxLength(20);

                entity.Property(e => e.ClanId).HasColumnName("ClanID");
                entity.Property(e => e.Procesirana).HasColumnName("Procesirana");


                entity.Property(e => e.Datum).HasColumnType("datetime");

        

                entity.HasOne(d => d.Clan)
                    .WithMany(p => p.Narudzbe)
                    .HasForeignKey(d => d.ClanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Narudzbe__ClanID__0C50D423");
            });

            modelBuilder.Entity<NarudzbeStavke>(entity =>
            {
               
                entity.Property(e => e.NarudzbeStavkeId).HasColumnName("NarudzbeStavkeId");
              

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.NarudzbeStavke)
                    .HasForeignKey(d => d.NarudzbaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NarudzbeS__Narud__13F1F5EB");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.NarudzbeStavke)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NarudzbeS__Proiz__1C873BEC");
            });

            modelBuilder.Entity<Obavijest>(entity =>
            {
                entity.Property(e => e.ObavijestId).HasColumnName("ObavijestID");
            });

            modelBuilder.Entity<PlacanjeClanarine>(entity =>
            {
                entity.HasIndex(e => e.ClanId);

           

                entity.HasIndex(e => e.TeretanaId);

                entity.HasIndex(e => e.TipClanarineId);

                entity.Property(e => e.PlacanjeClanarineId).HasColumnName("PlacanjeClanarineID");

                entity.Property(e => e.ClanId).HasColumnName("ClanID");

                

                entity.Property(e => e.TeretanaId).HasColumnName("TeretanaID");

                entity.Property(e => e.TipClanarineId).HasColumnName("TipClanarineID");

                entity.HasOne(d => d.Clan)
                    .WithMany(p => p.PlacanjeClanarine)
                    .HasForeignKey(d => d.ClanId);


                entity.HasOne(d => d.Teretana)
                    .WithMany(p => p.PlacanjeClanarine)
                    .HasForeignKey(d => d.TeretanaId);

                entity.HasOne(d => d.TipClanarine)
                    .WithMany(p => p.PlacanjeClanarine)
                    .HasForeignKey(d => d.TipClanarineId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.ProsjecnaOcjena).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Naziv).HasMaxLength(50);
                entity.Property(e => e.Opis).HasMaxLength(200);

                entity.Property(e => e.Sifra).HasMaxLength(30);
                entity.Property(e => e.VrstaProizvodaId).HasColumnName("VrstaProizvodaId");
     
                entity.HasOne(d => d.KategorijaProizvoda)
                    .WithMany(p => p.Proizvod)
                    .HasForeignKey(d => d.KategorijaProizvodaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proizvod__Katego__1B9317B3");
            });



            modelBuilder.Entity<RecenzijeProizvoda>(entity =>
            {
                entity.HasKey(e => e.RecenzijaProizvodaId);

                entity.Property(e => e.ClanId).HasColumnName("ClanID");

                entity.Property(e => e.Komentar).HasMaxLength(50);

                entity.HasOne(d => d.Clan)
                    .WithMany(p => p.RecenzijeProizvoda)
                    .HasForeignKey(d => d.ClanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recenzije__ClanI__17C286CF");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.RecenzijeProizvoda)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recenzije__Proiz__1D7B6025");
            });

            modelBuilder.Entity<RecenzijeTeretane>(entity =>
            {
                entity.HasKey(e => e.KomentarId);

                entity.HasIndex(e => e.ClanId)
                    .HasName("IX_KomentarTeretane_ClanID");

                entity.HasIndex(e => e.TeretanaId)
                    .HasName("IX_KomentarTeretane_TeretanaID");

                entity.Property(e => e.KomentarId).HasColumnName("KomentarID");

                entity.Property(e => e.ClanId).HasColumnName("ClanID");

                entity.Property(e => e.TeretanaId).HasColumnName("TeretanaID");

                entity.HasOne(d => d.Clan)
                    .WithMany(p => p.RecenzijeTeretane)
                    .HasForeignKey(d => d.ClanId)
                    .HasConstraintName("FK_KomentarTeretane_Clan_ClanID");

                entity.HasOne(d => d.Teretana)
                    .WithMany(p => p.RecenzijeTeretane)
                    .HasForeignKey(d => d.TeretanaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KomentarTeretane_Teretana_TeretanaID");
            });

            modelBuilder.Entity<Teretana>(entity =>
            {
                entity.HasIndex(e => e.GradId);
                entity.Property(e => e.ProsjecnaOCjena).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TeretanaId).HasColumnName("TeretanaID");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Teretana)
                    .HasForeignKey(d => d.GradId);
            });

            modelBuilder.Entity<TipClanarine>(entity =>
            {
                entity.Property(e => e.TipClanarineId).HasColumnName("TipClanarineID");
            });

   

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");
            });
            modelBuilder.Entity<VrstaProizvoda>(entity =>
            {
                entity.Property(e => e.VrstaProizvodaId).ValueGeneratedNever();

                entity.Property(e => e.Naziv).HasMaxLength(30);
            });
        }
    }
}
