using System.Text.Json;
using Paralelismo.Models;

namespace Paralelismo
{
    public class ViaCepServices //7° criado a classe ViaCepServices para apontar a url da api e realizar o filtro da consutla
    {
        public CepModels GetCep(String cep) //8°
        {
            var client = new HttpClient(); // 9° a variavel que vai receber o endereço da api
            var response = client.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;  // 10°variavel que vai receber a resposta do cliente
            var content = response.Content.ReadAsStringAsync().Result; // 11° criando metodo para buscar as infos em formato de string
            var cepResult = JsonSerializer.Deserialize<CepModels>(content); // 12° criado uma variavel que vai receber as informações do content em formato
            //string buscada dentro de CepModels que esta na classe CepModels

            return cepResult; // 13° retornando os valores


        }
    }
}