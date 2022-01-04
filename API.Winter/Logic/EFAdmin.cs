using API.Winter.DTO.Output_Models;
using API.Winter.Logic.Interfaces;
using API.Winter.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Winter.Logic
{
    public class EFAdmin : IAdmin
    {
        private readonly WinterContext _context;
        readonly IMapper _mapper;

        public EFAdmin(IMapper mapper)
        {
            _context = new WinterContext();
            _mapper = mapper;
        }

        public OverViewOM OverView()
        {
            var overview = new OverViewOM();
            var categoryList = _context.Category.ToList();
            var productList = _context.Product.Include(r => r.Files).ToList();
            var userList = _context.UserProfile.ToList();

            overview.CategoryCount = _context.Category.Count();
            overview.ProductCount = _context.Product.Count();
            overview.UserCount = _context.UserProfile.Count();

            if (categoryList != null && categoryList.Count() > 0)
                overview.Categories = _mapper.Map<List<CategoryOM>>(categoryList); 
            
            if (productList != null && productList.Count() > 0)
                overview.Products = _mapper.Map<List<ProductOM>>(productList);
            
            if (userList != null && userList.Count() > 0)
                overview.Users = _mapper.Map<List<UserOM>>(userList);

            return overview;
        }

    }
}
