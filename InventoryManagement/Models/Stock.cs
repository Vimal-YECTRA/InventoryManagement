using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Stock
    {
            [Key]
            public int Id { get; set; }
            public string Category { get; set; }
            public string Item { get; set; }
            public int Qty { get; set; }
            public float Price { get; set; }

    }
}
