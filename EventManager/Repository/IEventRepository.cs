using EventManager.Models;

namespace EventManager.Repository
{
    public interface IEventRepository
    {
        Task<List<EventModel>> GetAllEventsAsync();
        Task<EventModel> GetEventByIdAsync(int eventId);
        Task<int> AddEventAsync(EventModel eventModel);
        Task UpdateEventAsync(int eventId, EventModel eventModel);
        Task DeleteEventAsync(int eventId);
    }
}
