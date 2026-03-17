#  LocalizadorPadaria API

API desenvolvida em **ASP.NET Core 9** para o cadastro de padarias, com integração automática de endereço via CEP. Este projeto demonstra competências em consumo de APIs externas, arquitetura de serviços e persistência de dados.

---

##  Diferenciais Técnicos
* **Consumo de API Externa:** Integração com o serviço [ViaCEP](https://viacep.com.br/) para preenchimento automático de morada.
* **HttpClientFactory:** Implementação de boas práticas para requisições HTTP assíncronas.
* **Injeção de Dependência:** Desacoplamento da lógica através de um Service dedicado.
* **Persistência de Dados:** Uso de Entity Framework Core com **SQLite** para portabilidade.
* **Documentação:** Interface interativa via **Swagger**.

##  Tecnologias Utilizadas
* **Linguagem:** C# (.NET 9.0)
* **Framework:** ASP.NET Core Web API
* **Banco de Dados:** SQLite
* **Integração:** ViaCEP API (JSON)

##  Como funciona?
Ao cadastrar uma nova padaria enviando apenas o **Nome** e o **CEP**, a API:
1. Valida o formato do CEP.
2. Consulta o serviço externo ViaCEP.
3. Preenche automaticamente os campos de Logradouro, Bairro, Cidade e UF.
4. Salva o registo completo no banco de dados local.

##Executar a aplicação
````bash
dotnet run
````
A API estará disponível em: http://localhost:5000/Swagger ou https://localhost:5001/Swagger

##  Como Executar Localmente
````
1. **Clone o repositório:**
   ```bash
   git clone [https://github.com/GabrieldosSantos8/LocalizadorPadaria.git](https://github.com/GabrieldosSantos8/LocalizadorPadaria.git)
