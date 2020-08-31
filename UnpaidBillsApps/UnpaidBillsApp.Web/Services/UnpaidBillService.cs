using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnpaidBillsApp.Web.Models;
using UnpaidBillsApp.Web.Services.DTOs;

namespace UnpaidBillsApp.Web.Services
{
    public class BillService
    {
        private List<Bill> bills;

        public BillService()
        {
            bills = CreateTempBills();
        }
        public UnpaidListViewModel GetUnpaidBills()
        {
            var companies = CreateCompanies();
            var dropDownItemsForCompany = CreatDropdownItemsForCompany(companies);
            var viewModel = new UnpaidListViewModel
            {
                companies = companies,
                DropdownItemsForCompany = dropDownItemsForCompany
            };
            return viewModel;
        }
        public UnpaidListViewModel GetUnpaidBillsOfCompany(string companyId)
        {
            // service class will pull data from different sources including db
            var companies = CreateCompanies();
            var dropDownItemsForCompany = CreatDropdownItemsForCompany(companies);
            var unpaidBillOfComp = from bill in bills
                                   where bill.Paid == false && bill.CompanyId == companyId
                                   select bill;            
            var viewModel = new UnpaidListViewModel
            {
                companies = companies,
                DropdownItemsForCompany = dropDownItemsForCompany,
                UnpaidBills= unpaidBillOfComp.ToList()
            };
            return viewModel;
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
        private List<SelectListItem> CreatDropdownItemsForCompany(List<Company> companies)
        {
            List<SelectListItem> companyListItems = new List<SelectListItem>();
            foreach (var company in companies)
            {
                companyListItems.Add(new SelectListItem { Text = company.name, Value = company.id.ToString() });
            }

            return companyListItems;
        }
        private List<Bill> CreateTempBills()
        {
            var bills = new List<Bill>();
            bills.Add(new Bill { BillAmt = 223.02, BillNo = "Bill001", CompanyId = "1" });
            bills.Add(new Bill { BillAmt = 550, BillNo = "Bill002", CompanyId = "1" });
            bills.Add(new Bill { BillAmt = 4343.44, BillNo = "Bill003", CompanyId = "1" });
            bills.Add(new Bill { BillAmt = 2233.02, BillNo = "Bill004", CompanyId = "2" });
            bills.Add(new Bill { BillAmt = 2423.02, BillNo = "Bill005", CompanyId = "1" });
            bills.Add(new Bill { BillAmt = 2223.02, BillNo = "Bill006", CompanyId = "1" });
            bills.Add(new Bill { BillAmt = 2423.02, BillNo = "Bill007", CompanyId = "3" });

            return bills;
        }
    }
}