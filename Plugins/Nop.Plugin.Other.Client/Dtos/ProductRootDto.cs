using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Dtos
{
    public class ProductRootDto
    {
    }

    [JsonObject(Title = "ProductSimple")]
    public class ProductSimpleDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ShortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("Sku")]
        public string Sku { get; set; }

        [JsonProperty("MarkAsNew")]
        public bool MarkAsNew { get; set; }

        [JsonProperty("ProductPrice")]
        public ProductPriceDto ProductPrice { get; set; }

        [JsonProperty("Picture")]
        public PictureDto Picture { get; set; }

        [JsonProperty("ReviewOverview")]
        public ProductReviewOverviewDto ReviewOverview { get; set; }
    }

    [JsonObject(Title = "ProductPrice")]
    public class ProductPriceDto
    {
        [JsonProperty("OldPrice")]
        public string OldPrice { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("PriceValue")]
        public decimal PriceValue { get; set; }


        [JsonProperty("BasePricePAngV")]
        public string BasePricePAngV { get; set; }

        [JsonProperty("DisableBuyButton")]
        public bool DisableBuyButton { get; set; }

        [JsonProperty("DisableWishlistButton")]
        public bool DisableWishlistButton { get; set; }

        [JsonProperty("DisableAddToCompareListButton")]
        public bool DisableAddToCompareListButton { get; set; }

        [JsonProperty("AvailableForPreOrder")]
        public bool AvailableForPreOrder { get; set; }

        [JsonProperty("PreOrderAvailabilityStartDateTimeUtc")]
        public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }

        [JsonProperty("IsRental")]
        public bool IsRental { get; set; }

        [JsonProperty("ForceRedirectionAfterAddingToCart")]
        public bool ForceRedirectionAfterAddingToCart { get; set; }

        [JsonProperty("DisplayTaxShippingInfo")]
        public bool DisplayTaxShippingInfo { get; set; }

    }

    [JsonObject(Title = "ProductReviewOverview")]
    public class ProductReviewOverviewDto
    {
        [JsonProperty("ProductId")]
        public int ProductId { get; set; }

        [JsonProperty("RatingSum")]
        public int RatingSum { get; set; }

        [JsonProperty("TotalReviews")]
        public int TotalReviews { get; set; }

        [JsonProperty("AllowCustomerReviews")]
        public bool AllowCustomerReviews { get; set; }
    }
}
