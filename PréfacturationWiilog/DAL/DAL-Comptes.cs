using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PréfacturationWiilog
{
    class DAL_Comptes
    {
        public static ENT_Comptes GetOneComptes(SQLiteConnection db, string Id)
        {
            return db.Get<ENT_Comptes>(Id);

        }
        public static List<ENT_Comptes> GetOneComptesByFilialeAndNomclient(SQLiteConnection db, string pfiliale, string pnomclient)
        {
            return db.Query<ENT_Comptes>("SELECT * FROM ENT_Comptes WHERE Filiale=? AND Nomclient=?", pfiliale, pnomclient);
        }
        public static ENT_Comptes GetOneComptesByFiliale(SQLiteConnection db, string pfiliale)
        {
            List<ENT_Comptes> Listcomptes = db.Query<ENT_Comptes>("SELECT * FROM ENT_Comptes WHERE Filiale=?", pfiliale);
            if(Listcomptes.Count > 0)
            {
                return Listcomptes[0];
            }
            else
            {
                ENT_Comptes Moncompte = new ENT_Comptes();
                Moncompte.Id = 0;
                return Moncompte;
            }
        }
        public static List<ENT_Comptes> GetAllComptes(SQLiteConnection db)
        {
            return db.Query<ENT_Comptes>("select * from ENT_Comptes");
        }
        public static void CreateComptes(SQLiteConnection db, ENT_Comptes mycompte)
        {
            var Ok = db.Insert(mycompte);
            Console.WriteLine("{0}", Ok); // Permet de s'avoir que la modif s'est bien faite
        }
        public static void UpdateComptes(SQLiteConnection db, ENT_Comptes mycompte)
        {
            db.Update(mycompte);
        }
        public static void DeleteComptes(SQLiteConnection db, ENT_Comptes mycompte)
        {
            db.Delete(mycompte);

        }

    }
}
