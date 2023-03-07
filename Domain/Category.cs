

namespace Domain
{
    public class Category
    {
        public int Id {get; set;}
        public CategoryType CategoryType { get; set; }
        public int DailyChargePerHour {get; set;}

        public int OvernightChargePerHour {get;set;}
        public int SpacesUsed {get; set;}
    }

    public enum CategoryType
    {
        A,
        B,
        C
    }
}