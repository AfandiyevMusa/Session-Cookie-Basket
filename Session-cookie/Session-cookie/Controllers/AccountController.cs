using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session_cookie.Models;
using Session_cookie.ViewModels;

namespace Session_cookie.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM model)
        {
            List<User> dbUsers = GetAll();

            var findUserByEmail = dbUsers.FirstOrDefault(m => m.Email == model.Email);

            if (findUserByEmail == null)
            {
                ViewBag.error = "Email or password is wrong!";
                return View();
            }

            if(findUserByEmail.Password != model.Password)
            {
                ViewBag.error = "Email or password is wrong!";
                return View();
            }

            HttpContext.Session.SetString("user", JsonSerializer.Serialize(findUserByEmail));

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            //return RedirectToAction("Home", "Index");
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        private List<User> GetAll()
        {
            User user1 = new()
            {
                Id = 1,
                UserName = "musa123",
                Email = "musa@gmail.com",
                Password = "musa123"
            };

            User user2 = new()
            {
                Id = 2,
                UserName = "resul123",
                Email = "resul@gmail.com",
                Password = "resul123"
            };

            User user3 = new()
            {
                Id = 3,
                UserName = "mahir123",
                Email = "mahir@gmail.com",
                Password = "mahir123"
            };

            List<User> users = new() { user1, user2, user3 };
            return users;
        }
    }
}

