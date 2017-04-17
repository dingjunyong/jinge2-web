using Nop.Core;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Stores;
using Nop.Plugin.Other.Client.Domain.Mobiles;
using Nop.Plugin.Other.Client.Dtos;
using Nop.Plugin.Other.Client.Infrastructure.Json.ActionResults;
using Nop.Plugin.Other.Client.Infrastructure.Json.Serializers;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Nop.Plugin.Other.Client.Extensions;
using Nop.Services.Catalog;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.Other.Client.Dtos.Parameters;

namespace Nop.Plugin.Other.Client.Controllers
{
    public class CatalogApiController : BaseApiController
    {

        private readonly IPictureService _pictureService;
        private readonly ICategoryService _categoryService;
        private readonly IStoreContext _storeContext;
        private readonly IProductService _productService;


        public CatalogApiController(IJsonFieldsSerializer jsonFieldsSerializer,
            IAclService aclService,
            ICustomerService customerService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            IPictureService pictureService,
            IProductService productService,
            ICategoryService categoryService,
            IStoreContext storeContext
            )
            :base(jsonFieldsSerializer, aclService, customerService, storeMappingService, storeService, discountService, customerActivityService, localizationService)

        {
            _storeContext = storeContext;
            _pictureService = pictureService;
            _productService = productService;
            _categoryService = categoryService;
        }

      


        /// <summary>
        /// 获取分类页面的分类
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            CatalogSimpleRootDto dto = new CatalogSimpleRootDto();
            dto.Categories=PrepareCategorySimpleDtos(0);
            return Success(dto);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        public virtual IHttpActionResult Search(SearchParamater paramater)
        {
            if (string.IsNullOrEmpty(paramater.Q))
                return Error(HttpStatusCode.BadRequest, "关键词非法");

            SearchResultRootDto dto = new SearchResultRootDto();


            var searchTerms = paramater.Q;
            if (searchTerms == null)
                searchTerms = "";
            searchTerms = searchTerms.Trim();

            dto.SearchResult.Q = searchTerms;

            //products
            var products = _productService.SearchProducts(
                storeId: _storeContext.CurrentStore.Id,
                visibleIndividuallyOnly: true,
                keywords: searchTerms,
                orderBy: ProductSortingEnum.Position,
                pageIndex: paramater.PageNumber - 1,
                pageSize: paramater.PageSize);

            dto.SearchResult.NoResults = !dto.SearchResult.Products.Any();

            return Success(dto);

        }


        private List<CategorySimpleDto> PrepareCategorySimpleDtos(int rootCategoryId,
            bool loadSubCategories = true, IList<Category> allCategories = null)
        {

            var result = new List<CategorySimpleDto>();

            allCategories = _categoryService.GetAllCategories(storeId: _storeContext.CurrentStore.Id);
            var categories = allCategories.Where(c => c.ParentCategoryId == rootCategoryId).ToList();
            foreach (var category in categories)
            {
                var categoryModel = new CategorySimpleDto
                {
                    Id = category.Id,
                    Name = category.GetLocalized(x => x.Name),
                };

                if (loadSubCategories)
                {
                    var subCategories = PrepareCategorySimpleDtos(category.Id, loadSubCategories, allCategories);
                    categoryModel.SubCategories.AddRange(subCategories);
                }
                result.Add(categoryModel);
            }
            return result;
        }
    }
}
