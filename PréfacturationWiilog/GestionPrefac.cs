using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
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

                //Boucle création des pre factures
                //on commence par les abonnements
                DBConnect.DbConnection();
                List<ENT_Comptes> listeComptes = DAL_Comptes.GetAllComptes(DBConnect.dbconn);

                foreach (ENT_Comptes entcompt in listeComptes)
                {
                    excelWorksheet.Cells[14, 6] = entcompt.Filiale + " - " + entcompt.Nomclient;
                    excelWorksheet.Cells[15, 1] = "Contact : " + entcompt.Nomclient;
                    excelWorksheet.Cells[29, 7] = entcompt.Montantmensuel;
                    excelWorksheet.Cells[29, 10] = entcompt.Montantmensuel;
                    excelWorksheet.Cells[49, 10] = entcompt.Montantmensuel;
                    excelApp.ActiveWorkbook.SaveAs(Path.Combine(Path.GetDirectoryName(chemindestinationprefac), annee + "-" + mmmoisselectionne + " - " + entcompt.Filiale + " - " + entcompt.Nomclient + ".xlsx"), Excel.XlFileFormat.xlWorkbookDefault);

                }
               
                //on fait maintenant la facturation des CP
                //boucle dans les sites distincts
                if (GestionCSVActivite.listeClient != null)
                {
                    for (int i = 0; i < GestionCSVActivite.listeClient.Length; i++)
                    {
                        //MessageBox.Show("je suis ici " + GestionCSVActivite.listeClient[i]);
                        float totalgtht = 0;
                        //Boucle sur les utilisateurs
                        for (int y = 0; y < GestionCSVActivite.listeUtilisateur.Length; y++)
                        {

                            float compteurtemps = 0;
                            float tauxjournalier = 0;
                            float totalhtparutilisateur = 0;
                            switch (GestionCSVActivite.listeUtilisateur[y])
                            {
                                case "Lepain":
                                    tauxjournalier = 60;
                                    //Console.WriteLine("Case 1");
                                    break;
                                case "Coste":
                                    tauxjournalier = 55;
                                    //Console.WriteLine("Case 2");
                                    break;
                                case "Boumahrou":
                                    tauxjournalier = 50;
                                    break;
                                default:
                                    //Console.WriteLine("Default case");
                                    break;
                            }

                            //boucle dans les activités
                            foreach (strActivite stra in GestionCSVActivite.listeActivite)
                            {
                                if (stra.nomdUtilisateur == GestionCSVActivite.listeUtilisateur[y] & stra.site == GestionCSVActivite.listeClient[i])
                                {
                                    compteurtemps += stra.temps;
                                }
                            }
                            totalhtparutilisateur = compteurtemps * tauxjournalier;
                            totalgtht += totalhtparutilisateur;
                            excelWorksheet.Cells[29 + y, 2] = "Gestion de projet - " + GestionCSVActivite.listeUtilisateur[y];
                            excelWorksheet.Cells[29 + y, 7] = totalhtparutilisateur;
                            excelWorksheet.Cells[29 + y, 10] = totalhtparutilisateur;

                        }
                        excelWorksheet.Cells[14, 6] = GestionCSVActivite.listeClient[i];
                        excelWorksheet.Cells[15, 1] = "Contact : " + GestionCSVActivite.listeClient[i];
                        excelWorksheet.Cells[49, 10] = totalgtht;
                        excelWorksheet.Cells[24, 2] = "Gestion de projet du mois de " + mois + " pour : " + GestionCSVActivite.listeClient[i];
                        excelApp.ActiveWorkbook.SaveAs(Path.Combine(Path.GetDirectoryName(chemindestinationprefac), annee + "-" + mmmoisselectionne + " - " + GestionCSVActivite.listeClient[i] + ".xlsx"), Excel.XlFileFormat.xlWorkbookDefault);

                    }
                }




                //fin boucle création des préfactures

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
