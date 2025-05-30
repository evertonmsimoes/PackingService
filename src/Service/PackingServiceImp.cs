using DTOs.Request;
using DTOs.Response;
using PackingService.Entities;
using PackingService.Interfaces.Service;
using PackingService.Repository;

namespace PackingService.Service
{
    public class PackingServiceImp : IPackingService
    {

        private readonly PackingDbContext _context;

        public PackingServiceImp(PackingDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Public Methods

        public Task<IEnumerable<BoxesResponseDTO>> OrderPackagingAsync(OrdersRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Boxes> GetAllBoxes()
        {
            return _context.Boxes.ToList();
        }



        #endregion

        #region Private Methods


        #endregion
    }
}
