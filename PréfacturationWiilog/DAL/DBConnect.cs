using PréfacturationWiilog.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PréfacturationWiilog
{
    class DBConnect
    {
        /*
         * Tuto qui a permis de faire un minimum : 
         * https://www.codejourney.net/2017/05/sqlite-net-extensions-many-to-many-relationships/
         * Lib qui a permis d'utiliser sqlite 
         * https://bitbucket.org/twincoders/sqlite-net-extensions/src/master/
         * Doc minimale
         * https://github.com/praeclarum/sqlite-net/wiki/GettingStarted
         * */

        public static string pathOfDbSQLite = Directory.GetCurrentDirectory() + "\\" + "projectdb.db";
        public static SQLiteConnection dbconn;
        public static void DbConnection()
        {
            //création de la connexion
            dbconn = new SQLiteConnection(pathOfDbSQLite);

            //création des tables si elles n'existent pas
            //Note : Le fichier Sqlite3db se créé automatiquement s'il n'existe pas
            dbconn.CreateTable<ENT_Company>();
            dbconn.CreateTable<ENT_Comptes>();
            dbconn.CreateTable<ENT_Activites>();
        }
    }
}
