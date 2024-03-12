using pizzeriaS7L.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace pizzeriaS7L.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Username, Password")] Utenti utente)
        {
            if (ModelState.IsValid)
            {
                PizzeriaContext context = new PizzeriaContext();
                var utenteRegistrato = context.Utenti
                    .Where(m => m.Email == utente.Email && m.Username == utente.Username && m.Password == utente.Password)
                    .FirstOrDefault();

                if (utenteRegistrato != null)
                {
                    FormsAuthentication.SetAuthCookie(utenteRegistrato.Id.ToString(), true);
                    switch (utenteRegistrato.RuoloId)
                    {
                        case 1: // admin
                            TempData["Success"] = $"UTENTE REGISTRATO ID ADMIN {utenteRegistrato.Id}";
                            return RedirectToAction("Index", "Admin");
                        case 2: // utenti
                            TempData["Success"] = $"UTENTE REGISTRATO ID {utenteRegistrato.Id}";

                            return RedirectToAction("Index", "Shop");
                            // altri ruoli eventuali
                    }
                }
            }

            return View(utente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}