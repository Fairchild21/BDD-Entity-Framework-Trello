using System;
using System.Collections.Generic;

namespace BDD_Trello.Models;

public partial class UtilisateurProjet
{
    public int IdUtilisateurProjet { get; set; }

    public int? IdUtilisateur { get; set; }

    public int? IdProjet { get; set; }

    public virtual Projet? IdProjetNavigation { get; set; }

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; }

    public UtilisateurProjet()
    {
        this.IdUtilisateurProjet = 0;
    }

    public UtilisateurProjet(int idUtilisateur, int idProjet, Projet idProjetNavigation, Utilisateur idUtilisateurNavigation)
    {
        this.IdUtilisateurProjet = 0;
        this.IdUtilisateur = idUtilisateur;
        this.IdProjet = idProjet;
        this.IdProjetNavigation = idProjetNavigation;
        this.IdUtilisateurNavigation = idUtilisateurNavigation;
    }
}
