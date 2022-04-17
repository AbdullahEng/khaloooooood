using AdmissionSystem.Data;
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
            return DB.Admission_Eligibilty_Certificate.SingleOrDefault(a => a.id == id);
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
