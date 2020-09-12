using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace PréfacturationWiilog.Entities
{
    class ENT_OrderH
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public float TotalHT { get; set; }
    }
}
