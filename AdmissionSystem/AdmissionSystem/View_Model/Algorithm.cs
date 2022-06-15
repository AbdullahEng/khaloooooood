using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class Algorithm
    {
        public string name { get; set; }

        public string mark { get; set; }
        private bool accepted = false;
        public bool Accepted
        {
            get
            {
                return accepted;
            }
            set
            {
                accepted = value;
            }
        }
        public string Department { get; set; }
        public int WishNumber { get; set; }
        public int Counter { get; set; }

    }
}
