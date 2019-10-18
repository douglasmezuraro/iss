using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PSS.Models;

namespace PSS.Utils
{
    public static class Global
    {
        public static User User { get; set; }
        public static Cart Cart { get; set; } = new Cart();
    }
}