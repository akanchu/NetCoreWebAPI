using EventManager.Models;

namespace EventManager.Repository
{
    public interface IKOLRepository
    {
        Task<List<KOLModel>> GetAllKOLsAsync();
        Task<KOLModel> GetKOLByIdAsync(int kolId);
        Task<int> AddKOLAsync(KOLModel kolModel);
        Task UpdateKOLAsync(int kolId, KOLModel kolModel);
        Task DeleteKOLAsync(int kolId);
    }
}
