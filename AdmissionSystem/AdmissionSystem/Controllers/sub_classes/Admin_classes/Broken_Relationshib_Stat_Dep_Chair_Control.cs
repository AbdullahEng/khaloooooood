using AdmissionSystem.Model;
using AdmissionSystem.Model.Repository;
using AdmissionSystem.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers.sub_classes.Admin_classes
{
    [Authorize(Roles = "Admin")]
    public class Broken_Relationshib_Stat_Dep_Chair_Control : Controller
    {

        private readonly CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> broken_R_S_D_C_Repo;
        private readonly CRUD_Operation_Interface<Department> department_Repo;
        private readonly CRUD_Operation_Interface<Statues_of_admission_eligibilty> status_Of_Adm_Eligi_Repo;

        public Broken_Relationshib_Stat_Dep_Chair_Control(CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> broken_r_s_d_c_Repo
            , CRUD_Operation_Interface<Department> Department_repo
            , CRUD_Operation_Interface<Statues_of_admission_eligibilty> status_of_adm_eligi_repo
            )
        {
            broken_R_S_D_C_Repo = broken_r_s_d_c_Repo;
            department_Repo = Department_repo;
            status_Of_Adm_Eligi_Repo = status_of_adm_eligi_repo;
        }
        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller
        public ActionResult Index()
        {

           var broke = broken_R_S_D_C_Repo.List().ToList();
            var broklist = new List<Broken_Relationshib_Stat_Dep_Chair>();
            foreach (var item in broke)
            {
                if (broke != null) {
                    var status = status_Of_Adm_Eligi_Repo.Find(item.FK_statues_Of_Admission_EligibiltyId);
                    var dep = department_Repo.Find(item.Fk_departmentId);
                    var broktoAdd = new Broken_Relationshib_Stat_Dep_Chair {
                    Chair_count=item.Chair_count,
                     id=item.id,
                      Fk_department=dep,
                      Fk_departmentId=item.Fk_departmentId,
                      FK_statues_Of_Admission_Eligibilty=status,
                      FK_statues_Of_Admission_EligibiltyId=item.FK_statues_Of_Admission_EligibiltyId
                    
                    };

                    broklist.Add(broktoAdd);
                }
            }
                return View(broklist);
        }

        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller/Create
        public ActionResult Create()
        {
            var broken = new Broken_Relationshib_Stat_Dep_Chair_View_model
            {
                Fk_department = FillSellectionDepartment(),
                FK_statues_Of_Admission_Eligibilty = FillSellectionStatus_of_admi_eligi()

            };
            return View(broken);
        }

        // POST: Broken_Relationshib_Stat_Dep_Chair_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Broken_Relationshib_Stat_Dep_Chair_View_model collection)
        {
            try
            {
                if (collection.department_id == -1 || collection.status_of_admi_eligi_id == -1)
                {
                    ViewBag.Message = "The Department or Type of Admition is empty";
                    return View(GetAll());
                }
                var depfind = department_Repo.Find(collection.department_id);
                var statusFind = status_Of_Adm_Eligi_Repo.Find(collection.status_of_admi_eligi_id);
                var broken = new Broken_Relationshib_Stat_Dep_Chair
                {
                    Fk_department = depfind,
                    FK_statues_Of_Admission_Eligibilty = statusFind,
                    Chair_count = collection.Chair_count

                };


                var ff = broken_R_S_D_C_Repo.List()
                    .Where(f => (f.FK_statues_Of_Admission_EligibiltyId == collection.status_of_admi_eligi_id)
                    && (f.Fk_departmentId == collection.department_id )
                    &&( f.Chair_count == collection.Chair_count)).ToList();


                if (ff.Count == 0)
                {
                    broken_R_S_D_C_Repo.Add(broken);
                    ViewBag.AddSuccess = "The addition succeeded";
                    ViewBag.AddSuccessArabic = "نجحت الإضافة";
                    return View(GetAll());

                }
                else if (ff.Count == 1)
                {
                    ViewBag.sameEdit = "Already Exists";
                    ViewBag.sameEditArabic = "موجود بالفعل";
                    return View(GetAll());


                }
                else {
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

        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            var brokenfind = broken_R_S_D_C_Repo.Find(id);
            var depart = department_Repo.Find(brokenfind.Fk_departmentId);
            var status = status_Of_Adm_Eligi_Repo.Find(brokenfind.FK_statues_Of_Admission_EligibiltyId);
            var brokenView = new Broken_Relationshib_Stat_Dep_Chair_View_model
            {
                FK_statues_Of_Admission_Eligibilty = FillSellectionStatus_of_admi_eligi_with_TYpe_of_Admission_Brok_Edit(status),
                Fk_department = FillSellectionDepartment_Brok_Edit(depart),
                Chair_count = brokenfind.Chair_count
            };
            return View(brokenView);
        }

        // POST: Broken_Relationshib_Stat_Dep_Chair_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Broken_Relationshib_Stat_Dep_Chair_View_model collection)
        {
            try
            {
                var depart = department_Repo.Find(collection.department_id);
                var status = status_Of_Adm_Eligi_Repo.Find(collection.status_of_admi_eligi_id);
                if (collection.department_id == -1 || collection.status_of_admi_eligi_id == -1)
                {
                    ViewBag.Message = "The Department or Type of Admition is empty";
                    return View(GetAll());
                }
               
                var broken = new Broken_Relationshib_Stat_Dep_Chair
                {
                    Chair_count = collection.Chair_count,
                    Fk_department = depart,
                    FK_statues_Of_Admission_Eligibilty = status
                };



                var ff = broken_R_S_D_C_Repo.List()
                 .Where(f => (f.FK_statues_Of_Admission_EligibiltyId == collection.status_of_admi_eligi_id)
                 && (f.Fk_departmentId == collection.department_id)
                 && (f.Chair_count == collection.Chair_count)).ToList();


                if (ff.Count == 0)
                {
                    broken_R_S_D_C_Repo.Update(id, broken);
                    ViewBag.UpdateSuccess = "Editing success";
                    ViewBag.UpdateSuccessArabic = "نجاح التحرير";
                    return View(GetAll_Brok_Edit(status, depart));

                }
                else if (ff.Count == 1)
                {
                    ViewBag.sameEdit = "Same Edit";
                    ViewBag.sameEditArabic = "نفس التحرير";
                    return View(GetAll_Brok_Edit(status, depart));


                }
                else
                {

                    ViewBag.updatefails = "Editing failed";
                    ViewBag.updatefailsArabic = "فشل التحرير";
                    return View(GetAll_Brok_Edit(status, depart));

                }





                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Broken_Relationshib_Stat_Dep_Chair_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            var brokenfind = broken_R_S_D_C_Repo.Find(id);
            var depart = department_Repo.Find(brokenfind.Fk_departmentId);
            var status = status_Of_Adm_Eligi_Repo.Find(brokenfind.FK_statues_Of_Admission_EligibiltyId);
            //var brokenView = new Broken_Relationshib_Stat_Dep_Chair_View_model
            //{
            //    FK_statues_Of_Admission_Eligibilty = FillSellectionStatus_of_admi_eligi_with_TYpe_of_Admission_Brok_Edit(status),
            //    Fk_department = FillSellectionDepartment_Brok_Edit(depart),
            //    Chair_count = brokenfind.Chair_count
            //};
            var borkenView = new Broken_Relationshib_Stat_Dep_Chair { 
            Fk_department=brokenfind.Fk_department,
            Chair_count=brokenfind.Chair_count,
            Fk_departmentId=brokenfind.Fk_departmentId,
            FK_statues_Of_Admission_Eligibilty=brokenfind.FK_statues_Of_Admission_Eligibilty,
            FK_statues_Of_Admission_EligibiltyId=brokenfind.FK_statues_Of_Admission_EligibiltyId
            };
            return View(borkenView);
        }

        // POST: Broken_Relationshib_Stat_Dep_Chair_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var brokeFind = broken_R_S_D_C_Repo.Find(id);
               
                if (brokeFind == null)
                {
                    ViewBag.WasDeleted = "This Item is already deleted";
                    ViewBag.WasDeletedArabic = "تم حذف هذاالعنصر بالفعل";
                    return View();
                }
                else {
                    var depart = department_Repo.Find(brokeFind.Fk_departmentId);
                    var status = status_Of_Adm_Eligi_Repo.Find(brokeFind.FK_statues_Of_Admission_EligibiltyId);

                    broken_R_S_D_C_Repo.Delete(id);

                    ViewBag.freeDepartment = "Delete the '" + status.Type_of_admission_eligibilty
                                             + "'with Department' " + depart.specialization_name 
                                             +"'with Chair count '"+brokeFind.Chair_count
                                             + "' succeeded";
                    ViewBag.freeDepartmentArabic = "حذف ال '" + status.Type_of_admission_eligibilty
                                                   + "'مع القسم' " + depart.specialization_name 
                                                   +"مع عدد كراسي"+ brokeFind.Chair_count 
                                                   + "' تم بنجاح";
                    return View();

                }
                //var ff = broken_R_S_D_C_Repo.List().Where(f => f.Fk_departmentId == brokeFind.Fk_departmentId 
                //|| f.FK_statues_Of_Admission_EligibiltyId==brokeFind.FK_statues_Of_Admission_EligibiltyId);
               
                
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Department> FillSellectionDepartment()
        {
            var deprt = department_Repo.List().ToList();
            deprt.Insert(0, new Department { id = -1, specialization_name = "_-_-_-_-please Enter Department------" });
            return deprt;
        }
        List<Department> FillSellectionDepartment_Brok_Edit(Department dep)
        {
            var deprt = department_Repo.List().ToList();
            var list = new List<Department>();
            list.Insert(0,dep);
            deprt.Remove(dep);
            list.Insert(1, new Department { id = -1, specialization_name = "_-_-_-_-please Enter Department------" });
            list.InsertRange(2,deprt);
            return list;
        }
        List<Statues_of_admission_eligibilty> FillSellectionStatus_of_admi_eligi()
        {
            var status = status_Of_Adm_Eligi_Repo.List().ToList();
            status.Insert(0, new Statues_of_admission_eligibilty { id = -1, Type_of_admission_eligibilty = "_-_-_-_-please Enter Type of Admition------" });
            return status;
        }
        List<Statues_of_admission_eligibilty> FillSellectionStatus_of_admi_eligi_with_TYpe_of_Admission_Brok_Edit(Statues_of_admission_eligibilty Type)
        {
            var status = status_Of_Adm_Eligi_Repo.List().ToList();
            var list = new List<Statues_of_admission_eligibilty>();
            list.Insert(0,Type);
            status.Remove(Type);
            list.Insert(1, new Statues_of_admission_eligibilty { id = -1, Type_of_admission_eligibilty = "_-_-_-_-please Enter Type of Admition------" });
            list.InsertRange(2,status);
            return list;
        }

        Broken_Relationshib_Stat_Dep_Chair_View_model GetAll()
        {
            var broken = new Broken_Relationshib_Stat_Dep_Chair_View_model
            {
                Fk_department = FillSellectionDepartment(),
                FK_statues_Of_Admission_Eligibilty = FillSellectionStatus_of_admi_eligi()

            };
            return broken;
        }

        Broken_Relationshib_Stat_Dep_Chair_View_model GetAll_Brok_Edit(Statues_of_admission_eligibilty type,Department dep)
        {
            var broken = new Broken_Relationshib_Stat_Dep_Chair_View_model
            {
                Fk_department = FillSellectionDepartment_Brok_Edit(dep),
                FK_statues_Of_Admission_Eligibilty = FillSellectionStatus_of_admi_eligi_with_TYpe_of_Admission_Brok_Edit(type)

            };
            return broken;
        }

    }
}
