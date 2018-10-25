﻿using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public Publisher GetById(int id)
        {
            return bookServiceContext.Publishers.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Publisher> Update(Publisher publisher)
        {
            try
            {
                bookServiceContext.Entry(publisher).State = EntityState.Modified;
                await bookServiceContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(publisher.Id))
                {
                    return null;    
                }
                else
                {
                    throw;
                }
            }
            return publisher;
        }

        private bool PublisherExists(int id)
        {
            return bookServiceContext.Publishers.Any(p => p.Id == id);
        }
    }
}
