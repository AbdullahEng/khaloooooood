using AdmissionSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class Tracking_Rate_Repo : CRUD_Operation_Interface<Tracking_Rate>
    {
        ApplicationDbContext DB;
        public Tracking_Rate_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Tracking_Rate entity)
        {
            DB.Tracking_Rate.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            DB.Tracking_Rate.Remove(entity);
            DB.SaveChanges();
        }

        public Tracking_Rate Find(int id)
        {
            return DB.Tracking_Rate.SingleOrDefault(a => a.id == id);
        }

        public IList<Tracking_Rate> List()
        {
            return DB.Tracking_Rate.Include(a=>a.FK_Employee_Info).Include(a=>a.FK_Student_Info).ToList();
        }

        public void Update(int id, Tracking_Rate entity)
        {
            DB.Tracking_Rate.Update(entity);
            DB.SaveChanges();
        }
    }
}
