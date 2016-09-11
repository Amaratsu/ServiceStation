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

        //public ActionResult IndexCar()
        //{
        //    return View(db.Cars.ToList());
        //}

        public ActionResult EditCar(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Car car = db.Cars.Find(id);
            if (car != null)
            {
                return View(car);
            }
            return null;
        }

        [HttpPost]
        public ActionResult EditCar(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexCar");
        }

        [HttpGet]
        public ActionResult CreateCar()
        {
            return View("IndexCar");
        }
        [HttpPost]
        public ActionResult CreateCar(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
            return RedirectToAction("IndexCar");
        }

        [HttpPost]
        public Car DeleteCar(int id)
        {
            Car deleteCar = db.Cars.Find(id);
            if (deleteCar != null)
            {
                db.Cars.Remove(deleteCar);
                db.SaveChanges();
            }
            return deleteCar;
        }

        public ActionResult IndexCar(string searchString)
        {
            var car = from c in db.Cars select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                car = car.Where(x => x.Make.Contains(searchString));

            }
            return View(car);
        }
    }
}