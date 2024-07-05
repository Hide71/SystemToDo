using SystemToDo.Models;

namespace SystemToDo.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> GetAllTarefa();
        Task<TarefaModel> GetById(int id);
        Task<TarefaModel> AddTarefa(TarefaModel tarefa);
        Task<TarefaModel> EditTarefa(TarefaModel tarefa, int id);
        Task<bool> DeleteTarefa(int id);

    }
}
