using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.TestimonialDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
           //Service
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();


            //Identity
            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<UserLoginDto, AppUser>().ReverseMap();

            //About
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            //Room
            CreateMap<ResultRoomDto, Room >().ReverseMap();
            
            //Testimonial
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();

            //Subscribe
            CreateMap<CreateSubscriptionDto, Subscribe>().ReverseMap();

            //Staff
            CreateMap<ResultStaffDto, Staff>().ReverseMap();

            //Booking
            CreateMap<CreateBookingDto, Booking>().ReverseMap();

            //Contact
            CreateMap<CreateContactDto,Contact>().ReverseMap();

            //Guest
            CreateMap<ResultGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();
            CreateMap<CreateGuestDto, Guest>().ReverseMap();

            //SendMessage
            CreateMap<CreateSendMessageDto, SendMessage>().ReverseMap();





        }
    }
}
