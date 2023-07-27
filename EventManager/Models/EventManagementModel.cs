namespace EventManager.Models
{
    public class EventManagementModel
    {
        public int KOLEventId { get; set; }
        public int KOLId { get; set; }
        public string KolFirstName { get; set;}
        public string KolLastName { get; set; }
        public string KolCountry { get; set;}
        public string KOLCreatedBy { get; set;}
        public string KOLEmail { get; set;}
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventType { get; set; }
        public string EventCountry { get; set; }
        public string EventCreatedBy { get; set; }
        public string EventStartDate { get; set; }
        public string EventEndDate { get; set; }
        public string BusinessOwner { get;set; }
    }
}
