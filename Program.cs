using BDD_Trello.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ConsoleApp
{
    class Programm
    {
        static void Main(string[] args)
        {
            var context = new ProjetContext();
            
            Repository<Utilisateur> repoUtilisateur = new Repository<Utilisateur>(context);
            Repository<Projet> repoProjet = new Repository<Projet>(context);
            Repository<Liste> repoListe = new Repository<Liste>(context);
            Repository<Carte> repoCarte = new Repository<Carte>(context);
            Repository<Commentaire> repoCommentaire = new Repository<Commentaire>(context);
            Repository<Etiquette> repoEtiquette = new Repository<Etiquette>(context);
            Repository<UtilisateurProjet> repoUtilisateurProjet = new Repository<UtilisateurProjet>(context);

            // Ajout utilisateurs
            // var proj = new Projet();  // Constructeur vide pour utiliser la méthode Read afin de pouvoir ajouter plusieur listes à un même projet
            // proj = repoProjet.ReadEntity(1);
            // var user1 = new Utilisateur("Fairchild","fd@gmail.com", "fd0001", new DateTime(2023,01,26));
            // var user2 = new Utilisateur("Angel","ange@gmail.com", "an0011", new DateTime(2023,01,25));
            // repo.AddEntity(user1);
            // repo.AddEntity(user2);

            // //Ajout projets
            // var proj = new Projet("Trello", "Créer la BDD", new DateTime(2023,01,17));
            // repoProjet.AddEntity(proj);
            // var proj2 = new Projet("Test 2","Tester la deuxième méthode par défaut", DateTime.Today);
            // repoProjet.AddEntity(proj2);

            //Ajout listes
            // var proj = new Projet();
            // proj = repoProjet.ReadEntity(1);
            // var list = new Liste("Liste 1", 1, proj);
            // var list1 = new Liste("Liste 2", 1, proj);
            // var list2 = new Liste("Liste 3", 1, proj);
            // repoListe.AddEntity(list);
            // repoListe.AddEntity(list1);
            // repoListe.AddEntity(list2);

            // //Ajout cartes
            // var list = new Liste();
            // list = repoListe.ReadEntity(1);
            // var card = new Carte("A faire", "Travailler sur la bdd", new DateTime(2023,01,17),1,list);
            // var card1 = new Carte("A faire", "Mettre à jour la bdd", new DateTime(2023,01,26),1,list1);
            // var card2 = new Carte("A faire", "Tester la bdd", new DateTime(2023,01,26),1,list);
            // repoCarte.AddEntity(card);
            // repoCarte.AddEntity(card1);
            // repoCarte.AddEntity(card2);

            // //Ajout commentaires  
            // var card = new Carte();
            // card = repoCarte.ReadEntity(1);       
            // var user = new Utilisateur();
            // user = repoUtilisateur.ReadEntity(2); 
            // var commentaire = new Commentaire("Cela avant doucement mais sûrement", new DateTime(2023,01,26),1,2, card, user1);
            // var commentaire1 = new Commentaire("Update en cours", new DateTime(2023,01,26),2,2, card, user);
            // repoCommentaire.AddEntity(commentaire);
            // repoCommentaire.AddEntity(commentaire1);

            // //Ajout etiquette
            // var carte = new Carte ();
            // carte = repoCarte.Find(2);
            // var etiquette = new Etiquette("Urgent", "Rouge", 2, carte);
            // var etiquette1 = new Etiquette("Important", "Jaune", 1, carte);
            // repoEtiquette.AddEntity(etiquette);
            // repoEtiquette.AddEntity(etiquette1);
            

            // //Ajout utilisateurProjet
            // var userProj = new UtilisateurProjet(1, 1, proj, user2);
            // repoUtilisateurProjet.AddEntity(userProj);

        //    var card = new Carte();
        //    card = repoCarte.Find(1);
        //    card.changeListe(repoListe.Find(2));
        //    repoListe.UpdateEntity();

           
           Carte card = new Carte();
           System.Console.WriteLine(repoCarte.Find(1).IdListeNavigation);
           card.GetEtiquettes();
           //System.Console.WriteLine(card.Recherche("Urgent"));
            
            
        }
    }
}


        