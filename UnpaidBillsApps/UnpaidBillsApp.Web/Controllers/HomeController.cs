using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnpaidBillsApp.Web.Models;

namespace UnpaidBillsApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UnpaidList()
        {
            var companies = CreateCompanies();
            var dropDownItemsForCompany = CreatDropdownItemsForCompany(companies);
            dropDownItemsForCompany[2].Selected = true;
            var viewModel = new UnpaidListViewModel
            {
                companies = companies,
                DropdownItemsForCompany = dropDownItemsForCompany
            };
            viewModel.selectedCompanyId = "3";
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult UnpaidList(UnpaidListViewModel model)
        {
           if(ModelState.IsValid)
            {

            }
            return View(model);
        }
        private List<SelectListItem> CreatDropdownItemsForCompany(List<Company> companies)
        {
            List<SelectListItem> companyListItems = new List<SelectListItem>();
            foreach (var company in companies)
            {
                companyListItems.Add(new SelectListItem { Text = company.name, Value = company.id.ToString() });
            }

            return companyListItems;
        }
        private List<Company> CreateCompanies()
        {
            UnpaidListViewModel model = new UnpaidListViewModel();
            List<Company> companies = new List<Company>();

            companies.Add(new Company("1", "Company1"));
            companies.Add(new Company("2", "Company2"));
            companies.Add(new Company("3", "Company3"));
            companies.Add(new Company("4", "Company4"));
            companies.Add(new Company("5", "Company5"));
            return companies;
        }
    }
}