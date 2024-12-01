using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal:GenericRepository<Booking>, IBookingDal
    {
        private readonly Context _context;
        public EfBookingDal(Context context):base(context)
        {
            _context = context;
        }
        public void ApprovedReservation(Booking booking)
        {
            var appointment = _context.Bookings.Where(b => b.BookingID == booking.BookingID).FirstOrDefault();

            appointment.Status = "Təsdiqləndi";
            _context.SaveChanges();
        }
        public void ApprovedReservation2(int id)
        {
            var appointment = _context.Bookings.Find(id);
            appointment.Status = "Təsdiqləndi";
            _context.SaveChanges();
        }

        public void CanceledReservation(int id)
        {
            var appointment = _context.Bookings.Find(id);

            appointment.Status = "Ləğv edildi";

            _context.SaveChanges();  
        }
        public void HoldReservation(int id)
        {
            var appointment = _context.Bookings.Find(id);

            appointment.Status = "Müştəriylə Əlaqə";

            _context.SaveChanges();
        }


        public int GetBookingCount()
        {
            var value = _context.Bookings.Count();
            return value;
        }

        public List<Booking> Last6Bookings()
        {
            var value = _context.Bookings.OrderByDescending(s => s.BookingDate).Take(6).ToList();
            return value;
        }
    }
}
