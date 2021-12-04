using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using API.Winter.Models;
using AutoMapper;
using System;

namespace Winter.API.Helpers
{
    public class MappingClass
    {
        public string Create(string FirstName, string LastName)
        {
            return FirstName + " " + LastName;
        }
    }

    public class WishProfile : Profile
    {
        readonly MappingClass mappingClass = new MappingClass();
        public WishProfile()
        {
            CreateMap<Wish, WishOM>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => mappingClass.Create(src.User.FirstName, src.User.LastName)));

            CreateMap<WishIM, Wish>()
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now));
            //CreateMap<FileModel, WithnessDocument>().AfterMap<WitnessFileUploadMappingAction>();

        }

    }

    public class CartProfile : Profile
    {
        readonly MappingClass mappingClass = new MappingClass();
        public CartProfile()
        {
            CreateMap<Cart, CartOM>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => mappingClass.Create(src.User.FirstName, src.User.LastName)));

            CreateMap<CartIM, Cart>()
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now));

        }
    }

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductOM>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.ProductFile, opt => opt.MapFrom(src => src.Files));

            CreateMap<ProductIM, Product>()
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now));

        }

    }

    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategory, SubCategoryOM>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName));

            CreateMap<SubCategoryIM, SubCategory>()
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now));

        }

    }

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryOM>();

            CreateMap<CategoryIM, Category>()
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now));

        }

    }

    public class ProductFileProfile : Profile
    {
        public ProductFileProfile()
        {
            CreateMap<Files, ProductFileOM>()
                .ForMember(dest => dest.ProductFileId, opt => opt.MapFrom(src => src.Id));
            //.ForMember(dest => dest.ProductFileId, opt => opt.MapFrom(src => src.Id));

        }

    }

}
