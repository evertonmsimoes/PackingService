using DTOs.Request;
using DTOs.Response;
using PackingService.Entities;


namespace PackingService.Interfaces.Service
{
    public interface IPackingService
    {

        Task<IEnumerable<BoxesResponseDTO>> OrderPackagingAsync(OrdersRequestDTO request);
        Task<IEnumerable<Boxes>> GetAllBoxes();

    }
}
