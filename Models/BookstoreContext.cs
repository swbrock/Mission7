using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Mission7.Models
{
    public partial class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {
        }
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {

        }
        public DbSet<Books> Books { get; set; }
    }
}
