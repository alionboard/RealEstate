using Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class AddEstateDto
    {
        [Required(ErrorMessage = "Ücret alanı zorunludur.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Metrekare alanı zorunludur.")]
        public double SquareMeter { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int TotalNumberOfBuildingFloors { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1, 2)]
        public int EstateTypeId { get; set; }
        [Required(ErrorMessage = "Isınma Türü alanı zorunludur.")]
        [Range(1, 5)]
        public int HeatingTypeId { get; set; }
        [Required(ErrorMessage = "Müşteri zorunludur.")]
        [Range(1, int.MaxValue)]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "İlçe alanı zorunludur.")]
        [Range(1, 911)]
        public int DistrictId { get; set; }
    }
}
