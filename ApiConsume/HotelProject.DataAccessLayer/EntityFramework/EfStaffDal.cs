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
    public class EfStaffDal:GenericRepository<Staff>, IStaffDal
    {
        private readonly Context _context;
        public EfStaffDal(Context context):base(context)
        {
            _context = context;
        }

        public int GetStaffCount()
        {
            return _context.Staffs.Count();
        }

        public List<Staff> Last4Staffs()
        {
            var value = _context.Staffs.OrderByDescending(s => s.StaffId).Take(4).ToList();
            return value;
        }
    }
}
