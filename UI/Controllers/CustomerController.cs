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
        private readonly IEnumerable<CustomerType> _customerTypes;

        public CustomerController(ICustomerRepository customerRepository, ITypesRepository<CustomerType> customerTypeRepository, ITypesRepository<CustomerTypeCustomer> customerTypeCustomerRepository)
        {
            _customerRepository = customerRepository;
            _customerTypeRepository = customerTypeRepository;
            _customerTypeCustomerRepository = customerTypeCustomerRepository;
            _customerTypes = _customerTypeRepository.GetAllTTypes();
        }

        [HttpGet]
        [Route("Musteriler")]
        public IActionResult Index()
        {
            return View(_customerRepository.GetAll().OrderByDescending(x => x.ModifiedDate).ToList());
        }

        [HttpGet]
        [Route("Ekle")]
        public IActionResult Add()
        {
            TempData["CustomerTypes"] = _customerTypeRepository.GetAllTTypes().ToList();
            return View();
        }

        [HttpPost]
        [Route("Ekle")]
        public IActionResult Add(AddCustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer
                {
                    Fullname = customerDto.Fullname,
                    Email = customerDto.Email,
                    MobileNumber = customerDto.MobileNumber,
                    HousePhoneNumber = customerDto.HousePhoneNumber,
                };

                _customerRepository.Add(customer);

                foreach (int cType in customerDto.CustomerTypes)
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
            TempData["CustomerTypes"] = _customerTypeRepository.GetAllTTypes().ToList();
            return View(customerDto);

        }

        [HttpGet]
        [Route("Duzenle")]
        public IActionResult Edit(int id)
        {
            ViewBag.CustomerTypes = _customerTypes;
            return View(_customerRepository.GetById(id));
        }


        [HttpPost]
        [Route("Duzenle")]
        public IActionResult Edit(CustomerViewModel customerVM)
        {

            #region CustomerTypes Güncelleme

            //Mevcut CustomerTypes Silme
            _customerTypeCustomerRepository.DeleteAllTTypes(x => x.CustomerId == customerVM.Id);

            //Güncel CustomerTypes Ekleme
            List<CustomerTypeCustomer> entitiesToAdd = new List<CustomerTypeCustomer>();
            foreach (int customerTypeId in customerVM.CustomerTypes)
                entitiesToAdd.Add(new CustomerTypeCustomer { CustomerTypeId = customerTypeId, CustomerId = customerVM.Id });

            _customerTypeCustomerRepository.AddAllTTypes(entitiesToAdd);

            #endregion 

            Customer customer = new Customer
            {
                Id = customerVM.Id,
                Fullname = customerVM.Fullname,
                Email = customerVM.Email,
                MobileNumber = customerVM.MobileNumber,
                HousePhoneNumber = customerVM.HousePhoneNumber,
            };

            _customerRepository.Update(customer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Sil")]
        public IActionResult Delete(int id)
        {
            var customerToDelete = _customerRepository.GetById(id);
            _customerRepository.Delete(customerToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Detaylar")]
        public IActionResult Details(int id)
        {
            return View(_customerRepository.GetById(id));
        }
    }
}
