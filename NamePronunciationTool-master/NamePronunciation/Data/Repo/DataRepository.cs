using NamePronunciation.Entities;
using NamePronunciation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamePronunciation.Data.Repo
{
    public class DataRepository:IDataRepository
       
    {
        private readonly IContext dataContext;

        public DataRepository(IContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void saveAudioChanges(string Name,string Path)
        {
            Employee emp = new Employee();
            emp.AudioPath = Path;
            emp.EmployeeName = Name;
            dataContext.SaveChanges();
        }
        public Employee GetEmployeeDetails(string Name)
        {

            var details = (from r in dataContext.tblEmployee
                          where r.EmployeeName == Name
                          select r).FirstOrDefault();
            return details;

        }
    }
}
