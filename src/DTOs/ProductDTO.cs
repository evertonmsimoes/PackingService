using System.Text.Json.Serialization;

namespace DTOs
{
    public class ProductDTO
    {
        [JsonPropertyName("produto_id")]
        public required string ProdutoId { get; set; }
        public required DimensionDTO Dimensoes { get; set; }
    }
}
