using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LDTE_Web.Models.Utilities
{

   
    public class Utility
    {

        public void CheckLogin() {
            HttpContext ctx = HttpContext.Current;
           // if (ctx.Session["user"] == null) 
               // RedirectResult("Home");
               

        }
    }
}