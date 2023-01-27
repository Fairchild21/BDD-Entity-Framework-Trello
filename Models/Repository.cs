using Microsoft.EntityFrameworkCore;

namespace BDD_Trello.Models
{
    public class Repository<T> where T : class
    {
        private ProjetContext _db;
        private DbSet<T> _table;
        public Repository(ProjetContext db)
        {
            _db = db;
            _table = db.Set<T>();
            System.Console.WriteLine("Repository created.");
        }

        public void AddEntity(T entity)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _table.Add(entity);
                    _db.SaveChanges();
                    transaction.Commit();           
                    System.Console.WriteLine("Add Done");       
                }
                catch(ApplicationException ex)
                {
                    transaction.Rollback();
                    System.Console.WriteLine("Not add " + ex.Message);
                }
            }
        }

        public void DeleteEntity(T entity)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _table.Remove(entity);
                    _db.SaveChanges();
                    transaction.Commit();         
                    System.Console.WriteLine("Delete succeed");      
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

       public void UpdateEntity()
       {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
       } 

        public T Find(int ID)
        {
            try
            {
                return _table.Find(ID);              
            }
            catch (Exception)
            {
                System.Console.WriteLine("Cet ID est introuvable...");
                return null;
            }
        }    

          public List<T> FindListEntity(List<int> listID)
        {
            try
            {
                List<T> resultat = new List<T>();
                foreach (int element in listID)
                {
                    resultat.Add(_table.Find(element));
                }
                return resultat;              
            }
            catch (Exception)
            {
                System.Console.WriteLine("Au moins un de ces ID est introuvable...");
                return null;
            }
        }

        public bool Authentication(string entry, string password)
        {
            var users = _db.Utilisateurs.ToList();
            bool connected = false;

            foreach (Utilisateur u in users)
            {                
                if (u.Nom == entry || u.AdresseEmail == entry)
                {
                    if (u.MotDePasse == password)
                    {
                        connected = true;
                        return connected;
                    }
                }
            }
            return connected;

        }
    }
}