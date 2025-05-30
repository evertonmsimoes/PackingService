
using System.Text.Json.Serialization;

namespace PackingService.DTOs
{
    public class BoxesDTO
    {
        [JsonPropertyName("caixa_id")]
        public required string CaixaId { get; set; }
        public required List<string> Produtos { get; set; }
    }
}
