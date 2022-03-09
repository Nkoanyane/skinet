namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Desciption { get; set; }  
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductBrand ProductBrand { get; set; }  
        public int ProductBrandId { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
    }
}