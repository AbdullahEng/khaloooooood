using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Persentage_count_for_each__country
    {
        public int id { get; set; }
       // public int FK_statues_of_admission_eligibiltyId { get; set; }//one_to_many relationship
        public Statues_of_admission_eligibilty FK_statues_of_admission_eligibilty { get; set; }//one_to_many relationship
        public int  FK_countryId { get; set; }//one_to_one relashionship
        public Country FK_country { get; set; }//one_to_one relashionship
        public double Rate { get; set; }
    }
}
