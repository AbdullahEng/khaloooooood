using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    public class Department_relation_type_control : Controller
    {
        private readonly CRUD_Operation_Interface<Department_relation_Type> depart_Relat_Ty_repo;
        private readonly CRUD_Operation_Interface<Department> department_Repo;
        private readonly CRUD_Operation_Interface<Type_of_high_school_Cirtificate> type_Of_High_School_Repo;

        public Department_relation_type_control(CRUD_Operation_Interface<Department_relation_Type> depart_relat_Ty_repo
            ,CRUD_Operation_Interface<Department> department_repo
            ,CRUD_Operation_Interface<Type_of_high_school_Cirtificate> Type_of_high_school_repo
            )
        {
            depart_Relat_Ty_repo = depart_relat_Ty_repo;
            department_Repo = department_repo;
            type_Of_High_School_Repo = Type_of_high_school_repo;
        }
        // GET: Department_relation_type_control
        public ActionResult Index()
        {
           var dep= depart_Relat_Ty_repo.List().ToList();
            return View(dep);
        }

        // GET: Department_relation_type_control/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department_relation_type_control/Create
        public ActionResult Create()
        {
            var dep = new Department_relation_type_view_model
            {
                FK_Department=FillSellectionDepartment(),
                FK_type_Of_High_School_Cirtificate=FillSellectionType_of_high_school___(),
            };
            return View(dep);
        }

        // POST: Department_relation_type_control/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department_relation_type_view_model collection)
        {
            try
            {
                if (collection.Department_id == -1 || collection.Type_of_high_school_cirtificate_id == -1) {
                    ViewBag.Message = "The specilazation or Type of high school is empty";
                    return View(GetAll());
                
                }
                var departmentfind = department_Repo.Find(collection.Department_id);
                var typ_of_find = type_Of_High_School_Repo.Find(collection.Type_of_high_school_cirtificate_id);
                var depar_type_rel = new Department_relation_Type { 
                FK_Department=departmentfind,
                FK_type_Of_High_School_Cirtificate=typ_of_find,
                Minemum_of_Rate=collection.Minemum_of_Rate,
                Rate_of_chaire_count=collection.Rate_of_chaire_count
                };
                depart_Relat_Ty_repo.Add(depar_type_rel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Department_relation_type_control/Edit/5
        public ActionResult Edit(int id)
        {
            var deprtfind = depart_Relat_Ty_repo.Find(id);
            var depview = new Department_relation_type_view_model { 
            FK_Department=FillSellectionDepartment(),
            FK_type_Of_High_School_Cirtificate=FillSellectionType_of_high_school___(),
            Minemum_of_Rate=deprtfind.Minemum_of_Rate,
          Rate_of_chaire_count=deprtfind.Rate_of_chaire_count,   
            
            };
            return View(depview);
        }

        // POST: Department_relation_type_control/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department_relation_type_view_model collection)
        {
            try
            {
                var departfind = department_Repo.Find(collection.Department_id);
                var typfind = type_Of_High_School_Repo.Find(collection.Type_of_high_school_cirtificate_id);
                var dep = new Department_relation_Type { 
                    id=collection.id,
                FK_Department=departfind,
                FK_type_Of_High_School_Cirtificate=typfind,
                Minemum_of_Rate=collection.Minemum_of_Rate,
                Rate_of_chaire_count=collection.Rate_of_chaire_count
                };
                depart_Relat_Ty_repo.Update(id,dep);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Department_relation_type_control/Delete/5
        public ActionResult Delete(int id)
        {
            var depfind = depart_Relat_Ty_repo.Find(id);
            return View(depfind);
        }

        // POST: Department_relation_type_control/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                depart_Relat_Ty_repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Department> FillSellectionDepartment() {
            var deprt = department_Repo.List().ToList();
            deprt.Insert(0,new Department { id =-1,specialization_name= "_-_-_-_-please Enter specialization------" });
            return deprt;
        }
        List<Type_of_high_school_Cirtificate> FillSellectionType_of_high_school___() {
            var type = type_Of_High_School_Repo.List().ToList();
            type.Insert(0,new Type_of_high_school_Cirtificate {id=-1,type= "_-_-_-_-please Enter the type of hight schoole----" });
            return type;
        
        }
        Department_relation_type_view_model GetAll() {
            var dep = new Department_relation_type_view_model
            {
                FK_Department = FillSellectionDepartment(),
                FK_type_Of_High_School_Cirtificate=FillSellectionType_of_high_school___()
                
            };
            return dep;
        }
    }
}
