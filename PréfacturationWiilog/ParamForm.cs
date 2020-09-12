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
    public partial class ParamForm : Form
    {
        public static string port;
        public static string protocol;
        public ParamForm()
        {
            InitializeComponent();
            GestionINIParam.GetIniParam();
            //on set toutes les valeurs
            textBox1.Text = GestionINIParam.Serveursmtp;
            textBox2.Text = GestionINIParam.Utilisateur;
            textBox3.Text = GestionINIParam.Motdepasse;
            textBox4.Text = GestionINIParam.Expediteur;
            textBox5.Text = GestionINIParam.Destinataireprefac;
            set_Port(GestionINIParam.Port);
            set_Protocol(GestionINIParam.Protocol);
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            select_protocol("normal");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            select_protocol("SSL");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sauvegarde des paramétrages
            GestionINIParam.Serveursmtp = textBox1.Text;
            GestionINIParam.Utilisateur = textBox2.Text;
            GestionINIParam.Motdepasse = textBox3.Text;
            GestionINIParam.Expediteur = textBox4.Text;
            GestionINIParam.Destinataireprefac = textBox5.Text;
            GestionINIParam.Port = port;
            GestionINIParam.Protocol = protocol;
            GestionINIParam.SetIniParam();
            //On ferme la fenêtre
            this.Close();
        }
        private void select_Port(string pport)
        {
            port = pport;/*
            switch (pport)
            {
                case "25":
                    Console.WriteLine("25");
                    //radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    break;
                case "587":
                    Console.WriteLine("587");
                    radioButton1.Checked = false;
                    //radioButton2.Checked = true;
                    break;
                default:
                    break;
            }*/
        }
        private void select_protocol(string pprotocol)
        {
            protocol = pprotocol;
            
        }
        private void set_Port(string pport)
        {
            switch (pport)
            {
                case "25":
                    radioButton1.Checked = true;
                    break;
                case "587":
                    radioButton2.Checked = true;
                    break;
                default:
                    break;
            }
            
        }
        private void set_Protocol(string protocol)
        {
        switch (protocol)
            {
                case "normal":
                    radioButton3.Checked = true;
                    break;
                case "SSL":
                    radioButton4.Checked = true;
                    break;
                case "TLS":
                    radioButton5.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            select_Port("25");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            select_Port("587");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            select_protocol("TLS");
        }
    }
}
