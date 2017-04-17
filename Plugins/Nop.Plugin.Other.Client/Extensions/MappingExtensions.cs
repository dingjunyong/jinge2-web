using Nop.Core.Domain.Common;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Other.Client.Domain.Mobiles;
using Nop.Plugin.Other.Client.Dtos;
using Nop.Plugin.Other.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region mobile api/settings
        public static MobileSettingsModel.MobileActivitySettingsModel ToModel(this MobileActivitySettings entity)
        {
            return entity.MapTo<MobileActivitySettings, MobileSettingsModel.MobileActivitySettingsModel>();
        }
        public static MobileActivitySettings ToEntity(this MobileSettingsModel.MobileActivitySettingsModel model, MobileActivitySettings destination)
        {
            return model.MapTo(destination);
        }
        public static MobileSettingsModel.MobileCatalogNavigationSettingsModel ToModel(this MobileCatalogNavigationSettings entity)
        {
            return entity.MapTo<MobileCatalogNavigationSettings, MobileSettingsModel.MobileCatalogNavigationSettingsModel>();
        }
        public static MobileCatalogNavigationSettings ToEntity(this MobileSettingsModel.MobileCatalogNavigationSettingsModel model, MobileCatalogNavigationSettings destination)
        {
            return model.MapTo(destination);
        }
        public static MobileSettingsModel.MobileNivosliderSettingsModel ToModel(this MobileNivosliderSettings entity)
        {
            return entity.MapTo<MobileNivosliderSettings, MobileSettingsModel.MobileNivosliderSettingsModel>();
        }
        public static MobileNivosliderSettings ToEntity(this MobileSettingsModel.MobileNivosliderSettingsModel model, MobileNivosliderSettings destination)
        {
            return model.MapTo(destination);
        }
        public static MobileSettingsModel.MobileKeywordSettingsModel ToModel(this MobileKeywordSettings entity)
        {
            return entity.MapTo<MobileKeywordSettings, MobileSettingsModel.MobileKeywordSettingsModel>();
        }
        public static MobileKeywordSettings ToEntity(this MobileSettingsModel.MobileKeywordSettingsModel model, MobileKeywordSettings destination)
        {
            return model.MapTo(destination);
        }
        #endregion

        #region common dto

        public static SearchTermDto ToDto(this SearchTerm entity)
        {
            return entity.MapTo<SearchTerm, SearchTermDto>();
        }

        #endregion

    }
}
