using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4
{
    internal class App
    {
        private readonly IProductsService _productsService;
        private readonly IRequestService _requestService;

        public App(IProductsService productsService, IRequestService requestService)
        {
            _productsService = productsService;
            _requestService = requestService;
        }

        public async Task Start()
        {
            string ProductName = "product1";
            string ProductDescription = "good product";
            int UnitPrice = 100;
            string SupplierId = "$%%^1234";
            string CategoryId = "*^%123";
            int CurrentOrder = 5;

            string ProductName1 = "product2";
            string ProductDescription1 = "good product";
            int UnitPrice1 = 200;
            string SupplierId1 = "$%%^1234";
            string CategoryId1 = "*^%123";
            int CurrentOrder1 = 6;
   
            var productId1 = await _productsService.AddProductAsync(ProductName, ProductDescription, UnitPrice,
                CurrentOrder, SupplierId, CategoryId);
            var productId2 = await _productsService.AddProductAsync(ProductName1, ProductDescription1, UnitPrice1,
               CurrentOrder1, SupplierId1, CategoryId1);

            var neededProduct = await _requestService.GetProductWithNameAsync(ProductName);

            if(neededProduct != null)
            Console.WriteLine($"{neededProduct.UnitPrice}");
        }
    }
}
