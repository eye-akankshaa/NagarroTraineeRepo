using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.BookStore.Data
{
    public class EventStoreContext : IdentityDbContext
    {
        public EventStoreContext(DbContextOptions<EventStoreContext> options)
            :base(options)
        {

        }
        public DbSet<Events> Events { get; set; }

      
    }
}
