using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FruitStore.Models;
using Microsoft.AspNetCore.Identity;

namespace FruitStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //Responds on GET /Account/Register

        public IActionResult Register()
        {
            return View();
        }

        //Responds on POST /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string username, string password)
        {

            return Ok();

        }


    }
}