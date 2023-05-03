using Microsoft.AspNetCore.Mvc;
using UnPetitProjet.Models;

namespace UnPetitProjet.Controllers
{
    public class ExerciceController : Controller
    {
        public IActionResult Bienvenue()
        {
            string texte = "<h2>Bienvenue dans mon site web<h2>";
            return Content(texte);
        }
        public ContentResult Bienvenue2()
        {
            string texte = "<h2>Bienvenue dans mon site web de programmeur<h2>";
            string contentType = "text/html";
            int statusCode = 200;
            return new ContentResult
            {
                Content = texte,
                ContentType = contentType,
                StatusCode = statusCode,
            };

        }
        public IActionResult Index2()
        {

            return View("MaVue");
        }
        public IActionResult GetFichierPdf()
        {
            string chemin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf/chemnement.pdf");
            if (!System.IO.File.Exists(chemin))
            {
                return NotFound();
                //return View("Erreur");
            }
            byte[] fichier = System.IO.File.ReadAllBytes(chemin);
            return File(fichier, "application/pdf");
        }
        public IActionResult ListeClients()
        {
            var clients = new List<Client>
            {
                new Client(1,"Camara","Oumar","oumar@gmail.com")
            };

            return Json(clients);
        }
        public IActionResult RedirigeListeClient()
        {

            return RedirectToAction("ListeClients");
        }

    }
}
