using Business.Repositories;
using Data.Context;
using Data.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITypesRepository<CustomerType> _customerTypeRepository;
        private readonly ITypesRepository<CustomerTypeCustomer> _customerTypeCustomerRepository;

        public CustomerController(ICustomerRepository customerRepository, ITypesRepository<CustomerType> customerTypeRepository, ITypesRepository<CustomerTypeCustomer> customerTypeCustomerRepository)
        {
            _customerRepository = customerRepository;
            _customerTypeRepository = customerTypeRepository;
            _customerTypeCustomerRepository = customerTypeCustomerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            TempData["CustomerTypes"] = _customerTypeRepository.GetAllTTypes();
            return View();
        }

        [HttpPost]
        public IActionResult Add(CustomerViewModel customerVM, List<int> cTypes)
        {
            Customer customer = new Customer
            {
                Fullname = customerVM.Fullname,
                Email = customerVM.Email,
                MobileNumber = customerVM.MobileNumber,
                HousePhoneNumber = customerVM.HousePhoneNumber
            };

            _customerRepository.Add(customer);

            foreach (int cType in cTypes)
            {
                CustomerTypeCustomer customerTypeCustomer = new CustomerTypeCustomer
                {
                    Customer = customer,
                    CustomerTypeId = cType
                };
                _customerTypeCustomerRepository.Add(customerTypeCustomer);

            }
            return RedirectToAction("Index");
        }
    }
}
