using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;using MySql.Data.MySqlClient;

namespace ModeleEnCouchePlanning.Models
{
    public class VenteDAO : AccesBD
    {
        public List<Vente> listVente()
        {
            string query = "SELECT idVente, marchandise, nbVente, C.libelleCategVente AS idCategVente FROM vente V INNER JOIN categvente C ON(V.idCategVente = C.idCategvente);";
            // initialisation de la connexion
            Initialize();
            // création de la liste à retourner
            List<Vente> vente = new List<Vente>();

            MySqlCommand cmd = new MySqlCommand(query, co);
            //crée un data reader et exécute la commande
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                //lit la liste et stocke les données dans la liste
                while (dataReader.Read())
                {
                    Vente a = new Vente();
                    a.idVente = dataReader["idVente"] == DBNull.Value ? string.Empty : dataReader["idVente"].ToString();
                    a.marchandise = dataReader["marchandise"] == DBNull.Value ? string.Empty : dataReader["marchandise"].ToString();
                    a.nbVente = dataReader["nbVente"] == DBNull.Value ? string.Empty : dataReader["nbVente"].ToString();
                    a.idCategVente = dataReader["idCategVente"] == DBNull.Value ? string.Empty : dataReader["idCategVente"].ToString();
                    vente.Add(a);
                }
            }
            dataReader.Close();
            co.Close();

            //retourne la liste à afficher
            return vente;
        }
        public Vente idVente(string idVente)
        {

            string query = "SELECT idVente, marchandise, nbvente, idCategVente FROM vente WHERE idVente = " + idVente;
            Initialize();
            Vente vente = new Vente();

            MySqlCommand cmd = new MySqlCommand(query, co);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    vente.idVente = dataReader["idVente"] == DBNull.Value ? string.Empty : dataReader["idVente"].ToString();
                    vente.marchandise = dataReader["marchandise"] == DBNull.Value ? string.Empty : dataReader["marchandise"].ToString();
                    vente.nbVente = dataReader["nbVente"] == DBNull.Value ? string.Empty : dataReader["nbVente"].ToString();
                    vente.idCategVente = dataReader["idCategVente"] == DBNull.Value ? string.Empty : dataReader["idCategVente"].ToString();
                }
            }
            dataReader.Close();
            co.Close();
            return vente;
        }

        public void venteDelete(string idVente)
        {
            string query = "DELETE FROM vente WHERE idVente = " + idVente;
            nonQuery(query);
        }
        public void venteInsert(Vente vente)
        {
            string query = "INSERT INTO vente(marchandise, nbVente, idCategVente) VALUES ('" + vente.marchandise + "', '"+vente.nbVente+"', '"+vente.idCategVente+"');";
            nonQuery(query);
        }
        public void venteUpdate(Vente vente)
        {
            string query = "UPDATE vente SET marchandise = '" + vente.marchandise + "', nbVente = '"+vente.nbVente+ "', '" + vente.idCategVente + "' WHERE idVente = " + vente.idVente;
            nonQuery(query);
        }
    }
}