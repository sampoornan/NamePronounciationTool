using Microsoft.EntityFrameworkCore;
using NamePronunciation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamePronunciation.Data
{
    public interface IContext
    {
        public DbSet<Employee> tblEmployee { get; set; }
        int SaveChanges();
       
    }
}
