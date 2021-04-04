using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IEnumerable<CustomerType> _customerTypes;

        public CustomerController(ICustomerRepository customerRepository, ITypesRepository<CustomerType> customerTypeRepository, ITypesRepository<CustomerTypeCustomer> customerTypeCustomerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerTypeRepository = customerTypeRepository;
            _customerTypeCustomerRepository = customerTypeCustomerRepository;
            _customerTypes = _customerTypeRepository.GetAllTTypes().ToList();
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
            TempData["CustomerTypes"] = _customerTypes;
            return View();
        }

        [HttpPost]
        [Route("Ekle")]
        public IActionResult Add(AddCustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _mapper.Map<Customer>(customerDto);

                foreach (int cType in customerDto.CustomerTypes)
                {
                    CustomerTypeCustomer customerTypeCustomer = new CustomerTypeCustomer
                    {
                        Customer = customer,
                        CustomerTypeId = cType
                    };
                    customer.CustomerTypes.Add(customerTypeCustomer);
                }

                _customerRepository.Add(customer);
                _customerTypeCustomerRepository.AddAllTTypes(customer.CustomerTypes);

                return RedirectToAction("Index");
            }
            TempData["CustomerTypes"] = _customerTypes;
            return View(customerDto);

        }

        [HttpGet]
        [Route("Duzenle")]
        public IActionResult Edit(int id)
        {
            TempData["CustomerTypes"] = _customerTypes;
            Customer customer = _customerRepository.GetById(id);
            EditCustomerDto customerDto = _mapper.Map<EditCustomerDto>(customer);
            return View(customerDto);
        }

        [HttpPost]
        [Route("Duzenle")]
        public IActionResult Edit(EditCustomerDto customerDto)
        {
            List<CustomerTypeCustomer> entitiesToAdd = new List<CustomerTypeCustomer>();
            if (customerDto.CustomerTypeIds != null)
                foreach (int customerTypeId in customerDto.CustomerTypeIds)
                    entitiesToAdd.Add(new CustomerTypeCustomer { CustomerTypeId = customerTypeId, CustomerId = customerDto.Id });

            if (ModelState.IsValid)
            {
                _customerTypeCustomerRepository.DeleteAllTTypes(x => x.CustomerId == customerDto.Id);
                _customerTypeCustomerRepository.AddAllTTypes(entitiesToAdd);

                Customer customer = _mapper.Map<Customer>(customerDto);

                _customerRepository.Update(customer);
                return RedirectToAction("Index");
            }

            customerDto.CustomerTypes = entitiesToAdd;
            TempData["CustomerTypes"] = _customerTypes;
            return View(customerDto);
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
