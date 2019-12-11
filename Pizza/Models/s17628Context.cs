using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizza.Models
{
    public partial class s17628Context : DbContext
    {
        public s17628Context()
        {
        }

        public s17628Context(DbContextOptions<s17628Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dodatek> Dodatek { get; set; }
        public virtual DbSet<DodatekZamowienie> DodatekZamowienie { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<PizzaZamowienie> PizzaZamowienie { get; set; }
        public virtual DbSet<RozmiarPizzy> RozmiarPizzy { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<UzytkownikZamowienie> UzytkownikZamowienie { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17628;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Dodatek>(entity =>
            {
                entity.HasKey(e => e.IdDodatek)
                    .HasName("Dodatek_pk");

                entity.Property(e => e.IdDodatek).ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("money");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DodatekZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.DodatekIdDodatek, e.ZamowienieIdZamowienie })
                    .HasName("Dodatek_Zamowienie_pk");

                entity.ToTable("Dodatek_Zamowienie");

                entity.Property(e => e.DodatekIdDodatek).HasColumnName("Dodatek_IdDodatek");

                entity.Property(e => e.ZamowienieIdZamowienie).HasColumnName("Zamowienie_IdZamowienie");

                entity.HasOne(d => d.DodatekIdDodatekNavigation)
                    .WithMany(p => p.DodatekZamowienie)
                    .HasForeignKey(d => d.DodatekIdDodatek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatek_Zamowienie_Dodatek");

                entity.HasOne(d => d.ZamowienieIdZamowienieNavigation)
                    .WithMany(p => p.DodatekZamowienie)
                    .HasForeignKey(d => d.ZamowienieIdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatek_Zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("PK__EMP__14CCF2EE2FF549E9");

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.SkladnikIdSkladnik })
                    .HasName("Pizza_Skladnik_pk");

                entity.ToTable("Pizza_Skladnik");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_IdPizza");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_IdSkladnik");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Skladnik_Pizza");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Skladnik_Skladniki");
            });

            modelBuilder.Entity<PizzaZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.RozmiarPizzyIdRozmiaru, e.ZamowienieIdZamowienie })
                    .HasName("Pizza_Zamowienie_pk");

                entity.ToTable("Pizza_Zamowienie");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_IdPizza");

                entity.Property(e => e.RozmiarPizzyIdRozmiaru).HasColumnName("Rozmiar_Pizzy_IdRozmiaru");

                entity.Property(e => e.ZamowienieIdZamowienie).HasColumnName("Zamowienie_IdZamowienie");

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("money");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaZamowienie)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Zamowienie_Pizza");

                entity.HasOne(d => d.RozmiarPizzyIdRozmiaruNavigation)
                    .WithMany(p => p.PizzaZamowienie)
                    .HasForeignKey(d => d.RozmiarPizzyIdRozmiaru)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Zamowienie_Rozmiar_Pizzy");

                entity.HasOne(d => d.ZamowienieIdZamowienieNavigation)
                    .WithMany(p => p.PizzaZamowienie)
                    .HasForeignKey(d => d.ZamowienieIdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Zamowienie_Zamowienie");
            });

            modelBuilder.Entity<RozmiarPizzy>(entity =>
            {
                entity.HasKey(e => e.IdRozmiaru)
                    .HasName("Rozmiar_Pizzy_pk");

                entity.ToTable("Rozmiar_Pizzy");

                entity.Property(e => e.IdRozmiaru).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SrednicaWCm).HasColumnName("Srednica_w_cm");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("Uzytkownik_pk");

                entity.Property(e => e.IdUser).ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Indeks)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.NrDomu).HasColumnName("Nr_domu");

                entity.Property(e => e.NrMieszkania).HasColumnName("Nr_mieszkania");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UzytkownikZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.UzytkownikIdUser, e.ZamowienieIdZamowienie })
                    .HasName("Uzytkownik_Zamowienie_pk");

                entity.ToTable("Uzytkownik_Zamowienie");

                entity.Property(e => e.UzytkownikIdUser).HasColumnName("Uzytkownik_IdUser");

                entity.Property(e => e.ZamowienieIdZamowienie).HasColumnName("Zamowienie_IdZamowienie");

                entity.HasOne(d => d.UzytkownikIdUserNavigation)
                    .WithMany(p => p.UzytkownikZamowienie)
                    .HasForeignKey(d => d.UzytkownikIdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Uzytkownik_Zamowienie_Uzytkownik");

                entity.HasOne(d => d.ZamowienieIdZamowienieNavigation)
                    .WithMany(p => p.UzytkownikZamowienie)
                    .HasForeignKey(d => d.ZamowienieIdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Uzytkownik_Zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie).ValueGeneratedNever();

                entity.Property(e => e.DataCzasRealizacjiZamowienia)
                    .HasColumnName("Data_czas_realizacji_zamowienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataCzasZamowienia)
                    .HasColumnName("Data_czas_zamowienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.Komentarz)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SumaZamowienia)
                    .HasColumnName("suma_zamowienia")
                    .HasColumnType("money");
            });
        }
    }
}
