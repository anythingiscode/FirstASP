using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext _context;   //Le ponemos "_" para indicar que es privado

        //Asigno la inyección el el momento en el que creo el constructor
        public BeerController(PubContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var beers = _context.Beers.Include(b => b.Brand);  //Vamos a listar los tipos de cerveza e INCLUIMOS el nombre de la Marca
            return View( await beers.ToListAsync());
        }

        public IActionResult Create()    // No necesitamos que sea async porque no vamos a solicitar información de entrada-salida a la BDD
        {
            /*Guardo la info en un ViewData que es un diccionario que se puede acceder desde la vista
               ponemos entre [] el nombre del ViewData y le pasamos la ifo:
                en este caso una lista con SelectList (comboBox) : donde está la info, Que usa el cbo para buscar la info"BrandId", Que info aparece "Name"  */
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");

            return View();
        }

        [HttpPost]
        //Esto es para seguridad:Con esto nos aseguramos que la solicitud viene de nuestro dominio y no de fuera
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel model)      //Se diferenciará del anterior create porque este pasa variables. Le pasamos un obj model de la clase BeerViewModel
        {
            // 1º - Confirmamos que las validaciones pasan. Las validaciones están en el BeerViewModel
            if (ModelState.IsValid)
            {
                //Guardamos en EntityFramework
                var beer = new Beer()
                {
                    Name = model.Name,
                    BrandId = model.BrandId
                };
                //Lo agregamos al contexto --> 54'
                _context.Add(beer);     //--> OJO!!! Con esto todabía no se guarda nada en la BDD. Hay que enviarlo
                await _context.SaveChangesAsync();  // Ahora SÍ se guarda

                //Cuando acaba la grabación redirijo a la view
                return RedirectToAction(nameof(Index));
            }
            // Si no son válidos se volveran a cargar los datos en el cbo
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId);

            return View(model);
        }
    }
}
