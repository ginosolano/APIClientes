using ClientesAPI.Data;
using ClientesAPI.Models;

namespace ClientesAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClientesDbContext _context;
        public ClienteService(ClientesDbContext context)
        {
            this._context = context;
        }

        public void CreateCliente(ClienteModel cliente)
        {
            ClienteEntity clienteEntity = new()
            {
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                FechaDeNacimiento = cliente.FechaDeNacimiento,
                CUIT = cliente.CUIT,
                Domicilio = cliente.Domicilio,
                TelefonoCelular = cliente.TelefonoCelular,
                Email = cliente.Email,
            };

            _context.Clientes.Add(clienteEntity);
            _context.SaveChanges();
        }

        public void DeleteCliente(int id)
        {
            ClienteEntity clienteToDelete = this.GetClienteById(id);
            _context.Clientes.Remove(clienteToDelete);
            _context.SaveChanges();
        }

        public ClienteEntity GetClienteById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public List<ClienteEntity> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }

        public void UpdateCliente(int id, ClienteModel cliente)
        {
            var clienteToUpdate = this.GetClienteById(id);

            if (clienteToUpdate != null)
            {
                clienteToUpdate.Domicilio = cliente.Domicilio;
                clienteToUpdate.TelefonoCelular = cliente.TelefonoCelular;
                clienteToUpdate.Email = cliente.Email;

                _context.SaveChanges();
            }
        }

        public void UpdateAllCliente(int id, ClienteModel cliente)
        {
            var clienteToUpdate = this.GetClienteById(id);

            if (clienteToUpdate != null)
            {
                clienteToUpdate.Nombres = cliente.Nombres;
                clienteToUpdate.Apellidos = cliente.Apellidos;
                clienteToUpdate.FechaDeNacimiento = cliente.FechaDeNacimiento;
                clienteToUpdate.CUIT= cliente.CUIT;
                clienteToUpdate.Domicilio = cliente.Domicilio;
                clienteToUpdate.TelefonoCelular = cliente.TelefonoCelular;
                clienteToUpdate.Email = cliente.Email;

                _context.SaveChanges();
            }
        }

        public List<ClienteEntity> SearchClientesByNombre(string nombre)
        {
            return _context.Clientes.Where(c=>c.Nombres.Contains(nombre)).ToList();
        }

        public List<ClienteEntity> SearchClientesByApellido(string apellido)
        {
            return _context.Clientes.Where(c => c.Apellidos.Contains(apellido)).ToList();
        }
    }
}
