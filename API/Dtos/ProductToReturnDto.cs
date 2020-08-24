namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Desc { get; set; }
        public decimal price { get; set; }
        public string pictureurl { get; set; }
        public string    ProductType { get; set; }
       
        public string ProductBrand { get; set; }
       
         
    }
}