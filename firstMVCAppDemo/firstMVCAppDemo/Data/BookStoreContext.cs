using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstMVCAppDemo.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base (options)
        {

        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Language>Language { get; set; }

      
    }
}
