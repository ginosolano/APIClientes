using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace ClientesAPI.Models
{
    public class ClienteEntity
    {
        [Key]
        public int ID { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public required string CUIT { get; set; }
        public string? Domicilio { get; set; }
        public required string TelefonoCelular { get; set; }
        
        public required string Email { get; set; }

    }
}
