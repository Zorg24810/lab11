using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1.Extensions;
using lab1.Models;
using Microsoft.AspNetCore.Mvc;
using WebLabsV05.Entities;
using WebLabsV05.DAL.Data;
using Microsoft.Extensions.Logging;

namespace lab1.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo=1)
        {
            //var groupName = group.HasValue? _context.AutoGroups.Find(group.Value)?.GroupName: "all groups";
            //_logger.LogInformation($"info: group={group}, page={pageNo}");
            var autosFiltered = _context.Autos.Where(d => !group.HasValue || d.AutoGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.AutoGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Auto>.GetModel(autosFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }

        //private ILogger _logger;
        //public ProductController(ApplicationDbContext context,
        //ILogger<ProductController> logger)
        //{
        //    _pageSize = 3;
        //    _context = context;
        //    _logger = logger;
        //}
      

    }
}