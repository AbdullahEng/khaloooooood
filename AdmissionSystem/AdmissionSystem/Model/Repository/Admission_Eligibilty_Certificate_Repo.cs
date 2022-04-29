using AdmissionSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class Admission_Eligibilty_Certificate_Repo : CRUD_Operation_Interface<Admission_Eligibilty_Certificate>
    {
        ApplicationDbContext DB;
        public Admission_Eligibilty_Certificate_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
      
        public void Add(Admission_Eligibilty_Certificate entity)
        {
            DB.Admission_Eligibilty_Certificate.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            DB.Admission_Eligibilty_Certificate.Remove(entity);
            DB.SaveChanges();
        }

        public Admission_Eligibilty_Certificate Find(int id)
        {
            return DB.Admission_Eligibilty_Certificate.Include(a => a.FK_Type_of_high_school_Cirtificate).Include(a => a.wish1).Include(a => a.wish2).Include(a => a.wish3).SingleOrDefault(a => a.id == id);
        }

        public IList<Admission_Eligibilty_Certificate> List()
        {
           return DB.Admission_Eligibilty_Certificate.ToList();
        }

        public void Update(int id, Admission_Eligibilty_Certificate entity)
        {
            DB.Admission_Eligibilty_Certificate.Update(entity);
            DB.SaveChanges();
        }
    }
}
