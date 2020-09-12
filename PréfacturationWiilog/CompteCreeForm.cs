using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PréfacturationWiilog
{
    public partial class CompteCreeForm : Form
    {
        private ENT_Comptes modifcompte;
        Form1 _owner;

        public CompteCreeForm(Form1 owner,string idcompte = "")
        {
            _owner = owner;
            InitializeComponent();
            button2.Visible = false;
            if (idcompte != "")
            {
                //connexion db 
                DBConnect.DbConnection();
                modifcompte = DAL_Comptes.GetOneComptes(DBConnect.dbconn, idcompte);
                textBox1.Text = modifcompte.Filiale;
                textBox2.Text = modifcompte.Nomclient;
                textBox3.Text = modifcompte.Montantmensuel.ToString();
                textBox4.Text = modifcompte.Contact;
                textBox5.Text = modifcompte.Email;
                this.Text = "Modification de compte";
                button2.Visible = true;

            }
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompteCreeForm_FormClosing);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float montantmensuelht = float.Parse(textBox3.Text);
            if (modifcompte != null)
            {
                ENT_Comptes moncompte = modifcompte;
                moncompte.Filiale = textBox1.Text;
                moncompte.Nomclient = textBox2.Text;
                moncompte.Montantmensuel = float.Parse(textBox3.Text);
                moncompte.Contact = textBox4.Text;
                moncompte.Email = textBox5.Text;
                DBConnect.DbConnection();
                DAL_Comptes.UpdateComptes(DBConnect.dbconn, moncompte);
                this.Close();
            }
            else
            {
                ENT_Comptes moncompte = new ENT_Comptes();
                moncompte.Filiale = textBox1.Text;
                moncompte.Nomclient = textBox2.Text;
                moncompte.Montantmensuel = float.Parse(textBox3.Text);
                moncompte.Contact = textBox4.Text;
                moncompte.Email = textBox5.Text;
                DBConnect.DbConnection();
                DAL_Comptes.CreateComptes(DBConnect.dbconn, moncompte);
                _owner.refreshDataGridView();
                this.Close();

            }
        }
        private void CompteCreeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.refreshDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBConnect.DbConnection();
            if (modifcompte != null)
            {
                DAL_Comptes.DeleteComptes(DBConnect.dbconn, modifcompte);
                this.Close();
            }
        }
    }
}
