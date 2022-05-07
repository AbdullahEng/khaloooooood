using AdmissionSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class Broken_Relationshib_Stat_Dep_Chair_Repo : CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair>
    {
        ApplicationDbContext DB;
        public Broken_Relationshib_Stat_Dep_Chair_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Broken_Relationshib_Stat_Dep_Chair entity)
        {
            DB.Broken_Relationshib_Stat_Dep_Chair.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var brok = Find(id);
            DB.Broken_Relationshib_Stat_Dep_Chair.Remove(brok);
            DB.SaveChanges();
        }

        public Broken_Relationshib_Stat_Dep_Chair Find(int id)
        {
            var brok = DB.Broken_Relationshib_Stat_Dep_Chair.SingleOrDefault(b=>b.id==id);
            return brok;
        }

        public IList<Broken_Relationshib_Stat_Dep_Chair> List()
        {
            return DB.Broken_Relationshib_Stat_Dep_Chair.ToList();
        }

        public void Update(int id, Broken_Relationshib_Stat_Dep_Chair entity)
        {
            DB.Broken_Relationshib_Stat_Dep_Chair.Update(entity);
            DB.SaveChanges();
        }
    }
}
