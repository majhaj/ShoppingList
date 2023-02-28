using Application.Models;
using Application.OpenFoodProducts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenFoodProductController : ControllerBase
    {
        private readonly IOpenFoodProductService _apiClient;

        public OpenFoodProductController()
        {
            _apiClient = RestClient.For<IOpenFoodProductService>("https://majhaj:123maja@world.openfoodfacts.net");
        }

        [HttpGet("/{barcode}")]
        public ActionResult<OpenFoodFactsProduct> Get([FromRoute]string barcode)
        {
            var product = _apiClient.GetProductAsync(barcode).Result;
            return Ok(product);
        }

        [HttpGet("/search")]
        public ActionResult<List<OpenFoodFactsProduct>> Search(
            [FromQuery]string countriesTagsEn,
            [FromQuery] string nutritionGradesTags,
            [FromQuery] string storesTags,
            [FromQuery] string brandsTags)
        {
            var result = _apiClient.SearchProductsAsync(
                tagtype0: "countries_tag_en",
                tagContains0: "contains",
                tag0: countriesTagsEn,
                tagtype1: "nutrition_grades_tags",
                tagContains1: "contains",
                tag1: nutritionGradesTags,
                tagtype2: "stores_tags",
                tagContains2: "contains",
                tag2: storesTags,
                tagtype3: "brands_tags",
                tagContains3: "contains",
                tag3: brandsTags
               ).Result;

            return Ok(result);
        }

        [HttpPost("/{barcode}")]
        public ActionResult SaveProduct([FromRoute] string barcode)
        {
            _apiClient.SaveProductAsync(barcode);
            return Ok();
        }

    }
}
