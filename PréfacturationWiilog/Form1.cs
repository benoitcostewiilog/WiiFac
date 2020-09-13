using Microsoft.VisualBasic.FileIO;
using PréfacturationWiilog.DAL;
using PréfacturationWiilog.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;


namespace PréfacturationWiilog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //chargement du datagridview des comptes
            refreshDataGridView();

            //chargement des mois dans la combo box
            comboBox1.DataSource = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Take(12).ToList();
            comboBox1.SelectedItem = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[DateTime.Now.AddMonths(-1).Month - 1];
            //Chargement des années
            comboBox3.DataSource = Enumerable.Range(2018, DateTime.Now.Year - 2018 + 1).ToList();
            comboBox3.SelectedItem = DateTime.Now.Year;

        }

        private void Button1_Click(object sender, EventArgs e)
        {


        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                //MessageBox.Show($"Modification{e.ColumnIndex}");
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                CompteCreeForm modifform = new CompteCreeForm(this, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                modifform.Show();
            }
        }

        //Génration des prefacs
        private void Button2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Génération des préfacs en cours...";
            toolStripStatusLabel1.Text = GestionPrefac.GenererPrefac(comboBox3.Text, comboBox1.Text, comboBox1.SelectedIndex + 1);
            toolStripStatusLabel1.Text = GestionPrefac.ZipPrefac(comboBox1.Text, comboBox3.Text);
            if (GestionINIParam.Envoiemailprefac)
            {
            toolStripStatusLabel1.Text = GestionPrefac.EnvoiParMail(comboBox1.Text, comboBox3.Text, "coste.benoit@gmail.com");

            }


        }



        private void Button4_Click(object sender, EventArgs e)
        {

        }

        //Bouton Importer fichier csv
        private void SélectionnerLeFichierDactivitéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //initialisation de la db 
            DBConnect.DbConnection();

            //Variables de sélection du mois en cours
            int monthcombo = comboBox1.SelectedIndex + 1;
            int yearcombo = Int32.Parse(comboBox3.Text);
            DateTime DateSelectionnee = new DateTime(yearcombo, monthcombo, 1);
            
            //Liste des activités à charger depuis csv
            List<ENT_Activites> activiteCollection = new List<ENT_Activites>();
            //on ouvre la sélection d'un fichier
            
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "fichier csv (*.csv)|*.csv|Tous les fichiers (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }
            //suppression des activités pour le mois en cours
            DAL_Activites.DeleteAll(DBConnect.dbconn);

            //On charge tout dans la collection d'activite
            if (filePath != "")
            {
                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        //Processing row
                        string[] fields = parser.ReadFields();
                        //MessageBox.Show(fields[0]);
                        if (fields[0] != "Date")
                        {
                            try
                            {
                                DateTime madate = DateTime.ParseExact(fields[0], "dd/MM/yy", CultureInfo.InvariantCulture);
                                if (madate.Month == DateSelectionnee.Month & DateSelectionnee.Year == 2020)
                                {
                                    //MessageBox.Show("on est dans la date ! " + fields[0]);
                                    //on ajoute la ligne dans notre activitecsv
                                    ENT_Activites monActivite = new ENT_Activites();
                                    monActivite.Dateact = DateTime.ParseExact(fields[0], "dd/MM/yy", null);
                                    monActivite.Temps = float.Parse(fields[1], CultureInfo.InvariantCulture.NumberFormat);
                                    monActivite.Tache = fields[2];
                                    monActivite.Nomutilisateur = fields[3];
                                    monActivite.Projet = fields[4];

                                    //récupération du compte
                                    ENT_Comptes Moncompte= DAL_Comptes.GetOneComptesByFiliale(DBConnect.dbconn, fields[7]);
                                    if (Moncompte.Id > 0)
                                    {
                                        //on affecte le compte à l'activité
                                        monActivite.ENT_ComptesId = Moncompte.Id;
                                        monActivite.ENT_Comptes = Moncompte;
                                        //MessageBox.Show(Moncompte.Id.ToString());
                                    }
                                    else
                                    {
                                        //on créé le compte
                                        ENT_Comptes Moncompte2 = new ENT_Comptes();
                                        Moncompte2.Filiale = fields[7];
                                        DAL_Comptes.CreateComptes(DBConnect.dbconn, Moncompte2);
                                        //on affecte le compte à l'activité
                                        monActivite.ENT_Comptes = Moncompte2;
                                        monActivite.ENT_ComptesId = Moncompte2.Id;
                                    }
                                
                                    //on ajout l'activité à la liste d'activite
                                    activiteCollection.Add(monActivite);
                                }
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("{0} n'est pas dans le format dd/MM/yy", fields[0]);

                            }
                        }
                    }
                    //on persiste toutes les activités en base
                    DAL_Activites.InsertListofActivities(DBConnect.dbconn,activiteCollection);
                    //GestionCSVActivite.listeActivite = activiteCollection;
                    /*
                    GestionCSVActivite.ListeClientDistinct();
                    GestionCSVActivite.ListeUtilisateurDistinct();
                */    
                MessageBox.Show("Activitès chargées !");
                    //on raffraichit notre grid
                    refreshDataGridView();
                }
            }
        }

        private void SélectionnerLesComptesCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            //Sélection du fichier des comptes clients
            //Sélection du fichier compte csv
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "fichier csv (*.csv)|*.csv|Tous les fichiers (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    GestionCSVCompte.cheminfichiercsvcomptes = openFileDialog.FileName;
                }
            }
            //chargement de la datagrid avec le fichier csv
            GestionCSVCompte.ListeCompte();
            //on vide datagridview
            //chargement du datagrid

            foreach (strComptes strc in GestionCSVCompte.listecomptes)
            {
                //Console.WriteLine(s);
                dataGridView1.Rows.Add(strc.filiale, strc.nomClient, strc.montantMensuel, strc.contact);
            }
            */
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GestionPrefac.EnvoiParMail(comboBox1.Text, comboBox3.Text, "coste.benoit@gmail.com"));
        }

        private void paramétrageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamForm frm = new ParamForm();
            frm.Text = "Paramétrage Mail";
            frm.Show();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            CompteCreeForm creercomptef = new CompteCreeForm(this);
            creercomptef.Show();
        }
        public void refreshDataGridView()
        {

            DBConnect.DbConnection();
            eNTComptesBindingSource.DataSource = DAL_Comptes.GetAllComptes(DBConnect.dbconn);
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("query");
            DBConnect.DbConnection();
            List<ENT_Comptes> Moncompte = DAL_Comptes.GetOneComptesByFilialeAndNomclient(DBConnect.dbconn, "GTX-03", "CEA Leti");
            //MessageBox.Show(Moncompte[0].Contact + Moncompte[0].Id);
        }
    }
}
;