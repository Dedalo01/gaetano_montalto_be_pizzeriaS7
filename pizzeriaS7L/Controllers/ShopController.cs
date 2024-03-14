using pizzeriaS7L.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace pizzeriaS7L.Controllers
{
    [Authorize(Roles = "Admin, User")]
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

        public ActionResult Cart()
        {
            PizzeriaContext ctx = new PizzeriaContext();

            List<OrdiniArticoli> articoliSessione = Session["listaArticoli"] as List<OrdiniArticoli> ?? new List<OrdiniArticoli>();


            var carrello = (from s in articoliSessione
                            join a in ctx.Articoli on s.ArticoloId equals a.Id
                            select new CartViewModel
                            {
                                NomeArticolo = a.Nome,
                                Prezzo = a.Prezzo,
                                Quantita = s.Quantita
                            }).ToList();

            Session["carrello"] = carrello;

            return View(carrello);
        }

        public ActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Order(Ordini nuovoOrdine)
        {

            try
            {
                //if (ModelState.IsValid)
                //{
                PizzeriaContext ctx = new PizzeriaContext();
                nuovoOrdine.UtenteId = Convert.ToInt32(User.Identity.Name);
                nuovoOrdine.DataOrdine = DateTime.Now;
                ctx.Ordini.Add(nuovoOrdine);
                ctx.SaveChanges();

                List<OrdiniArticoli> ordiniArticoli = Session["listaArticoli"] as List<OrdiniArticoli>;

                foreach (var ordineArticolo in ordiniArticoli)
                {
                    ordineArticolo.OrdineId = nuovoOrdine.Id;
                    ctx.OrdiniArticoli.Add(ordineArticolo);
                }

                ctx.SaveChanges();
                // Il tuo codice di salvataggio qui
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Debug.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                throw; // Rilancia l'eccezione per gestirla più avanti, se necessario
            }


            return RedirectToAction("Success", new { orderId = nuovoOrdine.Id });
            // }

            //return View(nuovoOrdine);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}