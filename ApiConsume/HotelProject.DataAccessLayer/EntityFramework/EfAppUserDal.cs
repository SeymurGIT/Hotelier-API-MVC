using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal:GenericRepository<AppUser>, IAppUserDal
    {
        private readonly Context _context;
        public EfAppUserDal(Context context):base(context)
        {
            _context = context;
        }

        public int GetAppUserCount()
        {
            var value = _context.Users.Count();
            return value;
        }

        public List<AppUser> Users()
        {
            return _context.Users.ToList();
        }
    }
}
