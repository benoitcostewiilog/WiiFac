using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PréfacturationWiilog.Entities
{
    class ENT_LigneFactures
    {
        public string Description { get; set; }
        public int Quantite { get; set; }
        public float PrixUnitaire { get; set; }
        public float TotalLigne { get; set; }
    }
}
