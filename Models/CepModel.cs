using System.Text.Json.Serialization;

namespace Paralelismo.Models //4° Criado a classe com os metodos para buscar informações na API
{
    public class CepModels
    {
        [JsonPropertyName("cep")] //5° métodos com o parametro JsonPropertyName é importado de Serialization
        public string Cep {get; set;}

        [JsonPropertyName("logradouro")]
        public string Logradouro {get; set;}

        [JsonPropertyName("complemento")]
        public string Complemento {get; set;}

        [JsonPropertyName("bairro")]
        public string Bairro {get; set;}

        [JsonPropertyName("localidade")]
        public string Localidade {get; set;}

        [JsonPropertyName("uf")]
        public string Uf {get; set;}

        [JsonPropertyName("ibge")]
        public string Ibge {get; set;}

        [JsonPropertyName("gia")]
        public string Gia {get; set;}

        [JsonPropertyName("ddd")]
        public string Ddd {get; set;}

        [JsonPropertyName("siafi")]
        public string Siafi {get; set;}

        public override string ToString() //6° para toda vez que chamarmos a classe CepModel seja apresentado o json
        {
            return $"{this.Cep} - {this.Uf} - {this.Bairro} - {this.Localidade}";
        }

    }
}