namespace Obj_Opg_Indkøbskurv
{
    internal class Products
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public bool IsLimited { get; set; }

        public Products()
        {
            id = 0;
            Title = string.Empty;
            Stock = 0;
            Price = 0;
            IsLimited = false;
        }

        public Products(int id, string title, int stock, double price, bool isLimited)
        {
            id = id;
            Title = title;
            Stock = stock;
            Price = price;
            IsLimited = isLimited;
        }
    }
}
