using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSmash.Models
{
    public class AccountVals : UserAccounts
    {



        public bool IFSA { get; set; }


        public bool ISA { get; set; }

        public bool ASA { get; set; }

        public bool AFSA { get; set; }
    }
}