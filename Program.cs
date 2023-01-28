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
            var user1 = new Utilisateur("Fairchild","fd@gmail.com", "fd0001", DateTime.Now);
            var user2 = new Utilisateur("Angel","ange@gmail.com", "an0011", DateTime.Now);
            var user3 = new Utilisateur("Schiffon", "schi@gmail.com", "sc1100", DateTime.Now);
            // repoUtilisateur.AddEntity(user1);
            // repoUtilisateur.AddEntity(user2);
            // repoUtilisateur.AddEntity(user3);

            // //Ajout projets
            // var proj = new Projet();  // Constructeur vide pour utiliser la méthode Read afin de pouvoir ajouter plusieur listes à un même projet
            // repoProjet.Find();
            var proj = new Projet("Trello", "Créer la BDD", DateTime.Now);
            var proj2 = new Projet("Test 2","Tester la deuxième méthode par défaut", DateTime.Now);
            // repoProjet.AddEntity(proj);
            // repoProjet.AddEntity(proj2);

            //Ajout listes
            // repoProjet.Find();
            var list = new Liste("Liste 1", 1, proj);
            var list1 = new Liste("Liste 2", 1, proj);
            var list2 = new Liste("Liste 3", 1, proj2);
            // repoListe.AddEntity(list);
            // repoListe.AddEntity(list1);
            // repoListe.AddEntity(list2);

            // //Ajout cartes
            // repoListe.Find();
            var card = new Carte("A faire", "Travailler sur la bdd", 1,list, DateTime.Now);
            var card1 = new Carte("A faire", "Mettre à jour la bdd", 1,list1, DateTime.Now);
            var card2 = new Carte("A faire", "Tester la bdd", 2,list1, DateTime.Now);
            // repoCarte.AddEntity(card);
            // repoCarte.AddEntity(card1);
            // repoCarte.AddEntity(card2);

            // //Ajout commentaires  
            // repoCarte.Find();       
            // var user = new Utilisateur();
            // user = repoUtilisateur.ReadEntity(2); 
            var commentaire = new Commentaire("Cela avant doucement mais sûrement", 1,1, card, user1, DateTime.Now);
            var commentaire1 = new Commentaire("Update en cours", 2,2, card, user2, DateTime.Now);
            // repoCommentaire.AddEntity(commentaire);
            // repoCommentaire.AddEntity(commentaire1);

            // //Ajout etiquette            
            // repoCarte.Find();
            var etiquette = new Etiquette("Urgent", "Rouge", 1, card);
            var etiquette1 = new Etiquette("Important", "Jaune", 1, card);
            var etiquette2 = new Etiquette("Important", "Jaune", 2, card1);
            var etiquette3 = new Etiquette("Fait", "Vert", 3, card2);
            var etiquette4 = new Etiquette("Test", "Violet", 1,repoCarte.Find(1));
            // repoEtiquette.AddEntity(etiquette);
            // repoEtiquette.AddEntity(etiquette1);
            // repoEtiquette.AddEntity(etiquette2);
            // repoEtiquette.AddEntity(etiquette3);
            // repoEtiquette.AddEntity(etiquette4);
            

            // //Ajout utilisateurProjet
            var userProj = new UtilisateurProjet(1, 1, proj, user1);
            var userProj2 = new UtilisateurProjet(2,2, proj2, user2);
            // repoUtilisateurProjet.AddEntity(userProj);
            // repoUtilisateurProjet.AddEntity(userProj2);

        //    var card = new Carte();
        //    card = repoCarte.Find(1);
        //    card.changeListe(repoListe.Find(2));
        //    repoListe.UpdateEntity();

           
        //    Carte card5 = new Carte();
        //    System.Console.WriteLine(repoCarte.Find(1).IdListeNavigation);
        //    card5.GetEtiquettes();
        //    System.Console.WriteLine(card.Recherche("Urgent"));
            
            
        }
    }
}


