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
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO create an account and log this user in
                return RedirectToAction("Index", "Home");
            }

            return View();

        }


    }
}