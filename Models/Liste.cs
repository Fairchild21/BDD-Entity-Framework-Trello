using System;
using System.Collections.Generic;

namespace BDD_Trello.Models;

public partial class Liste
{
    public int IdListe { get; set; }

    public string? Nom { get; set; }

    public int? IdProjet { get; set; }

    public virtual List<Carte> Cartes { get; } = new List<Carte>();

    public virtual Projet? IdProjetNavigation { get; set; }

    public Liste()
    {
        this.IdListe = 0;
    }

    public Liste(string nom, int idProjet, Projet idProjetNavigation)
    {
        this.IdListe = 0;
        this.Nom = nom;
        this.IdProjet = idProjet;        
        this.IdProjetNavigation = idProjetNavigation;

    }

      public void changeNom(string nouveauNom)
        {
            Nom = nouveauNom;
        }
}
