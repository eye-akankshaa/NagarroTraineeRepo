using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BookReadingEvent.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookReadingEvent.Data.Data
{
    public class BookReadingEventContext : IdentityDbContext<ApplicationUser>
    {
        public BookReadingEventContext(DbContextOptions<BookReadingEventContext> options) : base(options)
        {

        }

        public DbSet<EventEntity> Events { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

    }
}
