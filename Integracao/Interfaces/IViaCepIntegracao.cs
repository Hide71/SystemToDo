using SystemToDo.Integracao.Response;

namespace SystemToDo.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse>ObterDadosViaCep(string cep);
    }
}
