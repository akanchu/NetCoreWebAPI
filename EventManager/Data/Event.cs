namespace EventManager.Data
{
    public class Event
    {
        public int EventId { get; set; }
        public int? EventTypeId { get; set; }
        public string EventTitle { get; set; }
        public int? CountryId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BusinessOwnerId { get; set; }
        public Boolean IsDeleted { get; set; }
        public string EventIcon { get; set; }

    }
}
