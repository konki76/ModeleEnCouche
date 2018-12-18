using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModeleEnCouchePlanning.Models
{
    public class Vente
    {
        public string idVente { get; set; }
        public string marchandise { get; set; }
        public string nbVente { get; set; }
        public string idCategVente { get; set; }

        public Vente() { }
        public Vente(string idVente, string marchandise, string nbVente, string idCategVente)
        {
            this.idVente = idVente;
            this.marchandise = marchandise;
            this.nbVente = nbVente;
            this.idCategVente = idCategVente;
        }
        public Vente (string marchandise, string nbVente, string idCategVente)
        {
            this.marchandise = marchandise;
            this.nbVente = nbVente;
            this.idCategVente = idCategVente;
        }
    }
}