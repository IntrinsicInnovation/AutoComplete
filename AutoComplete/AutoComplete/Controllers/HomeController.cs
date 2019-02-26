using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoComplete.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace AutoComplete.Controllers
{
    public class HomeController : Controller
    {

        private IEnumerable<UserViewModel> _Users;

        public HomeController()
        {
            _Users = new List<UserViewModel>
            {
                new UserViewModel
                {
                     UserName = "JohnDoe",
                     UserId = "1",
                     Email = "Johndoe@company.com",
                     FirstName = "John",
                     LastName = "Doe",
                },

                new UserViewModel
                {
                     UserName = "JohnFrank",
                     UserId = "2",
                     Email = "Johnfrank@company.com",
                     FirstName = "John",
                     LastName = "Frank",
                },


                new UserViewModel
                {
                     UserName = "SamSmith",
                     UserId = "3",
                     Email = "Samsmith@company.com",
                     FirstName = "Sam",
                     LastName = "Smith",
                },

                new UserViewModel
                {
                     UserName = "FrankSmith",
                     UserId = "4",
                     Email = "Franksmith@company.com",
                     FirstName = "Frank",
                     LastName = "Smith",
                }
            };
        }

        public IActionResult Index()
        {

         
            return View(new AutoCompleteViewModel());
        }




        [HttpGet]
        public DataSourceResult GetUsers([DataSourceRequest] DataSourceRequest request, string text)
        {
            var users = GetUsersByUserName(text);
            return users.ToDataSourceResult(request);
        }


        private IEnumerable<UserViewModel> GetUsersByUserName(string text)
        {
            var userlist = _Users.Where(u => u.UserName.ToLower().Contains(text.ToLower()));
            return userlist;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
