using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHangXachTay.Models
{
    public class Cart
    {
        public int id { get; set; }
        public tablePRODUCTofYourCart tablePRODUCTofYourCart { get; set; }
        public int tongtien { get; set; }
    }
}