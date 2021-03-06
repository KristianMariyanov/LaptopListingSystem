﻿namespace LaptopListingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Services.Common.Contracts;
    using LaptopListingSystem.Web.ViewModels.Laptops;

    [Route("api/[controller]")]
    public class LaptopsController : Controller
    {
        private const int DefaultNumberOfLaptops = 6;
        private const int DefaultLaptopCacheSeconds = 3600;
        private const int FirstPage = 1;
        private const int DefaultElementsOnPage = 6;

        private readonly IRepository<Laptop> laptops;
        private readonly IMappingService mappingService;
        private readonly IMemoryCache memoryCache;

        public LaptopsController(
            IRepository<Laptop> laptops,
            IMappingService mappingService,
            IMemoryCache memoryCache)
        {
            this.laptops = laptops;
            this.mappingService = mappingService;
            this.memoryCache = memoryCache;
        }
        
        public IActionResult Get()
        {
            const string CacheKey = "TopLatops";
            IList<LaptopShortViewModel> topLaptops;

            if (!this.memoryCache.TryGetValue(CacheKey, out topLaptops))
            {
                topLaptops = this.mappingService
                    .MapCollection<LaptopShortViewModel>(
                        this.laptops
                            .All()
                            .OrderByDescending(l => l.Votes.Count(v => !v.IsDeleted))
                            .Take(DefaultNumberOfLaptops))
                    .ToList();

                var opts = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(DefaultLaptopCacheSeconds)
                };

                this.memoryCache.Set(CacheKey, topLaptops, opts);
            }

            return this.Json(topLaptops);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue || id.Value == default(int))
            {
                return this.BadRequest("Invalid ID");
            }

            var laptop = this.mappingService
                .MapCollection<LaptopDetailsViewModel>(this.laptops.All().Where(l => l.Id == id))
                .FirstOrDefault();

            if (laptop == null)
            {
                return this.NotFound("Laptop doesn't exist");
            }

            return this.Json(laptop);
        }

        [HttpGet("[Action]")]
        [Authorize]
        public IActionResult Filter(string term, string order)
        {
            var laptopsQuery = this.laptops.All();

            if (!string.IsNullOrEmpty(term))
            {
                laptopsQuery = laptopsQuery.Where(l => l.Model.Contains(term) || l.Manufacturer.Name.Contains(term));
            }

            // TODO: Use enum
            if (order == "ram")
            {
                laptopsQuery = laptopsQuery.OrderByDescending(l => l.Ram);
            }
            else if (order == "votes")
            {
                laptopsQuery = laptopsQuery.OrderByDescending(l => l.Votes.Count);
            }
            else if (order == "comments")
            {
                laptopsQuery = laptopsQuery.OrderByDescending(l => l.Comments.Count);
            }

            var result = this.mappingService
                .MapCollection<LaptopShortViewModel>(laptopsQuery)
                .ToList();

            return this.Json(result);
        }

        [HttpGet("[Action]")]
        [Authorize]
        public IActionResult All(int? page)
        {
            if (!page.HasValue)
            {
                page = FirstPage;
            }
            var allLaptops = this.mappingService
                .MapCollection<LaptopShortViewModel>(
                    this.laptops
                        .All()
                        .Skip(page.Value - 1 * DefaultElementsOnPage)
                        .Take(DefaultElementsOnPage))
                .ToList();

            return this.Json(allLaptops);
        }
    }
}
