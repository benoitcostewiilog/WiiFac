using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PréfacturationWiilog.Entities
{
    class ENT_Factures
    {
        public ENT_Comptes Client { get; set; }
        public DateTime Dateprefac { get; set; }
        public List<ENT_LigneFactures> Lignefac { get; set; }
        //public List<ENT>
        public float Montanttotal { get; set; }
        
    }
}
