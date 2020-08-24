using System;
using System.Linq.Expressions;
using core.Entities;

namespace core.Specifications
{
    public class ProductsWithTypesandsSpecification : BaseSpecification<product>
    {
        public ProductsWithTypesandsSpecification()
        {
            AddInclude(x =>x.ProductType);
            AddInclude(x =>x.ProductBrand);
        }

        public ProductsWithTypesandsSpecification(int id) : base(x=>x.Id == id)
        { 
            AddInclude(x =>x.ProductType);
            AddInclude(x =>x.ProductBrand);

        }
    }
}