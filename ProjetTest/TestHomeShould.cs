using Microsoft.AspNetCore.Mvc;
using UnPetitProjet.Controllers;

namespace ProjetTest
{
    public class TestHomeShould
    {
        [Fact]
        public void Test1()
        {
            //test pour tester HomeController avec un id null
            var controller = new HomeController();
            var result = controller.Index(null);
            Assert.IsType<ViewResult>(result);
        }

   
    }
}