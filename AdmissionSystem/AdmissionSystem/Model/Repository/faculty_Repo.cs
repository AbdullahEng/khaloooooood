using AdmissionSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class faculty_Repo : CRUD_Operation_Interface<Faculty>
    {
        ApplicationDbContext DB;
        public faculty_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Faculty entity)
        {
            DB.Faculty.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var fac = Find(id);
            DB.Faculty.Remove(fac);
            DB.SaveChanges();
        }

        public Faculty Find(int id)
        {
            var fac = DB.Faculty.SingleOrDefault(f=>f.id==id);
            return fac;
        }

        public IList<Faculty> List()
        {
            return DB.Faculty.ToList();
        }

        public void Update(int id, Faculty entity)
        {
            DB.Faculty.Update(entity);
            DB.SaveChanges();
        }
    }
}
