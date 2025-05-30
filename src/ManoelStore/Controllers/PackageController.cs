using DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using PackingService.Interfaces.Service;

namespace PackingService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackingService _packingService;

        public PackageController(IPackingService packingService)
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
        public async Task<IActionResult> ReturnBoxesOrders([FromBody] OrdersRequestDTO request)
        {
            var result = await _packingService.OrderPackagingAsync(request);
            return Ok(result);
        }

        [HttpGet("boxes")]
        public IActionResult GetAllBoxes()
        {
            var boxes = _packingService.GetAllBoxes();
            return Ok(boxes);
        }
    }
}
