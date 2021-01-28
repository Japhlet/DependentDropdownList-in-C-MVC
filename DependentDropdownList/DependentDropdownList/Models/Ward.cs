using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependentDropdownList.Models
{
    public class Ward
    {
        public int ID { get; set; }
        public int subCountyId { get; set; }
        public String name { get; set; }
    }
}