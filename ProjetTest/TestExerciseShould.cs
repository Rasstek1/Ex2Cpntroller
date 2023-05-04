using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnPetitProjet.Controllers;
using UnPetitProjet.Models;
using Xunit;

namespace ControllerTest
{
    public class TestExerciseShould
    {
        [Fact]
        public void TestBienvenue()//Test 1 succeed
        {
            // Arrange
            var exerciseController = new ExerciceController();

            // Act
            var result = exerciseController.Bienvenue();

            // Assert
            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.Equal("<h2>Bienvenue dans mon site web<h2>", contentResult.Content);
        }
        [Fact]
        public void TestBienvenue2()//Test 2 succeed
        {
            // Declare les variables pour le test unitaire
            var exerciseController = new ExerciceController();
            // Act veut dire appeler la méthode à tester
            var result = exerciseController.Bienvenue2();
            // Assert veut dire vérifier que le résultat est du type ContentResult
            var contentResult = Assert.IsType<ContentResult>(result);
            //Test le type de retour de la méthode
            string expectedContent = "<h2>Bienvenue dans mon site web de programmeur<h2>";
            string expectedContentType = "text/html";
            int expectedStatusCode = 200;
            //Test le type de retour de la méthode
            Assert.IsType<string>(contentResult.Content);
            Assert.IsType<string>(contentResult.ContentType);
            Assert.IsType<int>(contentResult.StatusCode); // Corrected this line
                                                          //Test le contenu de la méthode
            Assert.Equal(expectedContent, contentResult.Content);
            Assert.Equal(expectedContentType, contentResult.ContentType);
            Assert.Equal(expectedStatusCode, contentResult.StatusCode);
        }

        [Fact]

        public void TestIndex2()//Test 3 succeed 
        {
            // Arrange : préparer le test en instanciant le contrôleur
            var exerciseController = new ExerciceController();

            // Act : appeler la méthode d'action Index2 du contrôleur
            var result = exerciseController.Index2() as ViewResult;

            // Assert : vérifier que la vue renvoyée a le bon nom et le bon type
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.Equal("MaVue", viewResult.ViewName);
        }

        [Fact]
        public void GetFichierPdf_ReturnsFileResult()
        {
            // Arrange
            var exerciceController = new ExerciceController();
            var expectedFileName = "chemnement.pdf";
            var expectedContentType = "application/pdf";
            var expectedFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", expectedFileName);

            // Act
            var result = exerciceController.GetFichierPdf() as FileContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedContentType, result.ContentType);

            var actualFilePath = Path.GetFullPath(expectedFilePath);
            Assert.Equal(actualFilePath, result.FileDownloadName);

            var actualFileContent = System.IO.File.ReadAllBytes(actualFilePath);
            Assert.Equal(actualFileContent.Length, result.FileContents.Length);

            for (int i = 0; i < actualFileContent.Length; i++)
            {
                Assert.Equal(actualFileContent[i], result.FileContents[i]);
            }
        }





        [Fact]

        public void ListeClients()//Test 4 fail
        {
            // Arrange : préparer le test en instanciant le contrôleur
            var exerciseController = new ExerciceController();

            // Act : appeler la méthode d'action ListeClients du contrôleur
            var result = exerciseController.ListeClients() as JsonResult;//'as' test que le type de retour est bien un JsonResult

            // Assert : vérifier que le résultat renvoyé est bien un objet JsonResult avec un ContentType approprié et des données valides
            Assert.NotNull(result);
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult.ContentType);
            Assert.Equal("application/json", jsonResult.ContentType);
            var clients = jsonResult.Value as List<Client>;
            Assert.NotNull(clients);
            Assert.Equal(1, clients.Count);
            Assert.Equal(1, clients[0].Numero);
            Assert.Equal("Camara", clients[0].Nom);
            Assert.Equal("Oumar", clients[0].Prenom);
            Assert.Equal("oumar@gmail.com", clients[0].Courriel);
        }

        [Fact]
        public void TestRedirigeListeClient()//Test 5 succeed
        {
            // Arrange : préparer le test en instanciant le contrôleur
            var exerciseController = new ExerciceController();

            // Act : appeler la méthode d'action RedirigeListeClient du contrôleur
            var result = exerciseController.RedirigeListeClient() as RedirectToActionResult;

            // Assert : vérifier que le résultat renvoyé est bien une redirection vers l'action ListeClients
            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ListeClients", result.ActionName);



        }

    }
}

//EXEMPLE DE TESTS UNITAIRES  
/*using ControleursExercices.Controllers;
using ControleursExercices.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace ControleursExercicesTests.Controllers
{
    public class ControleursExercicesShould
    {

        [Fact]
        public void IndexShouldReturnViewResult()
        {
            var homeController = new HomeController();

            var result = homeController.Index();

            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void ShowTextString()
        {
            var homeController = new HomeController();

            var result = homeController.ShowText();

            var expectedResult = "<h2>Bienvenu dans mon site web</h2>";
            Assert.IsType<string>(result);
            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void ReturnContent()
        {
            var homeController = new HomeController();

            var result = homeController.SendContent();

            Assert.IsType<ContentResult>(result);

            var expectedContent = "<h2>Bienvenu dans mon site web</h2>";
            var content = Assert.IsType<string>(result.Content);
            Assert.Equal(expectedContent, content);

            var expectedContentType = "text/html";
            var contentType = Assert.IsType<string>(result.ContentType);
            Assert.Equal(expectedContentType, contentType);
        }


        [Fact]
        public void ReturnTextWithParamValues()
        {
            var homeController = new HomeController();

            string id = "1234";
            string name = "Dalicia";
            var result = homeController.TextWithParamValues(id, name);

            var expectedResult = "La valeur de id est : " + id + " et le nom est name = " + name;

            Assert.IsType<string>(result);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShowIndexView()
        {
            var homeController = new HomeController();

            var result = homeController.Index();

            var viewResult = Assert.IsAssignableFrom<ActionResult>(result);
        }


        [Fact]
        public void AfficherPdfShouldReturnVirtualFileResult()
        {
            var homeController = new HomeController();

            var result = homeController.AfficherPdf();

            Assert.IsType<VirtualFileResult>(result);

            var expectedFileName = @"~\Files\dummy.pdf";
            Assert.Equal(expectedFileName, result.FileName);

            var expectedContentType = "application/pdf";
            Assert.Equal(expectedContentType, result.ContentType);
        }

        [Fact]
        public void AfficherJsonShouldReturnJsonResult()
        {
            var homeController = new HomeController();

            var result = homeController.AfficherJson();

            Assert.IsType<JsonResult>(result);

            dynamic valueJson = result.Value;

            Client expectedClient1 = new Client(1, "N1", "P1", "np1@gmail.com");
            Client expectedClient2 = new Client(2, "N2", "P2", "np2@gmail.com");

            var jsonElement1 = valueJson[0];
            var jsonElement2 = valueJson[1];

            Assert.IsType<Client>(jsonElement1);
            Assert.IsType<Client>(jsonElement2);

            Assert.Equal<int>(jsonElement1.Numero, expectedClient1.Numero);
            Assert.Equal(jsonElement1.Nom, expectedClient1.Nom);
            Assert.Equal(jsonElement1.Prenom, expectedClient1.Prenom);
            Assert.Equal(jsonElement1.Courriel, expectedClient1.Courriel);

            Assert.Equal<int>(expectedClient2.Numero, jsonElement2.Numero);
            Assert.Equal(expectedClient2.Nom, jsonElement2.Nom);
            Assert.Equal(expectedClient2.Prenom, jsonElement2.Prenom);
            Assert.Equal(expectedClient2.Courriel, jsonElement2.Courriel);
        }

        [Fact]
        public void RedirigerShouldReturnStringActionResult()
        {
            var homeController = new HomeController();

            var result = homeController.RedirectToShowText();
            var viewResult = Assert.IsType<RedirectToActionResult>(result);

            var expectedActionName = "ShowText";
            var actionName = Assert.IsType<string>(viewResult.ActionName);
            Assert.Equal(expectedActionName, actionName);
        }
    }
}

*/