using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BrandController : Controller
    {
        //Modificar el controlador para que nos devuelva la info de la BDD

        private readonly PubContext _context;   //Le ponemos "_" para indicar que es privado

        //Asigno la inyección el el momento en el que creo el constructor
        public BrandController(PubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _context.Brands.ToListAsync());  //De forma async traemos la lista de obj del tipo Brand
        }
    }
}
