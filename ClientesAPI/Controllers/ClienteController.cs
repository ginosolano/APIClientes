using ClientesAPI.Models;
using ClientesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            this._clienteService = clienteService;
        }
        /// <summary>
        /// Obtiene todos los clientes existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("ver-todos-los-clientes")]
        public IActionResult GetAllClientes()
        {
            List<ClienteEntity> clientes =  this._clienteService.GetAllClientes();
            return Ok(clientes);
        }

        /// <summary>
        /// Crear nuevo cliente ingresando nombres, apellidos, fecha de nacimiento, CUIT, domicilio, telefono celular y email
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost("crear-cliente")]
        public IActionResult CreateCliente([FromBody]ClienteModel cliente)
        {
            _clienteService.CreateCliente(cliente);
            return Ok();
        }

        /// <summary>
        /// Eliminar cliente ingresando ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("eliminar-cliente-por-id")]
        public IActionResult DeleteCliente(int id)
        {
            _clienteService.DeleteCliente(id);
            return Ok();
        }

        /// <summary>
        /// Buscar cliente por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("buscar-cliente-por-id")]
        public IActionResult GetClienteById(int id)
        {
            ClienteEntity cliente = _clienteService.GetClienteById(id);
            return Ok(cliente);
        }
        /// <summary>
        /// Buscar clientes que su nombre contenga la palabra ingresada
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [HttpGet("buscar-cliente-por-nombre")]
        public IActionResult SearchClientesByNombre([FromQuery]string nombre)
        {
            List<ClienteEntity> clientesEncontrados = this._clienteService.SearchClientesByNombre(nombre);
            return Ok(clientesEncontrados); 
        }
        /// <summary>
        /// Modificar domicilio, telefono y email de un cliente mediante su id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPatch("modificar-domicilio-email-y-celular-de-cliente-por-id")]
        public IActionResult UploadCliente(int id,[FromBody] ClienteModel cliente)
        {
            _clienteService.UpdateCliente(id, cliente);
            return NoContent();
        }

        /// <summary>
        /// Modificar todos los datos de un cliente (nombres, apellidos, fecha de nacimiento, CUIT, domicilio, telefono celular y email
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut("modificar-todo-el-cliente-por-id")]
        public IActionResult UploadAllCliente(int id, [FromBody] ClienteModel cliente)
        {
            _clienteService.UpdateAllCliente(id, cliente);
            return NoContent();
        }
        /// <summary>
        /// Buscar clientes que su apellido contenga la palabra ingresada
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [HttpGet("buscar-cliente-por-apellido")]
        public IActionResult SearchClientesByApellido([FromQuery] string apellido)
        {
            List<ClienteEntity> clientesEncontrados = this._clienteService.SearchClientesByApellido(apellido);
            return Ok(clientesEncontrados);
        }

    }
}
