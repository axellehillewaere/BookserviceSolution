using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.DTO;
using Bookservice.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class BookRepository : Repository<Book>
    {
        //context nodig om zaken weg te schrijven of toe te voegen
        //private BookServiceContext bookServiceContext;

        //geef context mee zodat ik weet naar waar moet opslaan
        public BookRepository(BookServiceContext context) : base(context)
        {
            //bookServiceContext = context;
        }

        public async Task<List<Book>> GetAllInclusive()
        {
            return await GetAll()
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        //public List<Book> List()
        //{
        //    return bookServiceContext.Books
        //        .Include(a => a.Author)
        //        .Include(p => p.Publisher)
        //        .ToList();
        //}

        public async Task<List<BookBasic>> ListBasic()
        {
            return await _bookServiceContext.Books.Select(b => new BookBasic
            {
                Id = b.Id,
                Title = b.Title
            }).ToListAsync();
        }

        public async Task<BookDetail> GetById(int id)
        {
            return await _bookServiceContext.Books.Select(b => new BookDetail
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Year = b.Year,
                Price = b.Price,
                NumberOfPages = b.NumberOfPages,
                AuthorId = b.Author.Id,
                AuthorName = $"{b.Author.LastName} {b.Author.FirstName}",
                PublisherId = b.Publisher.Id,
                PublisherName = b.Publisher.Name,
                FileName = b.FileName
            }).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
