using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
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
        public void TestBienvenue()//succeed
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
        public void TestBienvenue2()//succeed
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

        public void TestIndex2()//succeed
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

        public void ListeClients()//fail
        {
            // Arrange : préparer le test en instanciant le contrôleur
            var exerciseController = new ExerciceController();

            // Act : appeler la méthode d'action ListeClients du contrôleur
            var result = exerciseController.ListeClients() as JsonResult;

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
        public void TestRedirigeListeClient()//succeed
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





