using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace CrudMVCCodeFirst.Models
{
    public class LaunchEntry
    {
        public int Id { get; set; }
        public string LaunchInfo { get; set; }
        public string PostedByUserName { get; set; }
    }
}