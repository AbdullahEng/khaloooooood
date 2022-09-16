using AdmissionSystem.Data;
using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    [Authorize(Roles = "Admin")]
    public class Department_relation_type_control : Controller
    {
        private readonly CRUD_Operation_Interface<Department_relation_Type> depart_Relat_Ty_repo;
        private readonly CRUD_Operation_Interface<Department> department_Repo;
        private readonly CRUD_Operation_Interface<Type_of_high_school_Cirtificate> type_Of_High_School_Repo;
        private readonly ApplicationDbContext dB;

        public Department_relation_type_control(CRUD_Operation_Interface<Department_relation_Type> depart_relat_Ty_repo
            ,CRUD_Operation_Interface<Department> department_repo
            ,CRUD_Operation_Interface<Type_of_high_school_Cirtificate> Type_of_high_school_repo
            , ApplicationDbContext _DB
            )
        {
            depart_Relat_Ty_repo = depart_relat_Ty_repo;
            department_Repo = department_repo;
            type_Of_High_School_Repo = Type_of_high_school_repo;
            dB = _DB;
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
                var ddrrtt = depart_Relat_Ty_repo.List().Where(d=>d.FK_DepartmentId==collection.Department_id
                                                               && d.FK_type_Of_High_School_CirtificateId==collection.Type_of_high_school_cirtificate_id
                                                               && d.Minemum_of_Rate==collection.Minemum_of_Rate
                                                               && d.Rate_of_chaire_count==collection.Rate_of_chaire_count
                                                                                ).ToList();
                var drttypeofhigh = depart_Relat_Ty_repo.List().Where(d=>d.FK_type_Of_High_School_CirtificateId==collection.Type_of_high_school_cirtificate_id
                                                                      && d.FK_DepartmentId==collection.Department_id
                                                                      ).ToList();
                var ddrtOverRate = depart_Relat_Ty_repo.List().Where(d=>d.FK_DepartmentId==collection.Department_id);
                double count = 0;
                foreach (var item in ddrtOverRate)
                {

                    count += item.Rate_of_chaire_count;

                }


                double Rates = collection.Rate_of_chaire_count;
              
                foreach (var item in ddrtOverRate)
                {
                    Rates += item.Rate_of_chaire_count;
                    if (Rates > 100) {
                        ViewBag.messageOverRate = "Rate more than 100%" + "  you have just:::  "+(100-count)+"%";
                        return View(GetAll());
                    }
                  


                }
             
                if (ddrrtt.Count == 0 && drttypeofhigh.Count==0)
                {
                depart_Relat_Ty_repo.Add(depar_type_rel);
                    ViewBag.AddSuccess = "The addition succeeded";
                    ViewBag.AddSuccessArabic = "نجحت الإضافة";

                    return View(GetAll());
                }
                else if (ddrrtt.Count == 1 || drttypeofhigh.Count == 1)
                {
                    ViewBag.sameEdit = "Already Exists";
                    ViewBag.sameEditArabic = "موجود بالفعل";

                    return View(GetAll());

                }
                else
                {
                    ViewBag.Addfails = "The addition fails";
                    ViewBag.AddfailsArabic = "فشل الإضافة";

                    return View(GetAll());

                }
                //return RedirectToAction(nameof(Index));
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
            var dep = department_Repo.Find(deprtfind.FK_DepartmentId);
            var type = type_Of_High_School_Repo.Find(deprtfind.FK_type_Of_High_School_CirtificateId);
            var depview = new Department_relation_type_view_model { 
            FK_Department=FillSellectionDepartmentEDit(dep),
            FK_type_Of_High_School_Cirtificate=FillSellectionType_of_high_school___EDIt(type),
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
             
                var department_realtion = dB.Department_relation_Type.AsNoTracking().
                                                                        Include(a => a.FK_Department).
                                                                        Include(b => b.FK_type_Of_High_School_Cirtificate).
                                                                        SingleOrDefault(a => a.id == collection.id);
                var departfind = department_Repo.Find(department_realtion.FK_DepartmentId);
                var typfind = type_Of_High_School_Repo.Find(department_realtion.FK_type_Of_High_School_CirtificateId);
                var dep = new Department_relation_Type { 
                    id= department_realtion.id,
                FK_Department=departfind,
                FK_type_Of_High_School_Cirtificate=typfind,
                Minemum_of_Rate= collection.Minemum_of_Rate,
                Rate_of_chaire_count= collection.Rate_of_chaire_count
                };
                var ddrrtt = depart_Relat_Ty_repo.List().Where(d => d.FK_DepartmentId == department_realtion.FK_DepartmentId
                                                              && d.FK_type_Of_High_School_CirtificateId == department_realtion.FK_type_Of_High_School_CirtificateId
                                                              && d.Minemum_of_Rate == collection.Minemum_of_Rate
                                                              && d.Rate_of_chaire_count == collection.Rate_of_chaire_count
                                                                               ).ToList();

               //// var drttypeofhigh = depart_Relat_Ty_repo.List().Where(d => d.FK_type_Of_High_School_CirtificateId == collection.Type_of_high_school_cirtificate_id
               //                                                    && d.FK_DepartmentId == collection.Department_id
               //                                                    ).ToList();


                var ddrtOverRate = depart_Relat_Ty_repo.List().Where(d => d.FK_DepartmentId == department_realtion.FK_DepartmentId);





                double count = 0;
                foreach (var item in ddrtOverRate)
                {

                    count += item.Rate_of_chaire_count;

                }


                double Rates = collection.Rate_of_chaire_count;

                foreach (var item in ddrtOverRate)
                {
                    if (item.FK_DepartmentId != department_realtion.FK_DepartmentId &&
                              item.FK_type_Of_High_School_CirtificateId!=department_realtion.FK_type_Of_High_School_CirtificateId
                              ) 
                    {
                        Rates += item.Rate_of_chaire_count;
                    }
                    //Rates += item.Rate_of_chaire_count;
                    if (Rates > 100)
                    {
                        ViewBag.messageOverRate = "Rate more than 100%" + "  you have just:::  " + (100 - count) + "%";
                        return View(GetAll());
                    }



                }






                //double Rates = collection.Rate_of_chaire_count;
                //foreach (var item in ddrtOverRate)
                //{
                //  if(item.FK_DepartmentId!=department_realtion.FK_DepartmentId &&
                //        item.FK_type_Of_High_School_CirtificateId!=department_realtion.FK_type_Of_High_School_CirtificateId
                //        ) Rates += item.Rate_of_chaire_count;

                //    if (Rates > 100)
                //    {
                //        ViewBag.messageOverRate = "Rate more than 100%";
                //        return View(GetAllEDit(departfind, typfind));
                //    }


                //}
                //|| drttypeofhigh.Count == 0
                if (ddrrtt.Count == 0)
                {


                depart_Relat_Ty_repo.Update(id,dep);
                   
                    ViewBag.UpdateSuccess = "Editing success";
                    ViewBag.UpdateSuccessArabic = "نجاح التحرير";

                    return View(GetAllEDit(departfind, typfind));
                }
                else if (ddrrtt.Count == 1)
                {
                    ViewBag.sameEdit = "Same Edit";
                    ViewBag.sameEditArabic = "نفس التحرير";

                    return View(GetAllEDit(departfind, typfind));

                }
                else
                {

                    ViewBag.updatefails = "Editing failed";
                    ViewBag.updatefailsArabic = "فشل التحرير";

                    return View(GetAllEDit(departfind, typfind));

                }



                //return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
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
                var depfind = depart_Relat_Ty_repo.Find(id);
                if (depfind == null)
                {
                    ViewBag.WasDeleted = "This item is already deleted";
                    ViewBag.WasDeletedArabic = "تم حذف هذا العنصر بالفعل";

                    return View();
                }
                else
                {
              
                    depart_Relat_Ty_repo.Delete(id);
                    ViewBag.freeDepartment = "Delete the item succeeded";
                    ViewBag.freeDepartmentArabic = "تم الحذف";
                    return View();

                }
                //return RedirectToAction(nameof(Index));
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
        List<Department> FillSellectionDepartmentEDit(Department d)
        {
            var deprt = dB.Department.ToList();
            deprt.Remove(d);
            deprt.Insert(0,d);

            //deprt.Insert(0, new Department { id = -1, specialization_name = "_-_-_-_-please Enter specialization------" });
            return deprt;
        }
        List<Type_of_high_school_Cirtificate> FillSellectionType_of_high_school___() {
            var type = type_Of_High_School_Repo.List().ToList();
            type.Insert(0,new Type_of_high_school_Cirtificate {id=-1,type= "_-_-_-_-please Enter the type of hight schoole----" });
            return type;
        
        }
        List<Type_of_high_school_Cirtificate> FillSellectionType_of_high_school___EDIt(Type_of_high_school_Cirtificate t)
        {
            var type = type_Of_High_School_Repo.List().ToList();
            type.Remove(t);
            type.Insert(0,t);
            //type.Insert(0, new Type_of_high_school_Cirtificate { id = -1, type = "_-_-_-_-please Enter the type of hight schoole----" });
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
        Department_relation_type_view_model GetAllEDit( Department d,Type_of_high_school_Cirtificate t)
        {
            var dep = new Department_relation_type_view_model
            {
                FK_Department = FillSellectionDepartmentEDit(d),
                FK_type_Of_High_School_Cirtificate = FillSellectionType_of_high_school___EDIt(t)

            };
            return dep;
        }
    }
}
