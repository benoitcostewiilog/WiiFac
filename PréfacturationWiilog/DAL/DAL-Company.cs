using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PréfacturationWiilog
{
    class DAL_Company
    {
        public static ENT_Company GetOneCompany(SQLiteConnection db,string Id)
        {
            return db.Get<ENT_Company>(Id);

        }
        public static void CreateCompany(SQLiteConnection db, ENT_Company mycomp)
        {
            var Ok = db.Insert(mycomp);
            Console.WriteLine("{0}", Ok); // Permet de s'avoir que la modif s'est bien faite
        }
        public static void UpdateCompany(SQLiteConnection db, ENT_Company mycomp)
        {
            db.Update(mycomp);  
        }
        public static void DeleteCompany(SQLiteConnection db, ENT_Company mycomp)
        {
            db.Delete(mycomp);

        }
        public static List<ENT_Company> GetAllCompany()
        {
            return new List<ENT_Company>();
        }

    }
}
