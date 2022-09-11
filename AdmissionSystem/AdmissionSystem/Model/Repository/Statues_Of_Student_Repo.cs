using AdmissionSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Repository
{
    public class Statues_Of_Student_Repo : CRUD_Operation_Interface<Statues_Of_Student>
    {
        ApplicationDbContext DB;
        public Statues_Of_Student_Repo(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public void Add(Statues_Of_Student entity)
        {
            DB.Statues_Of_Student.Add(entity);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            DB.Statues_Of_Student.Remove(entity);
            DB.SaveChanges();
        }

        public Statues_Of_Student Find(int id)
        {
            //      return DB.Statues_Of_Student.Include(a=>a.FK_Student_Info).Single(a => a.id == id);
            return DB.Statues_Of_Student.Include(a => a.FK_Student_Info).Include(b => b.FK_Employee_Info).Single(a => a.id == id);

        }

        public IList<Statues_Of_Student> List()
        {
            //  return DB.Statues_Of_Student.Include(s=>s.FK_Student_Info).ToList();
            return DB.Statues_Of_Student.AsNoTracking().Include(a => a.FK_Student_Info).ThenInclude(b => b.Statues_Of_Admission_Eligibilty).Include(c => c.FK_Student_Info).ThenInclude(d => d.Cirtificate_city).ToList();

        }

        public void Update(int id, Statues_Of_Student entity)
        {
            DB.Statues_Of_Student.Update(entity);
            DB.SaveChanges();
        }
    }
}
