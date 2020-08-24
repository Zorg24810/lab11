using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Text"] = "Лабораторная работа 2";
            ViewData["Lst"] = new SelectList(_listDemo, "ListItemValue", "ListItemText");
            return View();
        }
        private List<ListDemo> _listDemo;
        public HomeController()
        {
            _listDemo = new List<ListDemo>
            {
                new ListDemo{ ListItemValue=1, ListItemText="Элемент 1"},
                new ListDemo{ ListItemValue=2, ListItemText="Элемент 2"},
                new ListDemo{ ListItemValue=3, ListItemText="Элемент 3"},
                new ListDemo{ ListItemValue=4, ListItemText="Элемент 4"}
             };
        }

    }  

}
