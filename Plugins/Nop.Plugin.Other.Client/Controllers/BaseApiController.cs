using Nop.Core;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Stores;
using Nop.Plugin.Other.Client.Dtos;
using Nop.Plugin.Other.Client.Infrastructure.Json.ActionResults;
using Nop.Plugin.Other.Client.Infrastructure.Json.Serializers;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Security;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Nop.Plugin.Other.Client.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly IJsonFieldsSerializer _jsonFieldsSerializer;
        protected readonly IAclService _aclService;
        protected readonly ICustomerService _customerService;
        protected readonly IStoreMappingService _storeMappingService;
        protected readonly IStoreService _storeService;
        protected readonly IDiscountService _discountService;
        protected readonly ICustomerActivityService _customerActivityService;
        protected readonly ILocalizationService _localizationService;

        public BaseApiController(IJsonFieldsSerializer jsonFieldsSerializer,
            IAclService aclService,
            ICustomerService customerService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService)
        {
            _jsonFieldsSerializer = jsonFieldsSerializer;
            _aclService = aclService;
            _customerService = customerService;
            _storeMappingService = storeMappingService;
            _storeService = storeService;
            _discountService = discountService;
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
        }
        protected IHttpActionResult Error(HttpStatusCode statusCode = (HttpStatusCode)422,  string errorMessage = "")
        {
           
            var errorsRootObject = new ReponseRootObject()
            {
                 Root=new RootDto
                 {
                      Code= statusCode,
                      Message= errorMessage
                 }
            };
            var errorsJson = _jsonFieldsSerializer.Serialize(errorsRootObject, null);
            return new ErrorActionResult(errorsJson, statusCode);
        }

        protected IHttpActionResult Success(object data)
        {

            var errorsRootObject = new ReponseRootObject()
            {
                Root = new RootDto
                {
                    Code = HttpStatusCode.OK,
                    Data= data
                }
            };
            var json = _jsonFieldsSerializer.Serialize(errorsRootObject, null);
            return new RawJsonActionResult(json);
        }

        protected void UpdateAclRoles<TEntity>(TEntity entity, List<int> passedRoleIds) where TEntity : BaseEntity, IAclSupported
        {
            if (passedRoleIds == null)
            {
                return;
            }

            entity.SubjectToAcl = passedRoleIds.Any();

            var existingAclRecords = _aclService.GetAclRecords(entity);
            var allCustomerRoles = _customerService.GetAllCustomerRoles(true);
            foreach (var customerRole in allCustomerRoles)
            {
                if (passedRoleIds.Contains(customerRole.Id))
                {
                    //new role
                    if (existingAclRecords.Count(acl => acl.CustomerRoleId == customerRole.Id) == 0)
                        _aclService.InsertAclRecord(entity, customerRole.Id);
                }
                else
                {
                    //remove role
                    var aclRecordToDelete = existingAclRecords.FirstOrDefault(acl => acl.CustomerRoleId == customerRole.Id);
                    if (aclRecordToDelete != null)
                        _aclService.DeleteAclRecord(aclRecordToDelete);
                }
            }
        }

        protected void UpdateStoreMappings<TEntity>(TEntity entity, List<int> passedStoreIds) where TEntity : BaseEntity, IStoreMappingSupported
        {
            if (passedStoreIds == null)
                return;

            entity.LimitedToStores = passedStoreIds.Any();

            var existingStoreMappings = _storeMappingService.GetStoreMappings(entity);
            var allStores = _storeService.GetAllStores();
            foreach (var store in allStores)
            {
                if (passedStoreIds.Contains(store.Id))
                {
                    //new store
                    if (existingStoreMappings.Count(sm => sm.StoreId == store.Id) == 0)
                        _storeMappingService.InsertStoreMapping(entity, store.Id);
                }
                else
                {
                    //remove store
                    var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                    if (storeMappingToDelete != null)
                        _storeMappingService.DeleteStoreMapping(storeMappingToDelete);
                }
            }
        }

        protected PictureDto PrepareImageDto<TDto>(Picture picture, TDto dto)
        {
            PictureDto pictureDto = null;

            if (picture != null)
            {
                // We don't use the image from the passed dto directly 
                // because the picture may be passed with src and the result should only include the base64 format.
                pictureDto = new PictureDto()
                {
                    Attachment = Convert.ToBase64String(picture.PictureBinary)
                };
            }

            return pictureDto;
        }
    }
}
