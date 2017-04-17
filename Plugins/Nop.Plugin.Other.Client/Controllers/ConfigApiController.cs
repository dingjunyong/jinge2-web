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

namespace Nop.Plugin.Other.Client.Controllers
{
    public class ConfigApiController: BaseApiController
    {

        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly ISearchTermService _searchTermService;

        public ConfigApiController(IJsonFieldsSerializer jsonFieldsSerializer,
            IAclService aclService,
            ICustomerService customerService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            IPictureService pictureService,
            ISearchTermService searchTermService,
            ISettingService settingService,
            IStoreContext storeContext
            )
            :base(jsonFieldsSerializer, aclService, customerService, storeMappingService, storeService, discountService, customerActivityService, localizationService)

        {
            _storeContext = storeContext;
            _pictureService = pictureService;
            _searchTermService = searchTermService;
            _settingService = settingService;
        }

        /// <summary>
        /// 获取手机端首页信息
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        public IHttpActionResult GetMobileHome()
        {
            MobileHomeRootDto dto = new MobileHomeRootDto();

            #region MobileActivitySettings

            var _mobileActivitySettings = _settingService.LoadSetting<MobileActivitySettings>(_storeContext.CurrentStore.Id);

            if (_mobileActivitySettings.Picture1Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture1Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link1;
                dto.Activitys.Add(m);
            }
            if (_mobileActivitySettings.Picture2Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture2Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link2;
                dto.Activitys.Add(m);
            }
            if (_mobileActivitySettings.Picture3Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture3Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link3;
                dto.Activitys.Add(m);
            }
            if (_mobileActivitySettings.Picture4Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture4Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link4;
                dto.Activitys.Add(m);
            }
            if (_mobileActivitySettings.Picture5Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture5Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link5;
                dto.Activitys.Add(m);
            }
            if (_mobileActivitySettings.Picture6Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture6Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link6;
                dto.Activitys.Add(m);
            }
            if (_mobileActivitySettings.Picture7Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture7Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link7;
                dto.Activitys.Add(m);
            }
            if (_mobileActivitySettings.Picture8Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture8Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link8;
                dto.Activitys.Add(m);
            }
            if (_mobileActivitySettings.Picture9Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture9Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link9;
                dto.Activitys.Add(m);
            }
            if (_mobileActivitySettings.Picture10Id != 0)
            {
                MobileHomeRootDto.ActivityDto m = new MobileHomeRootDto.ActivityDto();
                var picture = _pictureService.GetPictureById(_mobileActivitySettings.Picture10Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Link = _mobileActivitySettings.Link10;
                dto.Activitys.Add(m);
            }

            #endregion

            #region MobileCatalogNavigationSettings


            var _mobileCatalogNavigationSettings = _settingService.LoadSetting<MobileCatalogNavigationSettings>(_storeContext.CurrentStore.Id);

            if (_mobileCatalogNavigationSettings.Picture1Id != 0)
            {
                MobileHomeRootDto.CatalogNavigationDto m = new MobileHomeRootDto.CatalogNavigationDto();
                var picture = _pictureService.GetPictureById(_mobileCatalogNavigationSettings.Picture1Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileCatalogNavigationSettings.Text1;
                m.Link = _mobileCatalogNavigationSettings.Link1;
                dto.CatalogNavigations.Add(m);
            }
            if (_mobileCatalogNavigationSettings.Picture2Id != 0)
            {
                MobileHomeRootDto.CatalogNavigationDto m = new MobileHomeRootDto.CatalogNavigationDto();
                var picture = _pictureService.GetPictureById(_mobileCatalogNavigationSettings.Picture2Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileCatalogNavigationSettings.Text2;
                m.Link = _mobileCatalogNavigationSettings.Link2;
                dto.CatalogNavigations.Add(m);
            }
            if (_mobileCatalogNavigationSettings.Picture3Id != 0)
            {
                MobileHomeRootDto.CatalogNavigationDto m = new MobileHomeRootDto.CatalogNavigationDto();
                var picture = _pictureService.GetPictureById(_mobileCatalogNavigationSettings.Picture3Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileCatalogNavigationSettings.Text3;
                m.Link = _mobileCatalogNavigationSettings.Link3;
                dto.CatalogNavigations.Add(m);
            }
            if (_mobileCatalogNavigationSettings.Picture4Id != 0)
            {
                MobileHomeRootDto.CatalogNavigationDto m = new MobileHomeRootDto.CatalogNavigationDto();
                var picture = _pictureService.GetPictureById(_mobileCatalogNavigationSettings.Picture4Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileCatalogNavigationSettings.Text4;
                m.Link = _mobileCatalogNavigationSettings.Link4;
                dto.CatalogNavigations.Add(m);
            }
            if (_mobileCatalogNavigationSettings.Picture5Id != 0)
            {
                MobileHomeRootDto.CatalogNavigationDto m = new MobileHomeRootDto.CatalogNavigationDto();
                var picture = _pictureService.GetPictureById(_mobileCatalogNavigationSettings.Picture5Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileCatalogNavigationSettings.Text5;
                m.Link = _mobileCatalogNavigationSettings.Link5;
                dto.CatalogNavigations.Add(m);
            }
            if (_mobileCatalogNavigationSettings.Picture6Id != 0)
            {
                MobileHomeRootDto.CatalogNavigationDto m = new MobileHomeRootDto.CatalogNavigationDto();
                var picture = _pictureService.GetPictureById(_mobileCatalogNavigationSettings.Picture6Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileCatalogNavigationSettings.Text6;
                m.Link = _mobileCatalogNavigationSettings.Link6;
                dto.CatalogNavigations.Add(m);
            }
            if (_mobileCatalogNavigationSettings.Picture7Id != 0)
            {
                MobileHomeRootDto.CatalogNavigationDto m = new MobileHomeRootDto.CatalogNavigationDto();
                var picture = _pictureService.GetPictureById(_mobileCatalogNavigationSettings.Picture7Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileCatalogNavigationSettings.Text7;
                m.Link = _mobileCatalogNavigationSettings.Link7;
                dto.CatalogNavigations.Add(m);
            }
            if (_mobileCatalogNavigationSettings.Picture8Id != 0)
            {
                MobileHomeRootDto.CatalogNavigationDto m = new MobileHomeRootDto.CatalogNavigationDto();
                var picture = _pictureService.GetPictureById(_mobileCatalogNavigationSettings.Picture8Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileCatalogNavigationSettings.Text8;
                m.Link = _mobileCatalogNavigationSettings.Link8;
                dto.CatalogNavigations.Add(m);
            }

            #endregion

            #region MobileNivosliderSettings

            var _mobileNivosliderSettings = _settingService.LoadSetting<MobileNivosliderSettings>(_storeContext.CurrentStore.Id);

            if (_mobileNivosliderSettings.Picture1Id != 0)
            {
                MobileHomeRootDto.NivosliderDto m = new MobileHomeRootDto.NivosliderDto();
                var picture = _pictureService.GetPictureById(_mobileNivosliderSettings.Picture1Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileNivosliderSettings.Text1;
                m.Link = _mobileNivosliderSettings.Link1;
                dto.Nivosliders.Add(m);
            }
            if (_mobileNivosliderSettings.Picture2Id != 0)
            {
                MobileHomeRootDto.NivosliderDto m = new MobileHomeRootDto.NivosliderDto();
                var picture = _pictureService.GetPictureById(_mobileNivosliderSettings.Picture2Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileNivosliderSettings.Text2;
                m.Link = _mobileNivosliderSettings.Link2;
                dto.Nivosliders.Add(m);
            }
            if (_mobileNivosliderSettings.Picture3Id != 0)
            {
                MobileHomeRootDto.NivosliderDto m = new MobileHomeRootDto.NivosliderDto();
                var picture = _pictureService.GetPictureById(_mobileNivosliderSettings.Picture3Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileNivosliderSettings.Text3;
                m.Link = _mobileNivosliderSettings.Link3;
                dto.Nivosliders.Add(m);
            }
            if (_mobileNivosliderSettings.Picture4Id != 0)
            {
                MobileHomeRootDto.NivosliderDto m = new MobileHomeRootDto.NivosliderDto();
                var picture = _pictureService.GetPictureById(_mobileNivosliderSettings.Picture4Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileNivosliderSettings.Text4;
                m.Link = _mobileNivosliderSettings.Link4;
                dto.Nivosliders.Add(m);
            }
            if (_mobileNivosliderSettings.Picture5Id != 0)
            {
                MobileHomeRootDto.NivosliderDto m = new MobileHomeRootDto.NivosliderDto();
                var picture = _pictureService.GetPictureById(_mobileNivosliderSettings.Picture5Id);
                m.Picture = PrepareImageDto(picture, m);
                m.Text = _mobileNivosliderSettings.Text5;
                m.Link = _mobileNivosliderSettings.Link5;
                dto.Nivosliders.Add(m);
            }

            #endregion

            #region MobileKeywordSettings

            var _mobileKeywordSettings = _settingService.LoadSetting<MobileKeywordSettings>(_storeContext.CurrentStore.Id);
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text1))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text1;
                m.Link = _mobileKeywordSettings.Link1;
                dto.Keywords.Add(m);
            }
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text2))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text2;
                m.Link = _mobileKeywordSettings.Link2;
                dto.Keywords.Add(m);
            }
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text3))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text3;
                m.Link = _mobileKeywordSettings.Link3;
                dto.Keywords.Add(m);
            }
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text4))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text4;
                m.Link = _mobileKeywordSettings.Link4;
                dto.Keywords.Add(m);
            }
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text5))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text5;
                m.Link = _mobileKeywordSettings.Link5;
                dto.Keywords.Add(m);
            }
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text6))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text6;
                m.Link = _mobileKeywordSettings.Link6;
                dto.Keywords.Add(m);
            }
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text7))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text7;
                m.Link = _mobileKeywordSettings.Link7;
                dto.Keywords.Add(m);
            }
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text8))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text8;
                m.Link = _mobileKeywordSettings.Link8;
                dto.Keywords.Add(m);
            }
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text9))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text9;
                m.Link = _mobileKeywordSettings.Link9;
                dto.Keywords.Add(m);
            }
            if (!string.IsNullOrEmpty(_mobileKeywordSettings.Text10))
            {
                MobileHomeRootDto.KeywordDto m = new MobileHomeRootDto.KeywordDto();
                m.Text = _mobileKeywordSettings.Text10;
                m.Link = _mobileKeywordSettings.Link10;
                dto.Keywords.Add(m);
            }
            #endregion

            return Success(dto);
        }

        /// <summary>
        /// 获取搜索最多的热词
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        public IHttpActionResult GetHotSearchTerms()
        {
            SearchTermRootDto dto = new SearchTermRootDto();

            dto.SearchTerms = _searchTermService.GetSearchTerms(
                 isOrderByCountDesc: true,
                 pageSize: 15).Select(x => x.ToDto()).ToList();

            return Success(dto);
        }
    }
}
