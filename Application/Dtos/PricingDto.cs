namespace Application.Dtos
{
    public interface IDto
    {

    }
    public enum PricingType
    {
        Unknown = 0,
        Unitary = 1,
        Discount = 2,
        Bundle = 3,
    }
    public class PricingDto : IDto
    {
        public PricingType PricingType { get; set; }
        public int ProductId { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
