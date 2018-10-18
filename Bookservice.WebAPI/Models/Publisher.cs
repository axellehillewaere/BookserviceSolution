﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        //lege constructor nodig om op te vullen!
        public Publisher()
        {
        }

        public Publisher(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
