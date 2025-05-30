using DTOs.Request;
using DTOs.Response;
using PackingService.Interfaces.Service;

namespace PackingService.Service
{
    public class PackingServiceImp : IPackingService
    {
        #region Public Methods

        public Task<IEnumerable<BoxesResponseDTO>> OrderPackagingAsync(OrdersRequestDTO request)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods


        #endregion
    }
}
