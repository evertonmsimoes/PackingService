
using PackingService.Entities;

namespace PackingService.Interfaces.Repository
{
    public interface IBoxesRepository
    {
        Task<IEnumerable<Boxes>> GetAllBoxesAsync();
    }
}
