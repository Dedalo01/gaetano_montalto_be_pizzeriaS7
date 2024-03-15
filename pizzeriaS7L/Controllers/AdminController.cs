using pizzeriaS7L.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pizzeriaS7L.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            PizzeriaContext ctx = new PizzeriaContext();

            var ordiniEffettuati = ctx.Ordini.Include("Utenti").ToList();

            return View(ordiniEffettuati);
        }

        [HttpPost]
        public ActionResult Index(int orderId)
        {
            PizzeriaContext ctx = new PizzeriaContext();
            var ordineEvaso = ctx.Ordini.Find(orderId);
            ordineEvaso.IsCompleto = "EVASO";
            ctx.Entry(ordineEvaso).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(Articoli nuovoArticolo, HttpPostedFileBase Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto != null && Foto.ContentLength > 0)
                {
                    string nomeFotoUnivoco = Guid.NewGuid().ToString() + "_" + Path.GetFileNameWithoutExtension(Foto.FileName) + Path.GetExtension(Foto.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Assets/uploads"), nomeFotoUnivoco);
                    Foto.SaveAs(filePath);

                    nuovoArticolo.Foto = nomeFotoUnivoco;
                }

                PizzeriaContext ctx = new PizzeriaContext();

                ctx.Articoli.Add(nuovoArticolo);
                ctx.SaveChanges();

                TempData["AddArticleSuccess"] = "Il nuovo Articolo è stato aggiunto correttamente.";
                return RedirectToAction("AddArticle");
            }
            return View(nuovoArticolo);
        }


        public JsonResult GetOrderSummary(DateTime date)
        {
            var startDate = date.Date;
            var endDate = startDate.AddDays(1);
            PizzeriaContext context = new PizzeriaContext();


            var totalCompletedOrders = context.Ordini
                .Count(o => o.DataOrdine >= startDate && o.DataOrdine < endDate && o.IsCompleto == "EVASO");

            decimal totalRevenue = 0;

            var ordersInRange = context.Ordini
    .Where(o => o.DataOrdine >= startDate && o.DataOrdine < endDate && o.IsCompleto == "EVASO");

            if (ordersInRange.Any())
            {
                totalRevenue = context.Ordini
                    .Where(o => o.DataOrdine >= startDate && o.DataOrdine < endDate && o.IsCompleto == "EVASO")
                    .SelectMany(o => o.OrdiniArticoli)
                    .Sum(oa => oa.Articoli.Prezzo * oa.Quantita);
            }

            return Json(new { totalCompletedOrders, totalRevenue }, JsonRequestBehavior.AllowGet);
        }
    }
}