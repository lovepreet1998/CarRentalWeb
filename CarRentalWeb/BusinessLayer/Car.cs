using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalWeb.BusinessLayer
{
    public class Car
    {
        public int CarID { get; set; }

        public string CarName { get; set; }

        public float Price { get; set; }

        public int CarCategoryID { get; set; }

        public CarCategory Category { get; set; }

        public int CompanyID { get; set; }

        public Company Company { get; set; }
    }
}
