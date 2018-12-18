using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModeleEnCouchePlanning.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ClientView()
        {
            Models.ClientDAO c = new Models.ClientDAO();

            // supression d'un client
            if (Request.QueryString["idClient"] != null)
            {
                string idClient = String.Format("{0}", Request.QueryString["idClient"]);
                c.clientDelete(idClient);
            }
            // insertion d'un client
            if (Request.Form["Ajouter"] == "Ajouter" && Request.Form["nom"] != null)
            {
                string nom = String.Format("{0}", Request.Form["nom"]);
                Models.Client client = new Models.Client(nom);
                c.clientInsert(client);
            }
            // modification d'un client
            if (Request.Form["Modifier"] == "Modifier" && Request.Form["idClient"] != null && Request.Form["nom"] != null)
            {
                string idClient = String.Format("{0}", Request.Form["idClient"]);
                string nom = String.Format("{0}", Request.Form["nom"]);
                Models.Client client = new Models.Client(idClient, nom);
                c.clientUpdate(client);
            }

            ViewData["Clients"] = c.listClient();
            return View();
        }
        public ActionResult ClientModifView()
        {
            if (Request.QueryString["idClient"] != null)
            {
                string idClient = Request.QueryString["idClient"];
                Models.Client client = new Models.Client();
                Models.ClientDAO c = new Models.ClientDAO();
                client = c.idClient(idClient);

                ViewData["idClient"] = client.idClient;
                ViewData["nomClient"] = client.nom;
            }
            return View();
        }

        public ActionResult CategVenteView()
        {
            Models.CategVenteDAO c = new Models.CategVenteDAO();

            // supression d'une categVente
            if (Request.QueryString["idCategVente"] != null)
            {
                string idCategVente = String.Format("{0}", Request.QueryString["idCategVente"]);
                c.categVenteDelete(idCategVente);
            }
            // insertion d'une categVente
            if (Request.Form["Ajouter"] == "Ajouter" && Request.Form["libelleCategVente"] != null)
            {
                string libelleCategVente = String.Format("{0}", Request.Form["libelleCategVente"]);
                Models.CategVente categVente = new Models.CategVente(libelleCategVente);
                c.categVenteInsert(categVente);
            }
            // modification d'une categVente
            if (Request.Form["Modifier"] == "Modifier" && Request.Form["idCategVente"] != null && Request.Form["libelleCategVente"] != null)
            {
                string idCategVente = String.Format("{0}", Request.Form["idCategVente"]);
                string libelleCategVente = String.Format("{0}", Request.Form["libelleCategVente"]);
                Models.CategVente categVente = new Models.CategVente(idCategVente, libelleCategVente);
                c.categVenteUpdate(categVente);
            }

            ViewData["CategVentes"] = c.listCategVente();
            return View();
        }
        public ActionResult CategVenteModifView()
        {
            if (Request.QueryString["idCategVente"] != null)
            {
                string idCategVente = Request.QueryString["idCategVente"];
                Models.CategVente vente = new Models.CategVente();
                Models.CategVenteDAO c = new Models.CategVenteDAO();
                vente = c.idCategVente(idCategVente);

                ViewData["idCategVente"] = vente.idCategVente;
                ViewData["libelleCategVente"] = vente.libelleCategVente;
            }
            return View();
        }
        public ActionResult VenteView()
        {
            Models.VenteDAO c = new Models.VenteDAO();
            Models.CategVenteDAO cv = new Models.CategVenteDAO();

            // supression d'une Vente
            if (Request.QueryString["idVente"] != null)
            {
                string idVente = String.Format("{0}", Request.QueryString["idVente"]);
                c.venteDelete(idVente);
            }
            // insertion d'une Vente
            if (Request.Form["Ajouter"] == "Ajouter" && Request.Form["marchandise"] != null)
            {
                string marchandise = String.Format("{0}", Request.Form["marchandise"]);
                string nbVente = String.Format("{0}", Request.Form["nbVente"]);
                string idCategVente = String.Format("{0}", Request.Form["idCategVente"]);
                Models.Vente Vente = new Models.Vente(marchandise, nbVente, idCategVente);
                c.venteInsert(Vente);
            }
            // modification d'une Vente
            if (Request.Form["Modifier"] == "Modifier" && Request.Form["idVente"] != null && Request.Form["marchandise"] != null)
            {
                string idVente = String.Format("{0}", Request.Form["idVente"]);
                string marchandise = String.Format("{0}", Request.Form["marchandise"]);
                string nbVente = String.Format("{0}", Request.Form["nbVente"]);
                string idCategVente = String.Format("{0}", Request.Form["idCategVente"]);
                Models.Vente Vente = new Models.Vente(idVente, marchandise, nbVente, idCategVente);
                c.venteUpdate(Vente);
            }
            ViewData["CategVentes"] = cv.listCategVente();
            ViewData["Ventes"] = c.listVente();
            return View();
        }
        public ActionResult VenteModifView()
        {
            if (Request.QueryString["idVente"] != null)
            {
                string idVente = Request.QueryString["idVente"];
                Models.Vente vente = new Models.Vente();
                Models.VenteDAO c = new Models.VenteDAO();
                vente = c.idVente(idVente);

                ViewData["idVente"] = vente.idVente;
                ViewData["marchandise"] = vente.marchandise;
                ViewData["nbVente"] = vente.nbVente;
                ViewData["idCategVente"] = vente.idCategVente;
            }
            return View();
        }
    }
}