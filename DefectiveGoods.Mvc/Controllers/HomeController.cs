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

namespace DefectiveGoods.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {        
        private readonly IRepository<Product, long> _productRepository;
        private readonly IMapper _mapper;

        public HomeController(IRepository<Product, long> productRepository, IMapper mapper)
        {            
            _productRepository = productRepository;
            _mapper = mapper;
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

        public IEnumerable<ProductDto> GetProducts()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}

