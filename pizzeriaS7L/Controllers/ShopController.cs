using pizzeriaS7L.Models;
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
        public ActionResult Shop()
        {
            return View();
        }
    }
}