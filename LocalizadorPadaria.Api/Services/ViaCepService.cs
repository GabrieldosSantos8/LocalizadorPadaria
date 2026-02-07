using System.Net.Http.Json;
using LocalizadorPadaria.Api.Models;

namespace LocalizadorPadaria.Api.Services;

public interface IViaCepService {
    Task<Padaria?> PreencherEndereco(string nome, string cep);
}

public class ViaCepService : IViaCepService {
    private readonly HttpClient _httpClient;
    public ViaCepService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<Padaria?> PreencherEndereco(string nome, string cep) {
        try {
            // Remove qualquer traço do CEP antes de enviar
            var cepLimpo = cep.Replace("-", "");
            var response = await _httpClient.GetFromJsonAsync<ViaCepResponse>($"https://viacep.com.br/ws/{cepLimpo}/json/");
            
            if (response == null || response.Erro == "true") return null;

            return new Padaria {
                Nome = nome,
                Cep = cepLimpo,
                Logradouro = response.Logradouro,
                Bairro = response.Bairro,
                Cidade = response.Localidade,
                UF = response.Uf
            };
        } catch { return null; }
    }
}

// Record para mapear o JSON do ViaCEP
public record ViaCepResponse(string Logradouro, string Bairro, string Localidade, string Uf, string Erro);