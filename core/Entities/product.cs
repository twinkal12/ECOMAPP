namespace core.Entities
{
    public class product :BaseEntities
    {
        public string Name {get; set;}
        public string Desc { get; set; }
        public decimal price { get; set; }
        public string pictureurl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProducTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
         
    }
}