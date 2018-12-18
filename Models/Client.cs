using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModeleEnCouchePlanning.Models
{
    public class Client
    {
        public string idClient { get; set; }
        public string nom { get; set; }        
        public Client() { }
        public Client(string idClient, string nom)
        {
            this.idClient = idClient;
            this.nom = nom;
        }
        public Client(string nom)
        {
            this.nom = nom;
        }
    }
}