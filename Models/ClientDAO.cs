using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ModeleEnCouchePlanning.Models
{
    public class ClientDAO : AccesBD
    {
        public List<Client> listClient()
        {
            string query = "SELECT idClient, nom FROM client;";
            // initialisation de la connexion
            Initialize();
            // création de la liste à retourner
            List<Client> client = new List<Client>();

            MySqlCommand cmd = new MySqlCommand(query, co);
            //crée un data reader et exécute la commande
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                //lit la liste et stocke les données dans la liste
                while (dataReader.Read())
                {
                    Client a = new Client();
                    a.idClient = dataReader["idClient"] == DBNull.Value ? string.Empty : dataReader["idClient"].ToString();
                    a.nom = dataReader["nom"] == DBNull.Value ? string.Empty : dataReader["nom"].ToString();
                    client.Add(a);
                }
            }
            dataReader.Close();
            co.Close();

            //retourne la liste à afficher
            return client;
        }
        public Client idClient(string idClient)
        {
            
            string query = "SELECT idClient, nom FROM client WHERE idClient = "+ idClient;
            Initialize();
            Client client = new Client();

            MySqlCommand cmd = new MySqlCommand(query, co);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    client.idClient = dataReader["idClient"] == DBNull.Value ? string.Empty : dataReader["idClient"].ToString();
                    client.nom = dataReader["nom"] == DBNull.Value ? string.Empty : dataReader["nom"].ToString();
                }
            }
            dataReader.Close();
            co.Close();
            return client;
        }

        public void clientDelete(string idClient)
        {
            string query = "DELETE FROM client WHERE idClient = " + idClient;
            nonQuery(query);
        }
        public void clientInsert(Client client)
        {
            string query = "INSERT INTO client(nom) VALUES ('" + client.nom + "');";
            nonQuery(query);
        }
        public void clientUpdate(Client client)
        {
            string query = "UPDATE client SET nom = '" + client.nom + "' WHERE idClient = " + client.idClient;
            nonQuery(query);
        }
    }    
}