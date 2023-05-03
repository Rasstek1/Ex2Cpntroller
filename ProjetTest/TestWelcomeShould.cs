using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnPetitProjet.Controllers;

namespace ControllerTest
{
    internal class TestWelcomeShould
    {
        public void Test2()
        {
            //test pour tester WelcomeController qui retourne Content
            var controller = new WelcomeController();
            var result = controller.WelcomeDefault();
            Assert.IsType<ContentResult>(result);
        }
    }
}
