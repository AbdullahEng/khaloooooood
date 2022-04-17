using AdmissionSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class Employee_Repo : CRUD_Operation_Interface<Employee>
    {
        ApplicationDbContext DB;
        public Employee_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Employee entity)
        {
            DB.Employee.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            DB.Employee.Remove(entity);
            DB.SaveChanges();
        }

        public Employee Find(int id)
        {
            return DB.Employee.SingleOrDefault(a => a.id == id);
        }

        public IList<Employee> List()
        {
            return DB.Employee.ToList();
        }

        public void Update(int id, Employee entity)
        {
            DB.Employee.Update(entity);
            DB.SaveChanges();
        }
    }
}
