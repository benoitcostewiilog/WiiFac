using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace PréfacturationWiilog.Entities
{
    class ENT_OrderL
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public float Montant { get; set; }
    }
}
