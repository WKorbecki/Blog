using Blog.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    /*public class Portfolio
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date_Create { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }

        public Portfolio()
        {

        }
        public Portfolio(int id, string title, DateTime date_create, string type, string language)
        {
            this.Id = id;
            this.Title = title;
            this.Date_Create = date_create;
            this.Type = type;
            this.Language = language;
        }
    }*/
    public class PortfolioController : Controller
    {
        // GET: Admin/Portfolio
        private Portfolio PortfolioModel;
        public ActionResult Index()
        {
            /*var portfolio = new List<Portfolio>();
            portfolio.Add(new Portfolio(1, "Praca inżynierska", new DateTime(2016, 01, 01), "Gra", "C#"));
            portfolio.Add(new Portfolio(2, "Praca magisterska", new DateTime(2017, 06, 01), "Aplikacja desktopowa", "Matlab"));
            ViewBag.projects = portfolio;*/
            PortfolioModel = new Portfolio();
            var portfolio = PortfolioModel.GetAll();
            //var portfolio = PortfolioModel.Get(1);
            return View(portfolio);
        }
        
        public ActionResult Create()
        {
            return View(new Portfolio());
        }

        [HttpPost]
        public ActionResult Create(Portfolio portfolio)
        {
            //PortfolioModel.Insert(portfolio);
            portfolio.Insert();
            return RedirectToAction("Index", "Portfolio");
        }
    }
}