using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemToDo.Data;
using SystemToDo.Models;

namespace SystemToDo.Repositorios.Interfaces
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApiDbContext _Db;
        public UsuarioRepositorio(ApiDbContext apiDbContext)
        {
            _Db = apiDbContext;
        }
        public async Task<List<UsuarioModel>> GetAllUsuarios()
        {
            return await _Db.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _Db.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> AddUsuario(UsuarioModel usuario)
        {
            await _Db.Usuarios.AddAsync(usuario);
            await _Db.SaveChangesAsync();
            return usuario;

        }


        public async Task<UsuarioModel> EditUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await GetById(id);
            if (usuarioPorId == null)
            {

                throw new Exception($"Erro ao buscar Usuario por Id {id}!");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            _Db.Usuarios.Update(usuarioPorId);
            await _Db.SaveChangesAsync();
            return usuarioPorId;
        }
        public async Task<bool> DeleteUsuario(int id)
        {
            UsuarioModel usuarioPorId = await GetById(id);
            if (usuarioPorId == null)
            {

                throw new Exception($"Erro ao buscar Usuario por Id {id}!");
            }
            _Db.Usuarios.Remove(usuarioPorId);
            await _Db.SaveChangesAsync();
            return true;
        }

    }
}
