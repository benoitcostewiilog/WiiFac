using PréfacturationWiilog.DAL;
using PréfacturationWiilog.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace PréfacturationWiilog
{
    class GestionPrefac
    {
        public static string cheminmodeleprefacexcel = "";
        public static string chemindestinationprefac = "";
        public static string fichierprefaczip = "";
        public static string GenererPrefac(string annee, string mois, int intmois)
        {

            DateTime dateselectionnee = new DateTime(2010, intmois, 1);
            string mmmoisselectionne = dateselectionnee.ToString("MM");

            if (cheminmodeleprefacexcel == "")
            {
                //Message d'alerte
                //MessageBox.Show("Vous devez spécifier le répertoire de destination des préfacs");

                //Extraction du modèle depuis une ressource.
                cheminmodeleprefacexcel = Directory.GetCurrentDirectory() + "\\Doc\\" + "2020-01 PREFAC - modele.xls";

                using (FolderBrowserDialog openBrowserDialog = new FolderBrowserDialog())
                {
                    openBrowserDialog.Description = "Sélectionnez le répertoire de génération des préfacs";

                    if (openBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        chemindestinationprefac = openBrowserDialog.SelectedPath + "\\";
                    }
                }
            }

            //écrire dans excel
            Excel.Application excelApp = new Excel.Application();
            if (excelApp != null)
            {
                //ouverture du modèle
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(cheminmodeleprefacexcel);
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets["Feuil1"];

                //récupération des comptes dans la méthode
                DBConnect.DbConnection();
                List<ENT_Comptes> listeComptes = DAL_Comptes.GetAllComptes(DBConnect.dbconn);

                //récupération des actités dans la méthode
                List<ENT_Activites> ListeActivites = DAL_Activites.GetAllActivites(DBConnect.dbconn);

                //récupération des nom utilisateur distinct
                List<ENT_Activites> ListeUtilisateurs = DAL_Activites.SelectDistinctUserofActivites(DBConnect.dbconn);
                //Boucle création des pre factures
                //on commence par les abonnements/comptes
                foreach (ENT_Comptes entcompt in listeComptes)
                {
                    float totalgtht = 0;
                    
                    excelWorksheet.Cells[14, 6] = entcompt.Filiale;
                    if (entcompt.Nomclient != null)
                    {
                        excelWorksheet.Cells[15, 1] = "Contact : " + entcompt.Nomclient;
                    }
                    //Ajout des lignes pour Montant Mensuel

                    excelWorksheet.Cells[29, 7] = entcompt.Montantmensuel;
                    excelWorksheet.Cells[29, 10] = entcompt.Montantmensuel;
                    excelWorksheet.Cells[49, 10] = entcompt.Montantmensuel;
                    
                    totalgtht += entcompt.Montantmensuel;
                    //excelApp.ActiveWorkbook.SaveAs(Path.Combine(Path.GetDirectoryName(chemindestinationprefac), annee + "-" + mmmoisselectionne + " - " + entcompt.Filiale + ".xlsx"), Excel.XlFileFormat.xlWorkbookDefault);

                    int y = 1;

                    //boucle dans les utilisateurs distinct d'activite
                    foreach (ENT_Activites ActNomutilisateur in ListeUtilisateurs)
                    {

                        //MessageBox.Show("je suis ici " + ActNomutilisateur.Nomutilisateur);
                        //Boucle sur les utilisateurs
                        /* for (int y = 0; y < GestionCSVActivite.listeUtilisateur.Length; y++)
                         {
                             */
                        float compteurtemps = 0;
                        float tauxjournalier = 0;
                        float totalhtparutilisateur = 0;

                        switch (ActNomutilisateur.Nomutilisateur)
                        {
                            case "Lepain":
                                Console.WriteLine("Lepain");
                                tauxjournalier = 60;
                                //Console.WriteLine("Case 1");
                                break;
                            case "Coste":
                                Console.WriteLine("Coste");
                                tauxjournalier = 55;
                                //Console.WriteLine("Case 2");
                                break;
                            case "Boumahrou":
                                Console.WriteLine("Boumahrou");
                                tauxjournalier = 50;
                                break;
                            default:
                                //Console.WriteLine("Default case");
                                break;
                        }

                        //boucle dans les activités
                        foreach (ENT_Activites Activite in ListeActivites)
                        {
                            if (ActNomutilisateur.Nomutilisateur == Activite.Nomutilisateur & entcompt.Id == Activite.ENT_ComptesId)
                            {
                                Console.WriteLine("Compteur de temps : " + compteurtemps);
                                compteurtemps += Activite.Temps;

                            }

                        }
                        totalhtparutilisateur = compteurtemps * tauxjournalier;
                        totalgtht += totalhtparutilisateur;
                        excelWorksheet.Cells[29 + y, 2] = "Gestion de projet - " + ActNomutilisateur.Nomutilisateur;
                        excelWorksheet.Cells[29 + y, 7] = totalhtparutilisateur;
                        excelWorksheet.Cells[29 + y, 10] = totalhtparutilisateur;
                        y++;
                    }
                    Console.WriteLine("le totalht est : " + totalgtht);
                    excelWorksheet.Cells[14, 6] = entcompt.Filiale;
                    excelWorksheet.Cells[15, 1] = "Contact : " + entcompt.Contact;
                    excelWorksheet.Cells[49, 10] = totalgtht;
                    //excelWorksheet.Cells[49, 10] = "et oui mon petit";
                    excelWorksheet.Cells[24, 2] = "Gestion de projet du mois de " + mois + " pour : " + entcompt.Nomclient;
                    excelApp.ActiveWorkbook.SaveAs(Path.Combine(Path.GetDirectoryName(chemindestinationprefac), annee + "-" + mmmoisselectionne + " - " + entcompt.Filiale + ".xlsx"), Excel.XlFileFormat.xlWorkbookDefault);

                    Console.WriteLine("fin du fichier excel");
                }//fin de foreach liste comptes
                excelWorkbook.Close();
                excelApp.Quit();
            }
            return "Prefac générées !";

        }
        public static string EnvoiParMail(string mois, string annee, string destinataire, string piecejointe = "")
        {
            //Récupération ini
            //Première lettre en majuscule
            mois = char.ToUpper(mois[0]) + mois.Substring(1);

            GestionINIParam.GetIniParam();
            //Envoi d'un mail
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(GestionINIParam.Serveursmtp);

            mail.From = new MailAddress(GestionINIParam.Expediteur);
            mail.To.Add(destinataire);
            mail.CC.Add("b.coste@gt-logistics.fr");
            mail.Subject = $"Facturation du mois de : {mois} - {annee}";

            mail.Body = "Hello la compta \n" +
            $"Vous trouverez en pièce jointe les préfacs pour le mois de : {mois} - {annee} \n" +
            "Merci à vous.\n" +
            "Benoit Coste";

            // Création de la pièce jointe
            piecejointe = fichierprefaczip;
            Attachment data = new Attachment(piecejointe, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(piecejointe);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(piecejointe);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(piecejointe);
            // Add the file attachment to this email message.
            mail.Attachments.Add(data);

            SmtpServer.Port = Int32.Parse(GestionINIParam.Port);
            SmtpServer.Credentials = new System.Net.NetworkCredential(GestionINIParam.Utilisateur, GestionINIParam.Motdepasse);
            if (GestionINIParam.Protocol == "SSL")
            {
                SmtpServer.EnableSsl = true;
            }
            SmtpServer.Send(mail);
            return $"Mail envoyé à : {destinataire}";
        }
        public static string ZipPrefac(string mois, string annee)
        {

            if (chemindestinationprefac != "")
            {
                //on peut ziper le répertoire
                fichierprefaczip = Directory.GetParent(chemindestinationprefac) + $"Prefac Wiilog - {annee} - {mois}.zip";
                ZipFile.CreateFromDirectory(chemindestinationprefac, fichierprefaczip);
                File.Move(fichierprefaczip, chemindestinationprefac + $"Prefac Wiilog - {annee} - {mois}.zip");
                fichierprefaczip = chemindestinationprefac + $"Prefac Wiilog - {annee} - {mois}.zip";
                return "Prefac Zipées";
            }
            else
            {
                return "Vous devez d'abord générer les prefacs";
            }
        }
    }
}
