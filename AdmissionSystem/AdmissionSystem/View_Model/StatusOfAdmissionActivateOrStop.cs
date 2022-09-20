using AdmissionSystem.Model;
using System;
using System.Collections.Generic;
namespace AdmissionSystem.View_Model
{
    public class StatusOfAdmissionActivateOrStop
    {
        public int id { get; set; }
        public bool status { get; set; }
        public List<Statues_of_admission_eligibilty> lisat { get; set; }
    }
}
