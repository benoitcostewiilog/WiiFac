using PréfacturationWiilog.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PréfacturationWiilog.DAL
{
    class DAL_Activites
    {
        public static Boolean InsertListofActivities(SQLiteConnection db, List<ENT_Activites> Listact)
        {
            //on insert tout
            db.InsertAll(Listact);
            return true;
        }
        public static void DeleteAll(SQLiteConnection db)
        {
            db.DeleteAll<ENT_Activites>();
        }
        public static List<ENT_Activites> SelectDistinctUserofActivites(SQLiteConnection db)
        {
            return db.Query<ENT_Activites>("SELECT DISTINCT Nomutilisateur FROM ENT_Activites");
        }
        public static List<ENT_Activites> GetAllActivites(SQLiteConnection db)
        {
            return db.Query<ENT_Activites>("SELECT * FROM ENT_Activites");
        }
    }
}
