using Microsoft.AspNetCore.Mvc;

namespace UnPetitProjet.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult WelcomeDefault()
        {
            return Content("Bienvenue sur mon site");
        }
        public IActionResult WelcomeName(string prenom, string nom)
        {
            if (prenom != null || nom != null)
            {
                ViewData["prenom"] = prenom;
                ViewData["nom"] = nom;
                return View("Welcome");

            }
            else
            {
                return View("Erreur");
            }



        }
    }
}
