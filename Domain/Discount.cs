namespace Domain
{
    public class Discount
    {
        public int Id {get; set;}
        public DiscountType DiscountType { get; set; }
        public int DiscountPercentage {get; set;}
    }

    public enum DiscountType
    {
        Silver,
        Gold,
        Platinum
    }
}