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
    public class DapartmentControl : Controller
    {

        private readonly CRUD_Operation_Interface<Department> deprt_Repo;
        private readonly CRUD_Operation_Interface<Faculty> faculty_Repo;
        private readonly CRUD_Operation_Interface<Department_relation_Type> department_Relation_Repo;
        private readonly CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> broken_Repo;

        public DapartmentControl(CRUD_Operation_Interface<Department> deprt_repo
            , CRUD_Operation_Interface<Faculty> faculty_repo
            ,CRUD_Operation_Interface<Department_relation_Type>department_relation_Repo
            , CRUD_Operation_Interface<Broken_Relationshib_Stat_Dep_Chair> Broken_Repo
            
            )
        {
            deprt_Repo = deprt_repo;
            faculty_Repo = faculty_repo;
            department_Relation_Repo = department_relation_Repo;
            broken_Repo = Broken_Repo;
        }
        // GET: Department_Controller
        public ActionResult Index()
        {
            // Department_faculty_view_model
            var delist = deprt_Repo.List().ToList();
            return View(delist);
        }

        // GET: Department_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department_Controller/Create
        public ActionResult Create()
        {
            var depart_fac_v_m = new Department_faculty_view_model
            {
                facultylist = FillSelliction()

            };
            return View(depart_fac_v_m);
        }

        // POST: Department_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department_faculty_view_model collection)
        {

            try
            {
                if (collection.facultyid == -1)
                {
                    ViewBag.Message = "Please Select an Faculty";
                    ViewBag.MessageArabic = "الرجاء تحديد الكلية";

                    return View(GetAllDepartemnet());
                }
                var fac = faculty_Repo.Find(collection.facultyid);
                Department dep = new Department
                {
                    FK_faculty = fac,
                    specialization_name = collection.specialization_name
                };
                var deplist = deprt_Repo.List().Where(t => t.FK_facultyId == fac.id && t.specialization_name == collection.specialization_name).ToList();

                if (collection.specialization_name == null) { return View(GetAllDepartemnet()); }
                else
                {
                    if (deplist.Count == 0)
                    {
                        deprt_Repo.Add(dep);
                        ViewBag.AddSuccess = "The addition succeeded";
                        ViewBag.AddSuccessArabic = "نجحت الإضافة";

                        return View(GetAllDepartemnet());
                    }
                    else if (deplist.Count == 1)
                    {
                        ViewBag.sameEdit = "Already Exists";
                        ViewBag.sameEditArabic = "موجود بالفعل";

                        return View(GetAllDepartemnet());

                    }
                    else
                    {
                        ViewBag.Addfails = "The addition fails";
                        ViewBag.AddfailsArabic = "فشل الإضافة";

                        return View(GetAllDepartemnet());

                    }
                }
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Department_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            var dep = deprt_Repo.Find(id);
            var facu = faculty_Repo.Find(dep.FK_facultyId);
            var depvi = new Department_faculty_view_model
            {
                
                facultylist =FillSelliction_faculty_name(facu),
  
                specialization_name = dep.specialization_name


            };
            return View(depvi);
        }

        // POST: Department_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department_faculty_view_model collection)
        {
            try
            {
                var fac = faculty_Repo.Find(collection.facultyid);
                var dep = new Department
                {
                    id = collection.id,
                    FK_faculty = fac,
                    specialization_name = collection.specialization_name
                };
             

                if (collection.facultyid == -1)
                {
                    ViewBag.Message = "Please Select a Faculty";
                    ViewBag.MessageArabic = "الرجاء تحديد الكلية";

                    return View(GetAllDepartemnet());
                }
                //var fac = faculty_Repo.Find(collection.facultyid);
                //Department dep = new Department
                //{
                //    FK_faculty = fac,
                //    specialization_name = collection.specialization_name
                //};
                //var deplist = deprt_Repo.List().Where(t => t.FK_faculty == fac && t.specialization_name == collection.specialization_name).ToList();
                var deplist = deprt_Repo.List().Where(t =>   t.FK_facultyId == fac.id && t.specialization_name == collection.specialization_name).ToList();
                if (collection.specialization_name == null) { return View(GetAllDepartemnet_with_faculty_name(fac)); }
                else
                {
                    if (deplist.Count == 0)
                    {
                        deprt_Repo.Update(collection.id, dep);
                        ViewBag.UpdateSuccess = "Editing success";
                        ViewBag.UpdateSuccessArabic = "نجاح التحرير";

                        return View(GetAllDepartemnet_with_faculty_name(fac));
                    }
                    else if (deplist.Count == 1)
                    {
                        ViewBag.sameEdit = "Same Edit";
                        ViewBag.sameEditArabic = "نفس التحرير";

                        return View(GetAllDepartemnet_with_faculty_name(fac));

                    }
                    else {

                        ViewBag.updatefails = "Editing failed";
                        ViewBag.updatefailsArabic = "فشل التحرير";

                        return View(GetAllDepartemnet_with_faculty_name(fac));

                    }

                }










                //return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Department_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            var dep = deprt_Repo.Find(id);
            var facu = faculty_Repo.Find(dep.FK_facultyId);
            var depvi = new Department
            {
                FK_faculty=facu,
                //facultylist = FillSelliction(),
                specialization_name = dep.specialization_name


            };
            return View(depvi);
        }

        // POST: Department_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var dep = deprt_Repo.Find(id);
                if (dep == null)
                {
                    ViewBag.WasDeleted = "This department is already deleted";
                    ViewBag.WasDeletedArabic= "تم حذف هذا القسم بالفعل";

                    return View();
                }
                var brokenList = broken_Repo.List().Where(d=>d.Fk_departmentId==dep.id).ToList();
                var Dep_relation_Ty_list = department_Relation_Repo.List().Where(d => d.FK_DepartmentId == dep.id).ToList();
                var facu = faculty_Repo.Find(dep.FK_facultyId);
                //var dep_relation = department_Relation_Repo.List();
                //bool department_Is_linked = false;
                //foreach (var item in dep_relation)
                //{
                //    if (item.FK_DepartmentId == id)
                //    {
                //        department_Is_linked  = true;
                //        break;
                //    }
                //}

                if (brokenList.Count==0 && Dep_relation_Ty_list.Count==0)
                {
                    deprt_Repo.Delete(id);
                    ViewBag.freeDepartment = "Delete the '" + dep.specialization_name + "'with faculty' " + facu.Faculty_name + "' succeeded";
                    ViewBag.freeDepartmentArabic = "حذف ال '" + dep.specialization_name + "'مع الكليه' " + facu.Faculty_name + "' تم بنجاح";

                    return View();
                }
                else {
                    ViewBag.linkedDepartment = "you can't delete This item because it is related with Others(may broken relation or Department type)"; 
                    ViewBag.linkedDepartmentArabic = "لا يمكنك حذف هذا القسم لأنه مرتبط بالآخرين "; return View(dep);

                }

                //return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public List<Faculty> FillSelliction()
        {
            var fac = faculty_Repo.List().ToList();
            fac.Insert(0, new Faculty { id = -1, Faculty_name = "please Enter The Faculty" });
            return fac;

        }

        public List<Faculty> FillSelliction_faculty_name(Faculty f )
        {
            var fac = faculty_Repo.List().ToList();
            var listt = new List<Faculty>();
            listt.Insert(0,f);
            fac.Remove(f);
            listt.Insert(1, new Faculty { id = -1, Faculty_name = "please Enter The Faculty" });
            listt.InsertRange(2, fac);
            return listt;

        }
        public Department_faculty_view_model GetAllDepartemnet()
        {
            var model = new Department_faculty_view_model
            {
                facultylist = FillSelliction()

            };
            return model;
        }
        public Department_faculty_view_model GetAllDepartemnet_with_faculty_name( Faculty f)
        {
            var model = new Department_faculty_view_model
            {
                facultylist = FillSelliction_faculty_name(f)

            };
            return model;
        }
    }
}
