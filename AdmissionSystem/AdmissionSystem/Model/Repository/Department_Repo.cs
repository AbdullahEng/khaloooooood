using AdmissionSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class Department_Repo : CRUD_Operation_Interface<Department>
    {
        ApplicationDbContext DB;
        public Department_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Department entity)
        {
            DB.Department.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var Dp = Find(id);
            DB.Department.Remove(Dp);
            DB.SaveChanges();
        }

        public Department Find(int id)
        {
            var Dp=DB.Department.SingleOrDefault(d=>d.id==id);
            return Dp;
        }

        public IList<Department> List()
        {
            return DB.Department.ToList();
        }

        public void Update(int id, Department entity)
        {
            DB.Department.Update(entity);
            DB.SaveChanges();
        }
    }
}
