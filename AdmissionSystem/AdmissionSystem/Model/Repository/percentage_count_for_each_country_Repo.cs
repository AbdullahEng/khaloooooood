using AdmissionSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class percentage_count_for_each_country_Repo : CRUD_Operation_Interface<Persentage_count_for_each__country>
    {
        ApplicationDbContext DB;
        public percentage_count_for_each_country_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Persentage_count_for_each__country entity)
        {
            DB.Persentage_count_for_each__country.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var pers = Find(id);
            DB.Persentage_count_for_each__country.Remove(pers);
            DB.SaveChanges();
        }

        public Persentage_count_for_each__country Find(int id)
        {
            var pers = DB.Persentage_count_for_each__country.AsNoTracking().SingleOrDefault(p=>p.id==id);
            return pers;
        }

        public IList<Persentage_count_for_each__country> List()
        {
            return DB.Persentage_count_for_each__country.AsNoTracking().Include(c=>c.FK_country).Include(s=>s.FK_statues_of_admission_eligibilty).ToList();
        }

        public void Update(int id, Persentage_count_for_each__country entity)
        {
            DB.Persentage_count_for_each__country.Update(entity);
            DB.SaveChanges();
        }
    }
}
