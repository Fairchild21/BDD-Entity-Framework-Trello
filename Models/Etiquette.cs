using System;
using System.Collections.Generic;

namespace BDD_Trello.Models;

public partial class Etiquette
{
    public int IdEtiquette { get; set; }

    public string Nom { get; set; } = null!;

    public string Couleur { get; set; } = null!;

    public int? IdCarte { get; set; }

    public virtual Carte? IdCarteNavigation { get; set; }

    public Etiquette()
    {
        this.IdEtiquette = 0;
    }

    public Etiquette(string nom, string couleur, int idCarte, Carte idCarteNavigation)
    {
        this.IdEtiquette = 0;
        this.Nom = nom;
        this.Couleur = couleur;
        this.IdCarte = idCarte;
        this.IdCarteNavigation = idCarteNavigation;
    }
}
