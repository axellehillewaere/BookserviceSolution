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
    public class AuthorRepository : Repository<Author>
    {
        //private BookServiceContext bookServiceContext;

        public AuthorRepository(BookServiceContext context) : base (context)
        {
            //bookServiceContext = context;
        }

        //    public List<Author> List()
        //    {
        //        return bookServiceContext.Authors.ToList();
        //    }

        public async Task<List<AuthorBasic>> ListBasic()
        {
            return await _bookServiceContext.Authors.Select(a => new AuthorBasic
            {
                Id = a.Id,
                Name = a.LastName + " " + a.FirstName
            }).ToListAsync();
        }

        //    public Author GetById(int id)
        //    {
        //        return bookServiceContext.Authors.FirstOrDefault(a => a.Id == id);
        //    }
        //}
    }
