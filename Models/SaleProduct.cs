﻿namespace storeManagerDotNet.Models;

public class SaleProduct
{
    public int SaleId { get; set; }
    public Sale? Sale { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    
    
}
