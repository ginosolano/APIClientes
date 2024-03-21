using ClientesAPI.Models;

namespace ClientesAPI.Services
{
    public interface IClienteService
    {
        void CreateCliente(ClienteModel cliente);
        void DeleteCliente(int id);
        List<ClienteEntity> GetAllClientes();
        ClienteEntity GetClienteById(int id);
        void UpdateCliente(int id, ClienteModel cliente);
        void UpdateAllCliente(int id, ClienteModel cliente);
        List<ClienteEntity> SearchClientesByNombre(string nombre);
        List<ClienteEntity> SearchClientesByApellido(string apellido);
    }
}