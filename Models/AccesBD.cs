using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ModeleEnCouchePlanning.Models
{
    public class AccesBD
    {
        private static string connect = "Server=127.0.0.1;Database=planning;Uid=root;Pwd=;";
        protected MySqlConnection co = new MySqlConnection(connect);

        protected void Initialize()
        {
            try { co.Open(); }
            catch (Exception e) { e.ToString(); }
        }
        protected void nonQuery(string query)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                co.Open();
                // Exécution d’une instruction en base de données
                MySqlCommand cmd = new MySqlCommand(query, co);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connexion impossible, raisons : " + ex);
            }
            finally
            {
                // Fermeture de la base de données
                try { co.Close(); }
                catch (MySqlException e) { Console.WriteLine(e); }
            }
        }
    }
}