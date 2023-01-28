using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BDD_Trello.Models;

public partial class ProjetContext : DbContext
{
    public ProjetContext()
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
        // System.Console.WriteLine("database created");
    }

    public ProjetContext(DbContextOptions<ProjetContext> options): base(options)
    {
        
    }

    public virtual DbSet<Carte> Cartes { get; set; }

    public virtual DbSet<Commentaire> Commentaires { get; set; }

    public virtual DbSet<Etiquette> Etiquettes { get; set; }

    public virtual DbSet<Liste> Listes { get; set; }

    public virtual DbSet<Projet> Projets { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<UtilisateurProjet> UtilisateurProjets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-APU3DEDU;Database=Projet;Trusted_Connection=True;trustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carte>(entity =>
        {
            entity.HasKey(e => e.IdCarte).HasName("PK__Carte__AB8B6B397E3A0591");

            entity.ToTable("Carte");

            entity.Property(e => e.IdCarte).HasColumnName("ID_carte");
            entity.Property(e => e.DateCreation)
                .HasColumnType("date")
                .HasColumnName("Date_creation");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IdListe).HasColumnName("ID_liste");
            entity.Property(e => e.Titre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdListeNavigation).WithMany(p => p.Cartes)
                .HasForeignKey(d => d.IdListe)
                .HasConstraintName("FK__Carte__ID_liste__48CFD27E");
        });

        modelBuilder.Entity<Commentaire>(entity =>
        {
            entity.HasKey(e => e.IdCommentaire).HasName("PK__Commenta__08AD643C40A17AA7");

            entity.ToTable("Commentaire");

            entity.HasIndex(e => e.IdCarte, "UQ__Commenta__AB8B6B3857B171D4").IsUnique();

            entity.HasIndex(e => e.IdUtilisateur, "UQ__Commenta__DBEF746BA29FE0D6").IsUnique();

            entity.Property(e => e.IdCommentaire).HasColumnName("ID_commentaire");
            entity.Property(e => e.Contenu).HasColumnType("text");
            entity.Property(e => e.DateCreation)
                .HasColumnType("date")
                .HasColumnName("Date_creation");
            entity.Property(e => e.IdCarte).HasColumnName("ID_carte");
            entity.Property(e => e.IdUtilisateur).HasColumnName("ID_utilisateur");

            entity.HasOne(d => d.IdCarteNavigation).WithMany(p => p.Commentaire)
                .HasForeignKey(d => d.IdCarte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Commentai__ID_ca__4E88ABD4");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.Commentaire)
                .HasForeignKey(d => d.IdUtilisateur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Commentai__ID_ut__4F7CD00D");
        });

        modelBuilder.Entity<Etiquette>(entity =>
        {
            entity.HasKey(e => e.IdEtiquette).HasName("PK__Etiquett__65DA6D7AE30849C1");

            entity.ToTable("Etiquette");

            // entity.HasIndex(e => e.IdCarte, "UQ__Etiquett__AB8B6B38D0A789DD").IsUnique();

            entity.Property(e => e.IdEtiquette).HasColumnName("ID_etiquette");
            entity.Property(e => e.Couleur)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IdCarte).HasColumnName("ID_carte");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);

            // entity.HasOne(x => x.IdCarteNavigation).WithMany(x => x.Etiquette).HasForeignKey(x => x.IdCarte)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("FKEtiquetteID_ca__48CFD27E");
            entity.HasOne(d => d.IdCarteNavigation).WithMany(p => p.Etiquette)
                .HasForeignKey(d => d.IdCarte)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("etiquette_ibfk_1");
        });

        modelBuilder.Entity<Liste>(entity =>
        {
            entity.HasKey(e => e.IdListe).HasName("PK__Liste__7DAA00A796403014");

            entity.ToTable("Liste");

            entity.Property(e => e.IdListe).HasColumnName("ID_liste");
            entity.Property(e => e.IdProjet).HasColumnName("ID_projet");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProjetNavigation).WithMany(p => p.Listes)
                .HasForeignKey(d => d.IdProjet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Liste__ID_projet__4CA06362");
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.HasKey(e => e.IdProjet).HasName("PK__Projet__2396BD54D0704672");

            entity.ToTable("Projet");

            entity.Property(e => e.IdProjet).HasColumnName("ID_projet");
            entity.Property(e => e.DateCreation)
                .HasColumnType("date")
                .HasColumnName("Date_creation");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Nom)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("PK__Utilisat__6688E0AB1E2DDD0E");

            entity.ToTable("Utilisateur");

            entity.Property(e => e.IdUtilisateur).HasColumnName("ID_utilisateur");
            entity.Property(e => e.AdresseEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Adresse_email");
            entity.Property(e => e.DateInscription)
                .HasColumnType("date")
                .HasColumnName("Date_inscription");
            entity.Property(e => e.MotDePasse)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Mot_de_passe");
            entity.Property(e => e.Nom)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UtilisateurProjet>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateurProjet).HasName("PK__Utilisat__38E5FD2D840C5A62");

            entity.ToTable("Utilisateur_Projet");

            entity.Property(e => e.IdUtilisateurProjet).HasColumnName("ID_Utilisateur_projet");
            entity.Property(e => e.IdProjet).HasColumnName("ID_projet");
            entity.Property(e => e.IdUtilisateur).HasColumnName("ID_utilisateur");

            entity.HasOne(d => d.IdProjetNavigation).WithMany(p => p.UtilisateurProjets)
                .HasForeignKey(d => d.IdProjet)
                .HasConstraintName("FK__Utilisate__ID_pr__4BAC3F29");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.UtilisateurProjets)
                .HasForeignKey(d => d.IdUtilisateur)
                .HasConstraintName("FK__Utilisate__ID_ut__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
