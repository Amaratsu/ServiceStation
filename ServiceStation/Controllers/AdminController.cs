using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Model;

namespace ServiceStation.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private CarContext db;

        public AdminController(CarContext carContext)
        {
            db = carContext;
        }

        public ActionResult Index(string searchString)
        {
            var card = from c in db.Cards select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                card = card.Where(x => x.FirstName.Contains(searchString));
                
            }
            return View(card);
        }

        //public ViewResult Index()
        //{
        //    return View(db.Cards);
        //}

        public ActionResult Description(int id)
        {
            return View("Description", db.Cards.FirstOrDefault(c => c.Id == id));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Card card = db.Cards.Find(id);
            if (card != null)
            {
                return View(card);
            }
            return null;
        }

        [HttpPost]
        public ActionResult Edit(Card card)
        {
            db.Entry(card).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Card card)
        {
            db.Cards.Add(card);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public Card Delete(int id)
        {
            Card deleteCard = db.Cards.Find(id);
            if (deleteCard != null)
            {
                db.Cards.Remove(deleteCard);
                db.SaveChanges();
            }
            return deleteCard;
        }

        public ActionResult Index2()
        {
            return View(db.Cars.ToList());
        }
    }
}