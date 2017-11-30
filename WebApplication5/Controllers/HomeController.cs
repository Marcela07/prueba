using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller { 


        List<WebApplication5.Models.Profesor> listado = new List<WebApplication5.Models.Profesor>();
       
        public HomeController()
    {
            listado
        .Add(new Profesor {cg=1, rut = "16.112.333-2", nombre = "Juan Soto Riquelme", titulo = "Montaner Saldivia", grado = "Ingeniero" });
            listado
            .Add(new Profesor { cg = 2,rut = "17.254.362-5", nombre = "Maria Ester Rosas Sotomayor ", titulo = "Montaner Saldivia", grado = "Tecnico" });
        listado
                .Add(new Profesor { cg = 3, rut = "18.254.125-4", nombre = "Pedro Urdemales Perez", titulo = "Montaner Saldivia", grado = "Doctor"});

        
    }


    
        public IActionResult Index()
        {
            return View(new WebApplication5.Models.Profesor());
        }

        public IActionResult About()
        {
            ViewData["Title"] = "Ficha Profesor";

            return View(listado);
           
        }
        [HttpPost]
        public ActionResult Contact(int cg, string rut, string nombre, string titulo, string grado)
        {

            WebApplication5.Models.Profesor nuevo = new WebApplication5.Models.Profesor()
            {
                cg= cg,
                rut = rut,  
                nombre = nombre,
                titulo = titulo,
                grado = grado,
               
            };
           

            return View(nuevo);
        }
        private WebApplication5.Models.Profesor BuscarProfesor(int cg)
        {
            WebApplication5.Models.Profesor nueva = new Models.Profesor();
            foreach (WebApplication5.Models.Profesor profesor in listado)
            {
                if (profesor.cg == cg)
                {
                    nueva = profesor;
                }
            }
            return nueva;
        }
        public IActionResult Visualizar(int cg)
        {
            WebApplication5.Models.Profesor nueva = BuscarProfesor(cg);

            if (nueva != null)
            {
                return View("Contact", nueva);
            }
            return View("Listado", listado);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
