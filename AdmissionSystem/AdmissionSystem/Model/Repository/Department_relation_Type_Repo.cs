using AdmissionSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class Department_relation_Type_Repo : CRUD_Operation_Interface<Department_relation_Type>
    {
        ApplicationDbContext DB;
        public Department_relation_Type_Repo(ApplicationDbContext _DB)
        {
                DB=_DB;
        }
        public void Add(Department_relation_Type entity)
        {
            DB.Department_relation_Type.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            DB.Department_relation_Type.Remove(entity);
            DB.SaveChanges();
        }

        public Department_relation_Type Find(int id)
        {
            return DB.Department_relation_Type.SingleOrDefault(a => a.id == id);
        }

        public IList<Department_relation_Type> List()
        {
            return DB.Department_relation_Type.Include(a=>a.FK_Department).Include(b=>b.FK_type_Of_High_School_Cirtificate).ToList();
        }

        public void Update(int id, Department_relation_Type entity)
        {
            DB.Department_relation_Type.Update(entity);
            DB.SaveChanges();
        }
    }
}
