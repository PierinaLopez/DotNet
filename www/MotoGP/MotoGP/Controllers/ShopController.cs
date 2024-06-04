
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using System.Net.Sockets;
using System;

namespace MotoGP.Controllers
{
    public class ShopController : Controller
    {
     

        
        public IActionResult OrderTicket()
        {
            int BannerNr = 3;
            ViewData["BannerNr"] = BannerNr;
            
            return View();
        }

        public IActionResult ConfirmOrder()
        { 
            int BannerNr = 3;
            ViewData["BannerNr"] = BannerNr;
            return View();
        }












    }
}
