using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NamePronunciation.Entities;

namespace NamePronunciation.Data.Implementation
{
    public class Context:DbContext,IContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }
        public DbSet<Employee> tblEmployee { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
