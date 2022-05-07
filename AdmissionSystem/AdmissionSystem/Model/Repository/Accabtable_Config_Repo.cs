using AdmissionSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class Accabtable_Config_Repo : CRUD_Operation_Interface<Accabtable_config>
    {
        ApplicationDbContext DB;
        public Accabtable_Config_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Accabtable_config entity)
        {
            DB.Accabtable_config.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int id)
        {
            var acc = Find(id);
            DB.Accabtable_config.Remove(acc);
            DB.SaveChanges();
        }

        public Accabtable_config Find(int id)
        {
            var acc = DB.Accabtable_config.SingleOrDefault(a => a.id == id);
            return acc;
        }

        public IList<Accabtable_config> List()
        {
            return DB.Accabtable_config.ToList();
        }

        public void Update(int id, Accabtable_config entity)
        {
            DB.Update(entity);
            DB.SaveChanges();
        }
    }
}
