using AutoMapper;
using System;
using Winter.API.DTO.Input_Models;
using Winter.API.DTO.Output_Models;
using Winter.API.Models;

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
        MappingClass mappingClass = new MappingClass();
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
        MappingClass mappingClass = new MappingClass();
        public CartProfile()
        {
            CreateMap<Cart, CartOM>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => mappingClass.Create(src.User.FirstName, src.User.LastName)));

            CreateMap<CartOM, Cart>()
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now));

        }

    }

    //public class CartProfile : Profile
    //{
    //    MappingClass mappingClass = new MappingClass();
    //    public CartProfile()
    //    {
    //        CreateMap<Cart, CartOM>()
    //            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
    //            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => mappingClass.Create(src.User.FirstName, src.User.LastName)));

    //        CreateMap<CartOM, Cart>()
    //            .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now));

    //    }

    //}
}
