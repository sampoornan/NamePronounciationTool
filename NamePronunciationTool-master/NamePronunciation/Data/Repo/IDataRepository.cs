using NamePronunciation.Entities;
using NamePronunciation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamePronunciation.Data.Repo
{
    public interface IDataRepository
    {
        public void saveAudioChanges(string Name, string Path);
        public Employee GetEmployeeDetails(string Name);
    }
}
