using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    
    public class CrudDashBoardController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }


        public ActionResult Crear()
        {
            return View();
        }
    }
}