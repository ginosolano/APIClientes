using System.ComponentModel.DataAnnotations;

namespace ClientesAPI.Models
{
    public class ClienteModel
    {
        [Required(ErrorMessage = "Nombres es campo obligatorio")]
        public  string Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos es campo obligatorio")]
        public  string Apellidos { get; set; }

        [Display(Name ="Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime FechaDeNacimiento { get; set; }

        [Required(ErrorMessage = "CUIT es campo obligatorio")]
        [DisplayFormat(DataFormatString ="0:00-00000000-0",ApplyFormatInEditMode =true)]
        public string CUIT { get; set; }

        public string? Domicilio { get; set; }

        [Required(ErrorMessage = "Telefono celular es campo obligatorio" )]
        [Phone(ErrorMessage ="Los datos ingresados no corresponden a un formato de celular")]
        public string TelefonoCelular { get; set; }

        [Required(ErrorMessage ="Email es campo obligatorio")]
        [EmailAddress(ErrorMessage ="Los datos ingresados no corresponden a un formato de email")]
        public string Email { get; set; }
    }
}
