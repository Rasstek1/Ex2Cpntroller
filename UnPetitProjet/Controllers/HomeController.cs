using Microsoft.AspNetCore.Mvc;

namespace UnPetitProjet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
                return View("Erreur");
            else
            {
                ViewData["Nom"] = id;
                return View("Index");
            }  
        }
    }
}
