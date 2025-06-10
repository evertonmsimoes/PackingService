using System.Text.Json.Serialization;

namespace DTOs
{
    public class DimensionDTO
    {
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }

        [JsonIgnore]
        public int Volume => Altura * Largura * Comprimento;
    }
}
