using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PréfacturationWiilog
{
    class GestionINIParam
    {
        public static string Serveursmtp { get; set; }
        public static string Utilisateur { get; set; }
        public static string Motdepasse { get; set; }
        public static string Port { get; set; }
        public static string Protocol { get; set; }
        public static string Expediteur { get; set; }
        public static string Destinataireprefac { get; set; }
        public static bool  Envoiemailprefac { get; set; }
        public static void GetIniParam()
        {
            if (File.Exists("Configuration.ini"))
            {
                //Récupération des données depuis ini parser
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("Configuration.ini");
                Serveursmtp = data["Param Mail"]["serveursmtp"];
                Utilisateur = data["Param Mail"]["utilisateur"];
                Motdepasse = data["Param Mail"]["motdepasse"];
                Port = data["Param Mail"]["port"];
                Protocol = data["Param Mail"]["protocol"];
                Expediteur = data["Param Mail"]["expediteur"];
                Destinataireprefac = data["Param Mail"]["destinataireprefac"];
                if (data["Param Mail"]["envoiemailprefac"] != null)
                {
                Envoiemailprefac = bool.Parse(data["Param Mail"]["envoiemailprefac"]);
                }
                else
                {
                    Envoiemailprefac = true;
                }
            }
        }
        public static void SetIniParam()
        {
            //Sauvegarde des données depuis ini parser
            var parser = new FileIniDataParser();
            IniData data = new IniData();
            data["Param Mail"]["serveursmtp"] = Serveursmtp;
            data["Param Mail"]["utilisateur"] = Utilisateur;
            data["Param Mail"]["motdepasse"] = Motdepasse;
            data["Param Mail"]["destinataireprefac"] = Destinataireprefac;
            data["Param Mail"]["port"] = Port;
            data["Param Mail"]["protocol"] = Protocol;
            data["Param Mail"]["expediteur"] = Expediteur;
            data["Param Mail"]["envoiemailprefac"] = Envoiemailprefac.ToString();

            parser.WriteFile("Configuration.ini", data);

        }
    }
}
