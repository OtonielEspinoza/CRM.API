using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.DTOs.CustomerDTOs
{
   public class CreateCustomerDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es Obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo nombre no puede tener mas de 50 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es Obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener mas de 50 caracteres.")]
        public string LastName { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(255, ErrorMessage = "El campo Direccion no puede tener mas de 255 caracteres.")]
        public string? Address { get; set; }
    }
}
