using System.Collections;

namespace storeManagerDotNet.DTO
{
    public class SalesDTO
    {
        public List<SaleDTO> Sales { get; set; } = new List<SaleDTO>();

        public IEnumerator<SaleDTO> GetEnumerator()
        {
            return Sales.GetEnumerator();
        }
    }
}
