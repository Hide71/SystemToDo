﻿using SystemToDo.Integracao.Interfaces;
using SystemToDo.Integracao.Refit;
using SystemToDo.Integracao.Response;

namespace SystemToDo.Integracao
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        public readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;
        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit)
        {
            _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }
        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var responseData = await _viaCepIntegracaoRefit.ObterDadosViaCep(cep);
            if(responseData != null && responseData.IsSuccessStatusCode) {

                return responseData.Content;
            }
            return null;
        }
    }
}
