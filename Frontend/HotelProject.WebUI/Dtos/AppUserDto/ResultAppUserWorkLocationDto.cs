using HotelProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace HotelProject.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserWorkLocationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int WorkLocationID { get; set; }
        public string WorkLocationName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
