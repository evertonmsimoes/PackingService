
using DTOs;
using System.Text.Json.Serialization;

namespace PackingService.DTOs
{
    public class BoxesDTO
    {
        [JsonPropertyName("caixa_id")]
        public required string? CaixaId { get; set; }
        public required List<string> Produtos { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Observacao { get; set; }
    }
}
