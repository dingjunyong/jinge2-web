using AutoMapper;
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

namespace Nop.Plugin.Other.Client.Infrastructure.Mapper
{
    public class AdminMapperConfiguration : IMapperConfiguration
    {
        public Action<IMapperConfigurationExpression> GetConfiguration()
        {
            Action<IMapperConfigurationExpression> action = cfg =>
            {
                //mobile setting
                cfg.CreateMap<MobileActivitySettings, MobileSettingsModel.MobileActivitySettingsModel>()
                        .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
                cfg.CreateMap<MobileSettingsModel.MobileActivitySettingsModel, MobileActivitySettings>();
                cfg.CreateMap<MobileCatalogNavigationSettings, MobileSettingsModel.MobileCatalogNavigationSettingsModel>()
                    .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
                cfg.CreateMap<MobileSettingsModel.MobileCatalogNavigationSettingsModel, MobileCatalogNavigationSettings>();
                cfg.CreateMap<MobileNivosliderSettings, MobileSettingsModel.MobileNivosliderSettingsModel>()
                    .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
                cfg.CreateMap<MobileSettingsModel.MobileNivosliderSettingsModel, MobileNivosliderSettings>();
                cfg.CreateMap<MobileKeywordSettings, MobileSettingsModel.MobileKeywordSettingsModel>()
                    .ForMember(dest => dest.CustomProperties, mo => mo.Ignore());
                cfg.CreateMap<MobileSettingsModel.MobileKeywordSettingsModel, MobileKeywordSettings>();


                cfg.CreateMap<SearchTerm, SearchTermDto>();
                cfg.CreateMap<SearchTermDto, SearchTerm>();
            };

            return action;
        }



        public int Order
        {
            get { return 0; }
        }
    }
}
