using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
namespace PréfacturationWiilog.Entities
{
    class ENT_Activites
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Dateact { get; set; }
        public float Temps { get; set; }
        public string Tache { get; set; }
        public string Nomutilisateur { get; set; }
        public string Projet { get; set; }
        
        [ForeignKey(typeof(ENT_Comptes))] 
        public int ENT_ComptesId { get; set; }
        [OneToOne] 
        public ENT_Comptes ENT_Comptes{ get; set; }
        
    }
}
