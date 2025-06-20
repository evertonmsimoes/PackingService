﻿using PackingService.DTOs;
using System.Text.Json.Serialization;

namespace DTOs.Response
{
    public class BoxesResponseDTO
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }
        public required IEnumerable<BoxesDTO> Caixas { get; set; }
    }
}
