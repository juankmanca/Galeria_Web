using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Galeria_WEB.Models.Clases;
using Galeria_WEB.Models.DB;

namespace Galeria_WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Registro()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [HttpPost]
        public ActionResult Welcome()
        {
            string sw = Request["switch"];
            BaseDatos DB = new BaseDatos();
            List<Usuario> userList = new List<Usuario>();
            if (sw == "1")
            {
                string nombre = Request["name"];
                string cedula = Request["id"];
                string correo = Request["mail"];
                string contrasena = Request["password"];
                string nombreUsuario = Request["username"];
                string avatar = Request["charachter"];
                if (nombre == "" || cedula == "" || correo == "" || contrasena == "" || nombreUsuario == "" || avatar == "")
                {
                    ViewData["Error"] = "Todos los campos son obligatorios";
                    return View("Registro");
                }
                else
                {
                    Usuario user = new Usuario(nombreUsuario, contrasena, avatar, cedula, nombre, correo);
                    
                    int aux = DB.insertDate(user);
                    if(aux == 0)
                    {
                        userList = DB.TraerUsuarios();
                        ViewData["users"] = userList;
                        //this.Session["Login"] = user.NombreUsuario;
                        //this.Request();
                        ViewBag.Message = user;
                        return View();
                    }
                    else if(aux == 1)
                    {
                        
                        ViewData["Error"] = "Error al ingresar los campos";
                         return View("Registro");
                    }
                    else
                    {
                        ViewData["Error"] = "Este usuario ya existe";
                        return View("Registro");
                    }
                }
            }
            else
            {
                string nombreUsuario = Request["Username"];
                string contrasena = Request["password"];
                if(nombreUsuario == "" || contrasena == ""){
                    ViewData["Error"] = "Todos los campos son obligatorios";
                    return View("index");
                }
                else
                {
                    Usuario user = new Usuario(nombreUsuario, contrasena, null,null,null,null);
                    
                    string aux = DB.Validar(user);
                    if (aux == user.NombreUsuario)
                    {

                        ViewBag.Message = user;
                        return View();
                    }
                    else
                    {
                        ViewData["Error"] = aux;
                        return View("index");
                    }
                }
            }

            
        }

        
        }
    }