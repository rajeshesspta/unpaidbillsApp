using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnpaidBillsApp.Web.Services.DTOs
{
    public class Bill
    {
        public string BillNo { get; set; }
        public string CompanyId { get; set; }
        public double BillAmt { get; set; }
        public bool Paid { get; set; }
        //other fields goes here
    }
}