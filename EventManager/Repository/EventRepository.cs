using EventManager.Data;
using EventManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context;

        public EventRepository(EventContext context)
        {
            _context = context;
        }
        public async Task<List<EventModel>> GetAllEventsAsync()
        {
            var records = await _context.Event.Select(x => new EventModel()
            {
                BusinessOwnerId = x.BusinessOwnerId,
                CountryId = x.CountryId,
                CreatedBy = x.CreatedBy,
                EventId = x.EventId,
                EventTitle = x.EventTitle,
                EventIcon = x.EventIcon,
                EventTypeId = x.EventTypeId,
                EndDate = x.EndDate,
                IsDeleted = x.IsDeleted,
                StartDate = x.StartDate
            }).ToListAsync();
            return records;
        }
        public async Task<EventModel> GetEventByIdAsync(int eventId)
        {
            var records = await _context.Event.Where(x => x.EventId == eventId).Select(x => new EventModel()
            {
                BusinessOwnerId = x.BusinessOwnerId,
                CountryId = x.CountryId,
                CreatedBy = x.CreatedBy,
                EventId = x.EventId,
                EventTitle = x.EventTitle,
                EventIcon = x.EventIcon,
                EventTypeId = x.EventTypeId,
                EndDate = x.EndDate,
                IsDeleted = x.IsDeleted,
                StartDate = x.StartDate
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddEventAsync(EventModel eventModel)
        {
            var events = new Event()
            {
                BusinessOwnerId = eventModel.BusinessOwnerId,
                CountryId = eventModel.CountryId,
                CreatedBy = eventModel.CreatedBy,
                EventId = eventModel.EventId,
                EventTitle = eventModel.EventTitle,
                EventIcon = eventModel.EventIcon,
                EventTypeId = eventModel.EventTypeId,
                EndDate = eventModel.EndDate,
                IsDeleted = eventModel.IsDeleted,
                StartDate = eventModel.StartDate
            };
            _context.Event.Add(events);
            await _context.SaveChangesAsync();
            return events.EventId;
        }

        public async Task UpdateEventAsync(int eventId, EventModel eventModel)
        {
            var events = new Event()
            {
                BusinessOwnerId = eventModel.BusinessOwnerId,
                CountryId = eventModel.CountryId,
                CreatedBy = eventModel.CreatedBy,
                EventId = eventModel.EventId,
                EventTitle = eventModel.EventTitle,
                EventIcon = eventModel.EventIcon,
                EventTypeId = eventModel.EventTypeId,
                EndDate = eventModel.EndDate,
                IsDeleted = eventModel.IsDeleted,
                StartDate = eventModel.StartDate
            };
            _context.Event.Update(events);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var events = new Event() { EventId = eventId };
            _context.Event.Remove(events);
            await _context.SaveChangesAsync();
        }
    }
}
