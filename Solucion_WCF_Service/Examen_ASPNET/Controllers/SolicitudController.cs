using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen_ASPNET.ServiceReference1;

namespace Examen_ASPNET.Controllers
{
    public class SolicitudController : Controller
    {
        // Instancia de Service1Client

        Service1Client servicio = new Service1Client();
        public ActionResult ListadoSolicitud()
        {
            return View(servicio.Solicitudes());
        }
        public ActionResult AgregarSolicitud()
        {
            ViewBag.actividad = new SelectList(servicio.Actividades(), "idact", "desact");

            return View(new Solicitud()); 
        }

        [HttpPost] public ActionResult AgregarSolicitud(Solicitud reg) 
        { 
            ViewBag.mensaje = servicio.Agregar(reg); 
            ViewBag.actividad = new SelectList(servicio.Actividades(), "idact", "desact", reg.idact); 

            return View(reg);

        }
    }
}