using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalWeb.BusinessLayer
{
    public class RentDetail
    {
        public int RentDetailID { get; set; }

        public int CarID { get; set; }

        public Car Car { get; set; }

        public string CustomerName { get; set; }

        public string ContactNo { get; set; }

        public DateTime RentalDate { get; set; }
    }
}
