using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DefectiveGoods.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using DefectiveGoods.Mvc.Dto.Products;
using DefectiveGoods.Core.Infrastructure.Repositories;
using DefectiveGoods.Core.Products;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DefectiveGoods.Mvc.Dto;
using System.Linq.Dynamic.Core;
using DefectiveGoods.Core.ProductCaterories;
using DefectiveGoods.EntityFrameworkCore.Repositories.ProductCategories;

namespace DefectiveGoods.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {        
        private readonly IRepository<Product, long> _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public HomeController(
            IRepository<Product, long> productRepository, 
            IMapper mapper,
            IProductCategoryRepository productCategoryRepository)
        {            
            _productRepository = productRepository;
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public PagedResultDto<ProductDto> GetProducts([FromBody] PagedProductReguestDto input)
        {
            IQueryable<Product> query = _productRepository
                .GetAll()
                .AsNoTracking();

            int totalCount = query.Count();

            if (!string.IsNullOrEmpty(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            var products = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToList()
                .AsReadOnly();
            
            var result = _mapper.Map<IReadOnlyList<ProductDto>>(products);

            foreach (var product in result)
            {
                product.CategoryNames = _productCategoryRepository.GetCategoryNames(product.Id);
            }
            
            return new PagedResultDto<ProductDto>(totalCount, result);
        }        
    }
}

