using SQLite;

namespace PréfacturationWiilog
{
    class ENT_Comptes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Filiale { get; set; }
        public string Nomclient { get; set; }
        public float Montantmensuel { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }
}
