using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.DTO;
using Bookservice.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class AuthorRepository
    {
        private BookServiceContext bookServiceContext;

        public AuthorRepository(BookServiceContext context)
        {
            bookServiceContext = context;
        }

        public List<Author> List()
        {
            return bookServiceContext.Authors.ToList();
        }

        public List<AuthorBasic> GetAuthorBasic()
        {
            return bookServiceContext.Authors.Select(
                a => new AuthorBasic
                {
                    Id = a.Id,
                    Name = a.LastName + " " + a.FirstName
                }).ToList();
        }

        public List<Author> GetById(int id)
        {
            return bookServiceContext.Authors.Where(
                a => id == a.Id
                ).ToList();
        }
    }
}
