using AutoMapper;
using Business.Repositories;
using Data.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class EstateController : Controller
    {
        private readonly IEstateRepository _estateRepository;
        private readonly ITypesRepository<EstateType> _estateTypesRepository;
        private readonly ITypesRepository<HeatingType> _heatingTypesRepository;
        private readonly ITypesRepository<City> _cityRepository;
        private readonly ITypesRepository<District> _districtRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public EstateController(IEstateRepository estateRepository, ITypesRepository<EstateType> estateTypesRepository, ITypesRepository<HeatingType> heatingTypesRepository, ITypesRepository<City> cityRepository, ITypesRepository<District> districtRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _estateRepository = estateRepository;
            _estateTypesRepository = estateTypesRepository;
            _heatingTypesRepository = heatingTypesRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Emlaklar")]
        public IActionResult Index()
        {
            ViewBag.Cities = _cityRepository.GetAllTTypes();
            ViewBag.HeatingTypes = _heatingTypesRepository.GetAllTTypes();
            return View(_estateRepository.GetAll().ToList());
        }

        [HttpGet]
        [Route("Emlak-Ekle")]
        public IActionResult Add()
        {
            BagAllTypes();
            return View();
        }

        [HttpPost]
        [Route("Emlak-Ekle")]
        public IActionResult Add(AddEstateDto estateDto)
        {
            if (ModelState.IsValid)
            {
                Estate estate = _mapper.Map<Estate>(estateDto);
                _estateRepository.Add(estate);
                return RedirectToAction("Index");
            }
            BagAllTypes();
            return View(estateDto);
        }

        [HttpPost]
        public IActionResult GetDistricts(int cityId)
        {
            return Ok(_districtRepository.GetAllTTypes().Where(x=>x.CityId== cityId).OrderBy(x=>x.Name).ToList());
        }

        public void BagAllTypes()
        {
            ViewBag.EstateTypes = _estateTypesRepository.GetAllTTypes();
            ViewBag.HeatingTypes = _heatingTypesRepository.GetAllTTypes();
            ViewBag.Cities = _cityRepository.GetAllTTypes();
            ViewBag.Districts = _districtRepository.GetAllTTypes();
            ViewBag.Customers = _customerRepository.GetAll();
        }

        
    }
}
