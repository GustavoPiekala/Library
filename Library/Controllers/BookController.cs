using Library.DAO;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private BookDAO bookDAO;
        private CategoryDAO categoryDAO;

        public BookController(BookDAO bookDAO, CategoryDAO categoryDAO)
        {
            this.bookDAO = bookDAO;
            this.categoryDAO = categoryDAO;
        }

        public ActionResult Form()
        {
            ViewBag.Category = categoryDAO.SearchAll();
            return View();
        }

        public ActionResult Save(Book book)
        {

            if (book.CategoryId == 0)
            {
                ModelState.AddModelError("no.CategoryId", "Cadastre Primeiramente uma Categoria.");
            }

            if(ModelState.IsValid){
                bookDAO.Save(book);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Category = SearchAllCategories();
                return View("Form", book);
            }
        }

        public ActionResult Index(string titleBook)
        {
            IList<Book> books = bookDAO.SearchBooks(titleBook);
            return View(books);
        }

        public Book SearchById(int id)
        {
            return bookDAO.SearchById(id);
        }

        public ActionResult Delete(int id)
        {
            bookDAO.Delete(SearchById(id));
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {

            ViewBag.Category = SearchAllCategories();
            Book book = SearchById(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Update(Book book) 
        {

            if (ModelState.IsValid)
            {
                bookDAO.SaveChanges(book);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Category = SearchAllCategories();
                return View(book);
            }
            
        }

        public ActionResult ViewBook(int id)
        {

            return View(bookDAO.SearchById(id));
        }

        public IList<Category> SearchAllCategories()
        {
            return categoryDAO.SearchAll();
        }

    }
}