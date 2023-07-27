using EventManager.Models;

namespace EventManager.Repository
{
    public interface IEventManagementRepository
    {
        Task<List<EventManagementModel>> GetEventDetailAsync(int eventId);
        Task<int> AddKOLToGivenEventAsync(int kolId, int eventId);
        Task RemoveKOLFromEventAsync(int kolId, int eventId);
    }
}
