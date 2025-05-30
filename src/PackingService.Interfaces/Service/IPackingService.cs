using DTOs.Request;
using DTOs.Response;


namespace PackingService.Interfaces.Service
{
    public interface IPackingService
    {

        Task<IEnumerable<BoxesResponseDTO>> OrderPackagingAsync(OrdersRequestDTO request);

    }
}
