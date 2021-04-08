using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class EditEstateDto
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ücret alanı zorunludur.")]
        public int? Price { get; set; }
        [Required(ErrorMessage = "Metrekare alanı zorunludur.")]
        public double? SquareMeter { get; set; }
        [Required(ErrorMessage = "Oda Sayısı alanı zorunludur.")]
        public int? NumberOfRooms { get; set; }
        [Required(ErrorMessage = "Kat alanı zorunludur.")]
        public int? Floor { get; set; }
        [Required(ErrorMessage = "Bina Kat Sayısı alanı zorunludur.")]
        public int? TotalNumberOfBuildingFloors { get; set; }
        [Required(ErrorMessage = "Adres alanı zorunludur.")]
        public string Address { get; set; }
        [Range(1, 2, ErrorMessage = "Emlak Tipi alanı zorunludur.")]
        public int EstateTypeId { get; set; }
        [Range(1, 5, ErrorMessage = "Isınma Türü alanı zorunludur.")]
        public int HeatingTypeId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Müşteri alanı zorunludur.")]
        public int CustomerId { get; set; }
        [Range(1, 911, ErrorMessage = "İlçe alanı zorunludur.")]
        public int DistrictId { get; set; }
        public int CityId { get; set; }
    }
}
