namespace EventManager.Data
{
    public class KOL
    {
        public int KOLId { get; set; }
        public int CountryId { get; set; }
        public int? CreatedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
