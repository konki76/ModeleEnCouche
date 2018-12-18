using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ModeleEnCouchePlanning.Models
{
    public class CategVenteDAO : AccesBD
    {
        public List<CategVente> listCategVente()
        {
            string query = "SELECT idCategVente, libelleCategVente FROM categvente;";
            // initialisation de la connexion
            Initialize();
            // création de la liste à retourner
            List<CategVente> categVente = new List<CategVente>();

            MySqlCommand cmd = new MySqlCommand(query, co);
            //crée un data reader et exécute la commande
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                //lit la liste et stocke les données dans la liste
                while (dataReader.Read())
                {
                    CategVente a = new CategVente();
                    a.idCategVente = dataReader["idCategVente"] == DBNull.Value ? string.Empty : dataReader["idCategVente"].ToString();
                    a.libelleCategVente = dataReader["libelleCategVente"] == DBNull.Value ? string.Empty : dataReader["libelleCategVente"].ToString();
                    categVente.Add(a);
                }
            }
            dataReader.Close();
            co.Close();

            //retourne la liste à afficher
            return categVente;
        }
        public CategVente idCategVente(string idCategVente)
        {

            string query = "SELECT idCategVente, libelleCategVente FROM categvente WHERE idCategVente = " + idCategVente;
            Initialize();
            CategVente categVente = new CategVente();

            MySqlCommand cmd = new MySqlCommand(query, co);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    categVente.idCategVente = dataReader["idCategVente"] == DBNull.Value ? string.Empty : dataReader["idCategVente"].ToString();
                    categVente.libelleCategVente = dataReader["libelleCategVente"] == DBNull.Value ? string.Empty : dataReader["libelleCategVente"].ToString();
                }
            }
            dataReader.Close();
            co.Close();
            return categVente;
        }

        public void categVenteDelete(string idCategVente)
        {
            string query = "DELETE FROM categvente WHERE idCategVente = " + idCategVente;
            nonQuery(query);
        }
        public void categVenteInsert(CategVente categVente)
        {
            string query = "INSERT INTO categvente(libelleCategVente) VALUES ('" + categVente.libelleCategVente + "');";
            nonQuery(query);
        }
        public void categVenteUpdate(CategVente categVente)
        {
            string query = "UPDATE categvente SET libelleCategVente = '" + categVente.libelleCategVente + "' WHERE idCategVente = " + categVente.idCategVente;
            nonQuery(query);
        }
    }
}