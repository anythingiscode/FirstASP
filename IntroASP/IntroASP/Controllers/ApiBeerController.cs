using IntroASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    // Con esto podemos hacer validaciones en Back-end de las acciones que se hacen en Front-end

    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {
        private readonly PubContext _context;

        public ApiBeerController(PubContext context)
        {
            _context = context;
        }

        public async Task<List<Beer>> Get()
            => await _context.Beers.ToListAsync();      // 
        //Nos devuelve una lista en formato Json
        //Al insertar también el Inclulde nos manda el nombre de la ceveza y la marca (Include(b=> b.Brand))
    }
}
