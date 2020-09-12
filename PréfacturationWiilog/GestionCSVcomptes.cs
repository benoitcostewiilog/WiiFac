using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PréfacturationWiilog
{
    class GestionCSVCompte
    {
        public static string cheminfichiercsvcomptes;
        public static List<strComptes> listecomptes = new List<strComptes>();
        public static void AjouteCompte()
        {
            Console.WriteLine("Ajout d'un compte");
        }
        public static void ListeCompte()
        {
            Console.WriteLine("liste des comptes");
            List<string> stringcollection = new List<string>();

            if (cheminfichiercsvcomptes != "" || cheminfichiercsvcomptes != null)
            {
                //parse du fichier comptes
                using (TextFieldParser parser = new TextFieldParser(cheminfichiercsvcomptes))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        //Processing row
                        string[] fields = parser.ReadFields();
                        //On esquive l'entete
                        if(fields[0] == "filiale")
                        {
                            continue;
                        }

                        strComptes moncompte = new strComptes();
                        moncompte.filiale = fields[0];
                        moncompte.nomClient = fields[1];
                        moncompte.montantMensuel = Int32.Parse(fields[2]);
                        moncompte.contact = fields[3];
                        listecomptes.Add(moncompte);
                    }
                }
            }
        }
    }
}
