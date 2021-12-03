using AutoMapper;
using System;

namespace Winter
{
    //public class ProductProfile : Profile
    //{
    //    public ProductProfile()
    //    {
    //        CreateMap<Product, ProductOM>()
    //            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
    //            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName))
    //            .ForMember(dest => dest.ProductFile, opt => opt.MapFrom(src => src.Files));

    //        CreateMap<ProductIM, Product>()
    //            .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now));

    //    }

    //}

    //public class ProductFileProfile : Profile
    //{
    //    public ProductFileProfile()
    //    {
    //        CreateMap<ProductFileOM, ProductFileOM>()
    //            .ForMember(dest => dest.ProductFileId, opt => opt.MapFrom(src => src.Id));
    //            //.ForMember(dest => dest.ProductFileId, opt => opt.MapFrom(src => src.Id));

    //    }

    //}

}
