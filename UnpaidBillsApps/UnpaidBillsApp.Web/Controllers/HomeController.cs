using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnpaidBillsApp.Web.Models;
using UnpaidBillsApp.Web.Services;

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
            BillService billService = new BillService();
            var viewModel =  billService.GetUnpaidBills();
            //viewModel.selectedCompanyId = "3";
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult UnpaidList(UnpaidListViewModel model)
        {
           if(ModelState.IsValid)
            {
                BillService billService = new BillService();
                model = billService.GetUnpaidBillsOfCompany(model.selectedCompanyId);
            }
            return View(model);
        }

        
    }
}