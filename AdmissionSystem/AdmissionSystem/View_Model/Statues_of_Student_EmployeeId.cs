using AdmissionSystem.Model;
using System;
using System.Collections.Generic;
namespace AdmissionSystem.View_Model
{
    public class Statues_of_Student_EmployeeId
    {
        public int id { get; set; }
        public Employee Employee { get; set; }
        public List<Statues_Of_Student> ListaOfStudent { get; set; }
        public int statusId { get; set; }
    }
}
