﻿using Application.Models;
using Domain.Entities;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OpenFoodProducts
{
    public interface IOpenFoodProductService
    {
        [Get("api/v2/product/{barcode}")]
        Task<OpenFoodFactsProduct> GetProductAsync([Path] string barcode);

        [Get("cgi/search.pl")]
        Task<List<OpenFoodFactsProduct>> SearchProductsAsync
        (
            [Query] string tagtype0,
            [Query] string tagContains0,
            [Query] string tag0,
            [Query] string tagtype1,
            [Query] string tagContains1,
            [Query] string tag1,
            [Query] string tagtype2,
            [Query] string tagContains2,
            [Query] string tag2,
            [Query] string tagtype3,
            [Query] string tagContains3,
            [Query] string tag3,
            [Query] string action = "procces"

        );

        [Post("api/v2/product/{barcode}")]
        Task SaveProductAsync([Path] string barcode);

    }

}