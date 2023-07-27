using EventManager.Data;
using EventManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Repository
{
    public class EventManagementRepository: IEventManagementRepository
    {
        private readonly EventContext _context;

        public EventManagementRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<List<EventManagementModel>> GetEventDetailAsync(int eventId)
        {
            var records = await (from x in _context.Event
                          join y in _context.KOLEvent on x.EventId equals y.EventId
                          join z in _context.KOL on y.KOLId equals z.KOLId
                          where x.EventId == eventId
                          select new EventManagementModel()
                          {
                              KOLEventId =  y.Id,
                              EventTitle = x.EventTitle,
                              EventStartDate = x.StartDate.ToString(),
                              EventEndDate = x.EndDate.ToString(),
                              KolFirstName = z.FirstName,
                              KolLastName = z.LastName                              
                          }).ToListAsync();
            return records;
        }

        public async Task<int> AddKOLToGivenEventAsync(int kolId, int eventId)
        {
            var kolevent = new KOLEvent()
            {
               KOLId = kolId,
               EventId = eventId
            };
            _context.KOLEvent.Add(kolevent);
            await _context.SaveChangesAsync();
            return kolevent.Id;
        }

        public async Task RemoveKOLFromEventAsync(int kolId,int eventId)
        {
            var removeKOL = await _context.KOLEvent.Where(x => x.KOLId == kolId && x.EventId == eventId).Select(x => new KOLEvent()
            {
                Id = x.Id,
                KOLId = x.KOLId,
                EventId = x.EventId               
            }).FirstOrDefaultAsync();

            _context.KOLEvent.Remove(removeKOL);            
            await _context.SaveChangesAsync();
        }

    }
}
