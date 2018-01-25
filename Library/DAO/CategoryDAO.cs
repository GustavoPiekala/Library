using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.DAO
{
    public class CategoryDAO
    {
        private LibraryContext context;

        public CategoryDAO(LibraryContext context)
        {
            this.context = context;
        }

        public void Save(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public IList<Category> SearchAll()
        {
            return context.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category SearchById(int id)
        {
            return context.Categories.Find(id);
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public void SaveChanges(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}