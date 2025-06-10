using DTOs.Request;
using DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using PackingService.Entities;
using PackingService.Interfaces.Service;

namespace PackingService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageManagementController : ControllerBase
    {
        private readonly IPackingService _packingService;

        public PackageManagementController(IPackingService packingService)
        {
            _packingService = packingService;
        }



        /// <summary>
        /// Retorna as melhores caixas para o pedido.
        /// </summary>
        /// <remarks>
        /// Esse endpoint retorna uma lista com as melhores caixas e a disposição ideal dos produtos para cada pedido enviado.
        /// </remarks>
        [HttpPost("box")]
        public async Task<ActionResult<IEnumerable<BoxesResponseDTO>>> ReturnBoxesOrders([FromBody] OrdersRequestDTO request)
        {
            var result = await _packingService.OrderPackagingAsync(request);
            return Ok(result);
        }

        [HttpGet("boxes")]
        public async Task<ActionResult<IEnumerable<Boxes>>> GetAllBoxesAsync()
        {
            var boxes = await _packingService.GetAllBoxes();
            return Ok(boxes);
        }
    }
}
