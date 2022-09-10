using AdmissionSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class Type_of_high_school_Cirtificate_Repo : CRUD_Operation_Interface<Type_of_high_school_Cirtificate>
    {
        ApplicationDbContext DB;
        public Type_of_high_school_Cirtificate_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Type_of_high_school_Cirtificate entity)
        {
            DB.Type_of_high_school_Cirtificate.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            DB.Type_of_high_school_Cirtificate.Remove(entity);
            DB.SaveChanges();
        }

        public Type_of_high_school_Cirtificate Find(int id)
        {
            var entity = DB.Type_of_high_school_Cirtificate.SingleOrDefault(a => a.id == id);
            return entity;
        }

        public IList<Type_of_high_school_Cirtificate> List()
        {
            return DB.Type_of_high_school_Cirtificate.AsNoTracking().ToList();
        }

        public void Update(int id, Type_of_high_school_Cirtificate entity)
        {
            DB.Type_of_high_school_Cirtificate.Update(entity);
            DB.SaveChanges();

        }
    }
}
