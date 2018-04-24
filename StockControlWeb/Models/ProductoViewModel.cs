namespace StockControlWeb.Models
{
    public class ProductoViewModel
    {
        public int ProductoId { get; set; }
        public string ProductoName { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int CategoriaId { get; set; }

        //public virtual Categoria Categoria { get; set; }
        public string CategoriaName { get; set; }
    }
}