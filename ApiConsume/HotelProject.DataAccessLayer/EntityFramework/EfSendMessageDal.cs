﻿using HotelProject.DataAccessLayer.Abstract;
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
    public class EfSendMessageDal:GenericRepository<SendMessage>,ISendMessageDal
    {
        private readonly Context _context;
        public EfSendMessageDal(Context context) : base(context)
        {
            _context = context;
        }
        public int GetSentMessagesCount()
        {
            return _context.SendMessages.Count();
        }
    }
}
