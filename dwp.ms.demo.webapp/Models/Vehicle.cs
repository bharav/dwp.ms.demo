using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwp.ms.demo.webapp.Models
{
    public class Vehicle
    {
        public string modelName { get; set; }
        public string variant { get; set; }
        public string manufacturer { get; set; }
        public int yearOfManufacture { get; set; }
        public int monthOfManufacture { get; set; }
        public string chesisNo { get; set; }
        public string engineNo { get; set; }
        public string batchNo { get; set; }
    }
}
