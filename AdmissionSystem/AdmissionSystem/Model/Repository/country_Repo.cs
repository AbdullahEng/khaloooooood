using AdmissionSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class country_Repo : CRUD_Operation_Interface<Country>
    {
        ApplicationDbContext DB;
        public country_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Country entity)
        {
            DB.Country.Add(entity);
            DB.SaveChanges();
        }
        public void Delete(int id)
        {
            var count = Find(id);
            DB.Country.Remove(count);
            DB.SaveChanges();
        }

        public Country Find(int id)
        {
            var count = DB.Country.SingleOrDefault(c=>c.id==id);
            return count;
        }

        public IList<Country> List()
        {
            return DB.Country.ToList();
        }

        public void Update(int id, Country entity)
        {
            DB.Country.Update(entity);
            DB.SaveChanges();
        }
    }
}
