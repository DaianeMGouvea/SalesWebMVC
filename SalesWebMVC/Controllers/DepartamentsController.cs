using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartamentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departement> departes = new List<Departement>();
            departes.Add(new Departement { Id = 1, Name = "Eletronics" });
            departes.Add(new Departement { Id = 1, Name = "Fashions" });

            return View(departes);
        }
    }
}
