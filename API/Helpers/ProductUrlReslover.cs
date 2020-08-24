using AutoMapper;
using core.Entities;
using API.Helpers;
using API.Dtos;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductUrlReslover : IValueResolver<product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlReslover(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.pictureurl))
           {
               return _config["ApiUrl"] + source.pictureurl;

           }
            return null;
        }
    }
}