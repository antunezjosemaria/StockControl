using System;

namespace StockControlWeb.Models
{
    public class ProductoViewModel
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Codigo { get; set; }
        public string ProductoName { get; set; }
        public decimal PrecioVenta { get; set; }
        public string PrecioCompra { get; set; }
        public int Cantidad { get; set; }
        public Nullable<int> Activo { get; set; }
        public Nullable<int> Stock { get; set; }
        
        public string CategoriaName { get; set; }
    }
}