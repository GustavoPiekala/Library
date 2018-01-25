using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.DAO
{
    public class BookDAO
    {
        private LibraryContext context;

        public BookDAO(LibraryContext context)
        {
            this.context = context;
        }

        public void Save(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public IList<Book> SearchBooks(string title)
        {

            var query = context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            return query.OrderBy(b => b.Title).ToList(); ;
            
        }

        public Book SearchById(int id)
        {
            return context.Books.Find(id);
        }

        public void Delete(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }

        public void SaveChanges(Book book)
        {

            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}