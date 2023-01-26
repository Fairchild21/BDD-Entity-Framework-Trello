using System;
using System.Collections.Generic;

namespace BDD_Trello.Models;

public partial class Carte
{
    public int IdCarte { get; set; }

    public string? Titre { get; set; }

    public string? Description { get; set; }

    public DateTime? DateCreation { get; set; }

    public int? IdListe { get; set; }

    public virtual ICollection<Commentaire> Commentaire {get;}

    public virtual ICollection<Etiquette> Etiquette {get;}

    public virtual Liste? IdListeNavigation { get; set; }

    public Carte()
    {
        this.IdCarte = 0;
    }

    public Carte(string titre, string description, DateTime dateCreation, int idListe,Liste idListeNavigation)
    {
        this.IdCarte = 0;
        this.Titre = titre;
        this.Description = description;
        this.DateCreation = dateCreation;
        this.IdListe = idListe;
        this.IdListeNavigation = idListeNavigation;
    }
}
