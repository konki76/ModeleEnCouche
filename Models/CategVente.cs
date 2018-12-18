using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModeleEnCouchePlanning.Models
{
    public class CategVente
    {
        public string idCategVente { get; set; }
        public string libelleCategVente { get; set; }

        public CategVente() { }
        public CategVente(string idCategVente, string libelleCategVente)
        {
            this.idCategVente = idCategVente;
            this.libelleCategVente = libelleCategVente;
        }
        public CategVente(string libelleCategVente)
        {
            this.libelleCategVente = libelleCategVente;
        }
    }
}