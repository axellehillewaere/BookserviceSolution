using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Models
{
    //kunnen nooit geinstantieerd worden, wel om over te erven
    // geen new entitybase
    public abstract class EntityBase
    {
        public int Id { get; set; }

        private DateTime? created; //nullable
        public DateTime? Created
        {
            get
            {
                return created ?? DateTime.Now;
            }
            set
            {
                if (value != null)
                {
                    created = value;
                }
                else
                {
                    created = DateTime.Now;
                }
            }
        }
    }
}
