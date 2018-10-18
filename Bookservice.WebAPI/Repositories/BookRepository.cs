using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.DTO;
using Bookservice.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class BookRepository
    {
        //context nodig om zaken weg te schrijven of toe te voegen
        private BookServiceContext bookServiceContext;
        //geef context mee zodat ik weet naar waar moet opslaan
        public BookRepository(BookServiceContext context)
        {
            bookServiceContext = context;
        }

        public List<Book> List()
        {
            return bookServiceContext.Books.ToList();
        }

        public List<BookBasic> ListBasic()
        {
            return bookServiceContext.Books.Select(
                b => new BookBasic
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToList();
        }
    }
}
