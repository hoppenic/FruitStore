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

        SignInManager<FruitStoreUser> _signInManager;

        //using Microsoft.aspnet.core.identity
        //this is a constructor
        public AccountController(SignInManager<FruitStoreUser> signInManager)
        {
            _signInManager = signInManager; 
        }

        
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
                FruitStoreUser newUser = new FruitStoreUser();

                IdentityResult creationResult = _signInManager.UserManager.CreateAsync(newUser).Result;
                if (creationResult.Succeeded)
                {
                    IdentityResult passwordResult = _signInManager.UserManager.AddPasswordAsync(newUser, model.Password).Result;
                    if (passwordResult.Succeeded)
                    {
                        _signInManager.SignInAsync(newUser, false).Wait();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in creationResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }

            return View();
        }

        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        //responds on GET
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                FruitStoreUser existingUser = _signInManager.UserManager.FindByNameAsync(model.UserName).Result;
                if(existingUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult passwordResult = _signInManager.CheckPasswordSignInAsync(existingUser, model.Password, false).Result;
                    if (passwordResult.Succeeded)
                    {
                        _signInManager.SignInAsync(existingUser, false).Wait();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("PasswordIncorrect", "Username or password is incorrect");
                    }
                }
                else
                {
                    ModelState.AddModelError("UserDoesNotExist", "Username or password is incorrect");
                }
            }
            return View();

        }


    }
}