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
            this.Session["Login"] = null;

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

            return View();
        }

        [HttpPost]
        public ActionResult Welcome()
        {
            string sw = Request["switch"];
            BaseDatos DB = new BaseDatos();
            List<Usuario> userList = new List<Usuario>();
            if (sw == "1") //      Vale 1 cuado viene desde el Registro
            {
                string nombre = Request["name"];
                string cedula = Request["id"];
                string correo = Request["mail"];
                string contrasena = Request["pass"];
                string nombreUsuario = Request["username"];
                string avatar = Request["charachter"];
                if (nombre == "" || cedula == "" || correo == "" || contrasena == "" || nombreUsuario == "" || avatar == "")
                {
                    ViewData["Error"] = "Todos los campos son obligatorios";
                    return View("Registro");
                }
                else //  Si ningun campo esta vacio
                {
                    Usuario user = new Usuario(nombreUsuario, contrasena, avatar, cedula, nombre, correo);

                    int aux = DB.insertDate(user);
                    if (aux == 0) //  Si no hubo error
                    {
                        userList = DB.TraerUsuarios();
                        ViewData["userList"] = userList;
                        this.Session["Login"] = user.NombreUsuario;
                        ViewBag.Message = user;
                        return View();
                    }
                    else if (aux == 1) // Si ingreso un campo erroneo
                    {

                        ViewData["Error"] = "Error al ingresar los campos";
                        return View("Registro");
                    }
                    else  // Ingreso un nombre de usuario que ya existe
                    {
                        ViewData["Error"] = "Este usuario ya existe";
                        return View("Registro");
                    }
                }
            }
            else  //          Vale 2 si viene desde el Login
            {
                string nombreUsuario = Request["Username"];
                string contrasena = Request["password"];
                if (nombreUsuario == "" || contrasena == "") {
                    ViewData["Error"] = "Todos los campos son obligatorios";
                    return View("index");
                }
                else // Si no ingreso ningun campo vacio
                {
                    Usuario user = new Usuario(nombreUsuario, contrasena, null, null, null, null);

                    string aux = DB.Validar(user);
                    if (aux == user.NombreUsuario) // Si el usuario de la db es igual a el de la consulta
                    {
                        userList = DB.TraerUsuarios();
                        ViewData["userList"] = userList;

                        ViewBag.Message = user;
                        this.Session["Login"] = user.Nombre;

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

        [HttpPost]
        public ActionResult Delete()
        {
            

            return View();
        }

    }
    }