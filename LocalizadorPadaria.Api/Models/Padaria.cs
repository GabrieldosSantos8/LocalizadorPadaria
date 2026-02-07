namespace LocalizadorPadaria.Api.Models;

public class Padaria 
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? UF { get; set; }
}