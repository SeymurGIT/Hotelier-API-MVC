using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Xidmət ikon linki girin")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Xidmət başlığı girin")]
        [StringLength(100, ErrorMessage = "Xidmət başlığı 100 simvol həddini aşa bilməz")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
