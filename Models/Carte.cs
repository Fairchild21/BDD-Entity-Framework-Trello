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

    public Carte(string titre, string description, int idListe,Liste idListeNavigation, DateTime dateCreation = default)
    {
        this.IdCarte = 0;
        this.Titre = titre;
        this.Description = description;
        this.DateCreation = dateCreation;
        this.IdListe = idListe;
        this.IdListeNavigation = idListeNavigation;
    }

    public void changeListe(Liste idNouvelleListe)
    {
        IdListeNavigation = idNouvelleListe;
        IdListe = idNouvelleListe.IdListe;                
    }
    public void changeTitre(string nouveauTitre)
    {
        Titre = nouveauTitre;
    }

    public void changeDescription(string nouvelleDescription)
    {
        Titre = nouvelleDescription;
    }

    public ICollection<Etiquette> GetEtiquettes()
    {
        return Etiquette;
    }

    public ICollection<Commentaire> GetCommentaires()
    {
        return Commentaire;
    }

     public List<Etiquette> Recherche(string str) // La méthode prend en paramètre une string et utilise la méthode WHERE de la liste Etiquette pour filtrer les objets "etiquette"
    {
        return Etiquette.Where(x => x.Nom == str).ToList(); // x correspond à une étiquette
    }
    

}
