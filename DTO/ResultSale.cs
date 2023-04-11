namespace storeManagerDotNet.DTO
{
    public class ResultSale
    {
        public int Id { get; set; }
        public IEnumerable<SaleDTO> ItemsSold { get; set; } = new List<SaleDTO>();
    }
}
