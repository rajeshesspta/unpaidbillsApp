using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnpaidBillsApp.Web.Models
{
    public class UnpaidListViewModel
    {
        public List<Company> companies { get; set; }
        public List<SelectListItem> DropdownItemsForCompany { get; set; }
        public string selectedCompanyId { get; set; }
    }
}