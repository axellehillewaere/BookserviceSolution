using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class PublisherRepository
    {
        private BookServiceContext bookServiceContext;

        public PublisherRepository(BookServiceContext context)
        {
            bookServiceContext = context;
        }

        public List<Publisher> List()
        {
            return bookServiceContext.Publishers.ToList();
        }

        public List<Publisher> GetById(int id)
        {
            return bookServiceContext.Publishers.Where(
                p => id == p.Id
                ).ToList();
        }
    }
}
