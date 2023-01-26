using System;
using System.Collections.Generic;

namespace BDD_Trello.Models;

public partial class Utilisateur
{
    public int IdUtilisateur { get; set; }

    public string? Nom { get; set; }

    public string? AdresseEmail { get; set; }

    public string? MotDePasse { get; set; }

    public DateTime? DateInscription { get; set; }

    public virtual  ICollection<Commentaire> Commentaire { get;}

    public virtual ICollection<UtilisateurProjet> UtilisateurProjets { get; } = new List<UtilisateurProjet>();

    public Utilisateur()
    {
        this.IdUtilisateur = 0;
    }

    public Utilisateur(string nom, string adresseEmail, string motDePasse, DateTime dateInscription)
    {
        this.IdUtilisateur = 0;
        this.Nom = nom;
        this.AdresseEmail = adresseEmail;
        this.MotDePasse = motDePasse;
        this.DateInscription = dateInscription;
        
    }
}
