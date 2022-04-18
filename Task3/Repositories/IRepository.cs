using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.Entities;

namespace Task3.Repositories
{
   public interface IRepository
    {
        void Add(Person person);
        Person Get(int id);
        void Update(Person person);
        void Delete(Person person);
        IEnumerable<Person> GetAll();

   }
}
