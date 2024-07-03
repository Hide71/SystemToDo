using SystemToDo.Models;

namespace SystemToDo.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAllUsuarios();

        Task<UsuarioModel> GetById(int id);

        Task<UsuarioModel> AddUsuario(UsuarioModel usuario);

        Task<UsuarioModel> EditUsuario(UsuarioModel usuario, int id);

        Task<bool> DeleteUsuario(int id);

    }
}
