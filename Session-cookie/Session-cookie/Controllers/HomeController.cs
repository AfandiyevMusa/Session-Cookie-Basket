using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session_cookie.Models;


namespace Session_cookie.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        //HttpContext.Session.SetInt32("age", 20);
        //HttpContext.Session.SetString("name", "Musa");

        //Response.Cookies.Append("surname", "Afandiyev");
        //Response.Cookies.Append("surname", "Afandiyev", new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) });

        //Book book1 = new()
        //{
        //    Id = 1,
        //    Name = "Sevil",
        //    Author = "Cefer Cabbarli"
        //};
        //var serializedObject = JsonSerializer.Serialize(book1);
        //HttpContext.Session.SetString("book", serializedObject);
        if(HttpContext.Session.GetString("user") != null)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            ViewBag.email = user.Email;
        }
        return View();
    }

    public IActionResult Privacy()
    {
        //ViewBag.age = HttpContext.Session.GetInt32("age");
        //ViewBag.name = HttpContext.Session.GetString("name");

        //ViewBag.surname = Request.Cookies["surname"];

        //Book model = JsonSerializer.Deserialize<Book>(HttpContext.Session.GetString("book"));
        //return View(model);
        return View();
    }
}

//class Book
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public string Author { get; set; }
//}

