using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Galeria_WEB.Models.Clases;

namespace Galeria_WEB.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Usuario user = new Usuario("", null, null, null, null, null);
            this.Session["Login"] = null;
            var data = Request.QueryString["msg"];
            if(data != null && !data.Equals(""))
            {
                ViewData["Error"] = data;
            }
            ViewBag.Message = user;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {

            string sw = Request["sw"];

            if (sw.Equals("1")) {
                return View("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Registro()
        {
            ViewBag.Message = "Formulario de registros";

            var data = Request.QueryString["msg"];
            if(data != null && !data.Equals(""))
            {
                ViewData["Error"] = data;
            }

            return View();
        }

        


    }
    }