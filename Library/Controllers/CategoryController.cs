using Library.DAO;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryDAO categoryDAO;

        public CategoryController(CategoryDAO categoryDAO)
        {
            this.categoryDAO = categoryDAO;
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Save(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryDAO.Save(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", category);
            }
        }

        public ActionResult Delete(int id)
        {

            Category category = SearchById(id);
            categoryDAO.Delete(category);

            return RedirectToAction("Index");
            
        }

        public ActionResult Index()
        {

            IList<Category> categories = categoryDAO.SearchAll();
            return View(categories);
        }

        public ActionResult Update(int id)
        {

            Category category = SearchById(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);

        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                
                categoryDAO.SaveChanges(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }

        }

        public Category SearchById(int id)
        {
            return categoryDAO.SearchById(id);
        }
    }
}