using System;
using System.Collections.Generic;

namespace BDD_Trello.Models;

public partial class Commentaire
{
    public int IdCommentaire { get; set; } 

    public string? Contenu { get; set; }

    public DateTime? DateCreation { get; set; }

    public int? IdCarte { get; set; }

    public int? IdUtilisateur { get; set; }

    public virtual Carte? IdCarteNavigation { get; set; }

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; }

    public Commentaire()
    {
        this.IdCommentaire = 0;
    }

    public Commentaire(string contenu, int idCarte, int idUtilisateur, Carte idCarteNavigation, Utilisateur idUtilisateurNavigation, DateTime dateCreation = default)
    {
        this.IdCommentaire = 0;
        this.Contenu = contenu;
        this.DateCreation = dateCreation;
        this.IdCarte = idCarte;
        this.IdUtilisateur = idUtilisateur;
        this.IdUtilisateurNavigation = idUtilisateurNavigation;
    }

     public void changeContenu(string nouveauContenu)
    {
        Contenu = nouveauContenu;
    }
}
