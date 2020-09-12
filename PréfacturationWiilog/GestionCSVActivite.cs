using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PréfacturationWiilog
{
    class GestionCSVActivite
    {
        public static List<strActivite> listeActivite;
        public static string[] listeClient;
        public static string[] listeUtilisateur;
        
        
        public static void ListeClientDistinct()
        {
            listeClient = new string[0];
            //on vérifie si liste activité n'est pas null

            List<string> listeclientcollection = new List<string>();
            //boucle activte
            if (listeActivite.Count > 0)
                listeActivite.ForEach(delegate (strActivite uneActivite)
                {
                    if (listeclientcollection.Contains(uneActivite.site))
                    {
                    }
                    else
                    {
                        listeclientcollection.Add(uneActivite.site);
                        //Console.WriteLine(uneActivite.site);
                    }
                    //Console.WriteLine(uneActivite.site);
                });
            listeClient = listeclientcollection.ToArray();
            
        }
        public static void ListeUtilisateurDistinct()
        {
            listeUtilisateur = new string[0];
            //on vérifie si liste activité n'est pas null

            List<string> listeutilisateurcollection = new List<string>();
            //boucle activte
            if (listeActivite.Count > 0)
                listeActivite.ForEach(delegate (strActivite uneActivite)
                {
                    if (listeutilisateurcollection.Contains(uneActivite.nomdUtilisateur))
                    {
                    }
                    else
                    {
                        listeutilisateurcollection.Add(uneActivite.nomdUtilisateur);
                        Console.WriteLine(uneActivite.nomdUtilisateur);
                    }
                    //Console.WriteLine(uneActivite.site);
                });
            listeUtilisateur = listeutilisateurcollection.ToArray();
        }
    }
}
