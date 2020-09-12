

using SQLite;

namespace PréfacturationWiilog
{
    class ENT_Company
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
