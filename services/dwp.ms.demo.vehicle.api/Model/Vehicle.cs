using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwp.ms.demo.vehicle.api.Model
{
    public class Vehicle
    {
        public string EngineNo { get; set; }
        public string ChesisNo { get; set; }
        public string ModelName { get; set; }
        public string Variant { get; set; }
        public string Manufacturer { get; set; }
        public int YearOfManufacture { get; set; }
        public int MonthOfManufacture { get; set; }
        public string BatchNo { get; set; }
    }
}
