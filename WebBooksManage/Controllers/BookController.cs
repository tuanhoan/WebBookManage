using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBooksManage.Models;

namespace WebBookManage.Controllers
{
    public class BookController : Controller
    {
        BookContext db = new BookContext();
        // GET: Book
        public ActionResult Index()
        {
            List<Book> books = new List<Book>();
            books = db.Books.ToList();
            return View(books);
        }
        [Authorize]
        public ActionResult Buy(int Id)
        {
            Book book = db.Books.SingleOrDefault(x => x.Id == Id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Book book, FormCollection collection)
        {
            var Id = collection["Id"];
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return this.Create();
        }
        [Authorize]
        public ActionResult Details(int Id)
        {
            Book book = db.Books.First(x => x.Id == Id);
            return View(book);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var b = db.Books.First(m => m.Id == id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var b = db.Books.First(m => m.Id == id);
            if (b != null)
            {
                UpdateModel(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var b = db.Books.First(m => m.Id == id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var b = db.Books.Where(x => x.Id == id).First();
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}