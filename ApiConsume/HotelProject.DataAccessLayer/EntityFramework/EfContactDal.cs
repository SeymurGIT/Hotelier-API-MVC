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
    public class EfContactDal :GenericRepository<Contact>, IContactDal
    {
        private readonly Context _context;

        public EfContactDal(Context context) : base(context)
        {
            _context = context;
        }
        public int GetContactCount()
        {
            return _context.Contacts.Count();
        }
    }
}
