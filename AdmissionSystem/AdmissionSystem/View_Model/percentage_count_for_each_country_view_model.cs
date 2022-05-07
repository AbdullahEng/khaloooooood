using AdmissionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class percentage_count_for_each_country_view_model
    {
        public int id { get; set; }
        // public int FK_statues_of_admission_eligibiltyId { get; set; }//one_to_many relationship
        public int statues_of_adm_eli_ID { get; set; }
        public List<Statues_of_admission_eligibilty> FK_statues_of_admission_eligibilty { get; set; }//one_to_many relationship
        public int countryId { get; set; }//one_to_one relashionship
        public List<Country> FK_country { get; set; }//one_to_one relashionship
        public double Rate { get; set; }

    }
}
