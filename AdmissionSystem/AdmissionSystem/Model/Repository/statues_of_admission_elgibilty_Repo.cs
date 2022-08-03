using AdmissionSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class statues_of_admission_elgibilty_Repo : CRUD_Operation_Interface<Statues_of_admission_eligibilty>
    {
        ApplicationDbContext DB;
        public statues_of_admission_elgibilty_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Statues_of_admission_eligibilty entity)
        {
            DB.Statues_of_admission_eligibilty.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var sta = Find(id);
            DB.Statues_of_admission_eligibilty.Remove(sta);
            DB.SaveChanges();
        }

        public Statues_of_admission_eligibilty Find(int id)
        {
            var sta = DB.Statues_of_admission_eligibilty.SingleOrDefault(st => st.id == id);
            return sta;
        }

        public IList<Statues_of_admission_eligibilty> List()
        {
            return DB.Statues_of_admission_eligibilty.AsNoTracking().ToList();
        }

        public void Update(int id, Statues_of_admission_eligibilty entity)
        {
            DB.Statues_of_admission_eligibilty.Update(entity);
            DB.SaveChanges();
        }
    }
}
