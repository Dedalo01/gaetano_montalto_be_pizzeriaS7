using pizzeriaS7L.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace pizzeriaS7L.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            PizzeriaContext context = new PizzeriaContext();

            var listaPizze = context.Articoli.ToList();


            return View(listaPizze);
        }

        [HttpPost]
        public ActionResult Index(int articoloId, int quantita, string articoloNome)
        {
            List<OrdiniArticoli> articoli = Session["listaArticoli"] as List<OrdiniArticoli> ?? new List<OrdiniArticoli>();

            OrdiniArticoli nuovoOrdineArticolo = new OrdiniArticoli
            {
                ArticoloId = articoloId,
                Quantita = quantita
            };

            articoli.Add(nuovoOrdineArticolo);

            Session["listaArticoli"] = articoli;


            TempData["AddSuccess"] = quantita > 1 ? $"Sono state aggiunte correttamente {quantita} {articoloNome}!" : $"E' stata aggiunta correttamente {quantita} {articoloNome}";
            return RedirectToAction("Index");
        }

        public ActionResult Shop()
        {
            return View();
        }
    }
}