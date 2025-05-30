using System.Text.Json.Serialization;

namespace DTOs
{
    public class OrderDTO
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }
        public required List<ProductDTO> Produtos { get; set; }

    }
}
