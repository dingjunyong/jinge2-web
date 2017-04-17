using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Models
{
    public partial class MobileSettingsModel : BaseNopModel
    {

        public MobileSettingsModel()
        {
            MobileActivitySettings = new MobileActivitySettingsModel();
            MobileCatalogNavigationSettings = new MobileCatalogNavigationSettingsModel();
            MobileNivosliderSettings = new MobileNivosliderSettingsModel();
            MobileKeywordSettings = new MobileKeywordSettingsModel();

        }

        public MobileActivitySettingsModel MobileActivitySettings { get; set; }

        public MobileCatalogNavigationSettingsModel MobileCatalogNavigationSettings { get; set; }

        public MobileNivosliderSettingsModel MobileNivosliderSettings { get; set; }

        public MobileKeywordSettingsModel MobileKeywordSettings { get; set; }

        public partial class MobileActivitySettingsModel : BaseNopModel
        {
            [NopResourceDisplayName("活动图片1")]
            [UIHint("Picture")]
            public int Picture1Id { get; set; }
            [NopResourceDisplayName("活动链接1")]

            public string Link1 { get; set; }

            [NopResourceDisplayName("活动图片2")]
            [UIHint("Picture")]
            public int Picture2Id { get; set; }
            [NopResourceDisplayName("活动链接2")]
            public string Link2 { get; set; }

            [NopResourceDisplayName("活动图片3")]
            [UIHint("Picture")]
            public int Picture3Id { get; set; }
            [NopResourceDisplayName("活动链接3")]
            public string Link3 { get; set; }

            [NopResourceDisplayName("活动图片4")]
            [UIHint("Picture")]
            public int Picture4Id { get; set; }
            [NopResourceDisplayName("活动链接4")]
            public string Link4 { get; set; }

            [NopResourceDisplayName("活动图片5")]
            [UIHint("Picture")]
            public int Picture5Id { get; set; }
            [NopResourceDisplayName("活动链接5")]
            public string Link5 { get; set; }

            [NopResourceDisplayName("活动图片6")]
            [UIHint("Picture")]
            public int Picture6Id { get; set; }
            [NopResourceDisplayName("活动链接6")]
            public string Link6 { get; set; }

            [NopResourceDisplayName("活动图片7")]
            [UIHint("Picture")]
            public int Picture7Id { get; set; }
            [NopResourceDisplayName("活动链接7")]
            public string Link7 { get; set; }

            [NopResourceDisplayName("活动图片8")]
            [UIHint("Picture")]
            public int Picture8Id { get; set; }
            [NopResourceDisplayName("活动链接8")]
            public string Link8 { get; set; }

            [NopResourceDisplayName("活动图片9")]
            [UIHint("Picture")]
            public int Picture9Id { get; set; }
            [NopResourceDisplayName("活动链接9")]
            public string Link9 { get; set; }

            [NopResourceDisplayName("活动图片10")]
            [UIHint("Picture")]
            public int Picture10Id { get; set; }
            [NopResourceDisplayName("活动链接10")]
            public string Link10 { get; set; }
        }
        public partial class MobileCatalogNavigationSettingsModel : BaseNopModel
        {
            [NopResourceDisplayName("首页导航图片1")]
            [UIHint("Picture")]
            public int Picture1Id { get; set; }
            [NopResourceDisplayName("首页导航文字1")]
            public string Text1 { get; set; }
            [NopResourceDisplayName("首页导航链接1")]
            public string Link1 { get; set; }

            [NopResourceDisplayName("首页导航图片2")]
            [UIHint("Picture")]
            public int Picture2Id { get; set; }
            [NopResourceDisplayName("首页导航文字2")]
            public string Text2 { get; set; }
            [NopResourceDisplayName("首页导航链接2")]
            public string Link2 { get; set; }

            [NopResourceDisplayName("首页导航图片3")]
            [UIHint("Picture")]
            public int Picture3Id { get; set; }
            [NopResourceDisplayName("首页导航文字3")]
            public string Text3 { get; set; }
            [NopResourceDisplayName("首页导航链接3")]
            public string Link3 { get; set; }

            [NopResourceDisplayName("首页导航图片4")]
            [UIHint("Picture")]
            public int Picture4Id { get; set; }
            [NopResourceDisplayName("首页导航文字4")]
            public string Text4 { get; set; }
            [NopResourceDisplayName("首页导航链接4")]
            public string Link4 { get; set; }

            [NopResourceDisplayName("首页导航图片5")]
            [UIHint("Picture")]
            public int Picture5Id { get; set; }
            [NopResourceDisplayName("首页导航文字5")]
            public string Text5 { get; set; }
            [NopResourceDisplayName("首页导航链接5")]
            public string Link5 { get; set; }

            [NopResourceDisplayName("首页导航图片6")]
            [UIHint("Picture")]
            public int Picture6Id { get; set; }
            [NopResourceDisplayName("首页导航文字6")]
            public string Text6 { get; set; }
            [NopResourceDisplayName("首页导航链接6")]
            public string Link6 { get; set; }

            [NopResourceDisplayName("首页导航图片7")]
            [UIHint("Picture")]
            public int Picture7Id { get; set; }
            [NopResourceDisplayName("首页导航文字7")]
            public string Text7 { get; set; }
            [NopResourceDisplayName("首页导航链接7")]
            public string Link7 { get; set; }

            [NopResourceDisplayName("首页导航图片8")]
            [UIHint("Picture")]
            public int Picture8Id { get; set; }
            [NopResourceDisplayName("首页导航文字8")]
            public string Text8 { get; set; }
            [NopResourceDisplayName("首页导航链接8")]
            public string Link8 { get; set; }
        }

        public partial class MobileNivosliderSettingsModel : BaseNopModel
        {

            [NopResourceDisplayName("首页轮播图片1")]
            [UIHint("Picture")]
            public int Picture1Id { get; set; }
            [NopResourceDisplayName("首页轮播文字1")]
            public string Text1 { get; set; }
            [NopResourceDisplayName("首页轮播链接1")]
            public string Link1 { get; set; }

            [NopResourceDisplayName("首页轮播图片2")]
            [UIHint("Picture")]
            public int Picture2Id { get; set; }
            [NopResourceDisplayName("首页轮播文字2")]
            public string Text2 { get; set; }
            [NopResourceDisplayName("首页轮播链接2")]
            public string Link2 { get; set; }

            [NopResourceDisplayName("首页轮播图片3")]
            [UIHint("Picture")]
            public int Picture3Id { get; set; }
            [NopResourceDisplayName("首页轮播文字3")]
            public string Text3 { get; set; }
            [NopResourceDisplayName("首页轮播链接3")]
            public string Link3 { get; set; }

            [NopResourceDisplayName("首页轮播图片4")]
            [UIHint("Picture")]
            public int Picture4Id { get; set; }
            [NopResourceDisplayName("首页轮播文字4")]
            public string Text4 { get; set; }
            [NopResourceDisplayName("首页轮播链接4")]
            public string Link4 { get; set; }

            [NopResourceDisplayName("首页轮播图片5")]
            [UIHint("Picture")]
            public int Picture5Id { get; set; }
            [NopResourceDisplayName("首页轮播文字5")]
            public string Text5 { get; set; }
            [NopResourceDisplayName("首页轮播链接5")]
            public string Link5 { get; set; }
        }

        public partial class MobileKeywordSettingsModel : BaseNopModel
        {

            [NopResourceDisplayName("首页热词文字1")]
            public string Text1 { get; set; }
            [NopResourceDisplayName("首页热词链接1")]
            public string Link1 { get; set; }

            [NopResourceDisplayName("首页热词文字2")]
            public string Text2 { get; set; }
            [NopResourceDisplayName("首页热词链接2")]
            public string Link2 { get; set; }

            [NopResourceDisplayName("首页热词文字3")]
            public string Text3 { get; set; }
            [NopResourceDisplayName("首页热词链接3")]
            public string Link3 { get; set; }

            [NopResourceDisplayName("首页热词文字4")]
            public string Text4 { get; set; }
            [NopResourceDisplayName("首页热词链接4")]
            public string Link4 { get; set; }

            [NopResourceDisplayName("首页热词文字5")]
            public string Text5 { get; set; }
            [NopResourceDisplayName("首页热词链接5")]
            public string Link5 { get; set; }


            [NopResourceDisplayName("首页热词文字6")]
            public string Text6 { get; set; }
            [NopResourceDisplayName("首页热词链接6")]
            public string Link6 { get; set; }

            [NopResourceDisplayName("首页热词文字7")]
            public string Text7 { get; set; }
            [NopResourceDisplayName("首页热词链接7")]
            public string Link7 { get; set; }



            [NopResourceDisplayName("首页热词文字8")]
            public string Text8 { get; set; }
            [NopResourceDisplayName("首页热词链接8")]
            public string Link8 { get; set; }

            [NopResourceDisplayName("首页热词文字9")]
            public string Text9 { get; set; }
            [NopResourceDisplayName("首页热词链接9")]
            public string Link9 { get; set; }

            [NopResourceDisplayName("首页热词文字10")]
            public string Text10 { get; set; }
            [NopResourceDisplayName("首页热词链接10")]
            public string Link10 { get; set; }
        }

    }
}
