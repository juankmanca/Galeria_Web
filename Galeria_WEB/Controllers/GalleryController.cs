using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Galeria_WEB.DAO;
using Galeria_WEB.Models.Clases;

namespace Galeria_WEB.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View("Welcome");
        }
        
        public ActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete()
        {
            string name = Request["username"];
            string session = Request["session"];
            Usuario user = new Usuario(name, null, null, null, null, null);

            Usuario userLoged = new Usuario(session, null, null, null, null, null);

            daoDelete dbDelete = new daoDelete();
            daoRead dbRead = new daoRead();
            if (dbDelete.EliminarRegistro(user))
            {

                ViewData["userList"] = dbRead.TraerUsuarios();
                ViewBag.Message = userLoged;
                return View("Welcome");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit()
        {

            string username = Request["username"];
            string session = Request["session"];
            Usuario user = new Usuario(username, null, null, null, null, null);

            Usuario userLoged = new Usuario(session, null, null, null, null, null);

            ViewBag.Message = userLoged;
            ViewBag.user = user.NombreUsuario;
            return View();
        }

        [HttpPost]
        public ActionResult EditData()
        {
            string name = Request["username"];
            string session = Request["session"];
            string newPass = Request["password"];

            Usuario user = new Usuario(name, newPass, null, null, null, null);

            Usuario userLoged = new Usuario(session, null, null, null, null, null);

            daoUpdate dbUpdate = new daoUpdate();
            daoRead dbRead = new daoRead();
            if (dbUpdate.ActualizarContrasena(user))
            {

                ViewData["userList"] = dbRead.TraerUsuarios();
                ViewBag.Message = userLoged;
                return View("Welcome");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult ValidarLogin()
        {
            BaseDatos DB = new BaseDatos();
            daoRead dbRead = new daoRead();
            List<Usuario> userList = new List<Usuario>();

            string nombreUsuario = Request["Username"];
            string contrasena = Request["password"];
            if (nombreUsuario.Equals("") || contrasena.Equals(""))
            {
                //ViewData["Error"] = "Todos los campos son obligatorios";

                return RedirectToAction("Index", "Home", new { msg = "Todos los campos son obligatorios" });
            }
            else // Si no ingreso ningun campo vacio
            {
                Usuario user = new Usuario(nombreUsuario, contrasena, null, null, null, null);

                string aux = dbRead.ValidarUserPass(user);
                if (aux == user.NombreUsuario) // Si el usuario de la db es igual a el de la consulta
                {
                    userList = dbRead.TraerUsuarios();
                    ViewData["userList"] = userList;

                    this.Session["Login"] = user.NombreUsuario;
                    ViewBag.Message = user;

                    //ViewBag.Message = user;
                    //this.Session["Login"] = user.Nombre;

                    return View("Welcome");
                }
                else
                {
                   // ViewData["Error"] = aux;
                    //return View("Home/index");

                    return RedirectToAction("Index", "Home", new { msg = aux });
                }
            }
        }

        [HttpPost]
        public ActionResult ValidarRegistro()
        {
            daoCreate dbCreate = new daoCreate();
            daoRead dbRead = new daoRead();
            List<Usuario> userList = new List<Usuario>();
            
                string nombre = Request["name"];
                string cedula = Request["id"];
                string correo = Request["mail"];
                string contrasena = Request["pass"];
                string nombreUsuario = Request["username"];
                string avatar = Request["charachter"];
                //Validar si hay algun campo vacio
                if (nombre.Equals("") || cedula.Equals("") || correo.Equals("") || contrasena.Equals("") || nombreUsuario.Equals("") || avatar.Equals(""))
                {
                return RedirectToAction("Registro", "Home/Registro", new { msg = "Todos los campos son obligatorios" });
                //return View("Home/Registro");
                }
                else //  Si ningun campo esta vacio
                {
                    Usuario user = new Usuario(nombreUsuario, contrasena, avatar, cedula, nombre, correo);

                    int aux = dbCreate.InsertUser(user);
                    if (aux == 0) //  Si no hubo error
                    {
                        userList = dbRead.TraerUsuarios();
                        ViewData["userList"] = userList;
                        this.Session["Login"] = user.NombreUsuario;
                        ViewBag.Message = user;
                        return View("Welcome");
                    }
                    else if (aux == 1) // Si ingreso un campo erroneo
                    {

                    return RedirectToAction("Registro", "Home/Registro", new { msg = "Error al ingresar los campos" });
                }
                    else  // Ingreso un nombre de usuario que ya existe
                    {
                    return RedirectToAction("Registro", "Home/Registro", new { msg = "Este usuario ya existe" });
                }
                }
            }
        }
    }
