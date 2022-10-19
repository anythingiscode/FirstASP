using System.ComponentModel.DataAnnotations;

namespace IntroASP.Models.ViewModels
{
    public class BeerViewModel      //Aquí ponemos los campos que necesito para el formulario CREAR
    {
        [Required]                      // Con esto y la siguiente linea config nuestros campos. [Required] == Obligatorio
        [Display(Name = "Marca")]
        public int BrandId { get; set; }

        [Required]
        [Display(Name = "Nombre")]        // Que ponga "Nombre" en lugar de Name
        public string Name { get; set; }
    }
}
