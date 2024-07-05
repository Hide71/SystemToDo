using Microsoft.EntityFrameworkCore;
using SystemToDo.Data;
using SystemToDo.Models;

namespace SystemToDo.Repositorios.Interfaces
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly ApiDbContext _Db;
        public TarefaRepositorio(ApiDbContext db )
        {
            _Db = db;
        }
        public async Task<List<TarefaModel>> GetAllTarefa()
        {
            return await _Db.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();

        }

        public async Task<TarefaModel> GetById(int id)
        {
            return await _Db.Tarefas
                .Include( x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TarefaModel> AddTarefa(TarefaModel tarefa)
        {
            await _Db.Tarefas.AddAsync(tarefa);
            await _Db.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> DeleteTarefa(int id)
        {
            TarefaModel tarefaporId = await GetById(id);
            if(tarefaporId == null)
            {
                throw new Exception("Id não foi encontrado!");
            }

            _Db.Tarefas.Remove(tarefaporId);
            await _Db.SaveChangesAsync();
            return true;
        }

        public async Task<TarefaModel> EditTarefa(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await GetById(id);
            if(tarefaPorId == null)
            {
                throw new Exception("Erro ao buscar id!");

            }
            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;
            _Db.Tarefas.Update(tarefaPorId);
            await _Db.SaveChangesAsync();
            return tarefaPorId;
        }

        
    }
}
