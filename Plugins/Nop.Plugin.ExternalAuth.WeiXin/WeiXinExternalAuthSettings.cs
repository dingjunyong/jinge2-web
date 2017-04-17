using Nop.Core.Configuration;

namespace Nop.Plugin.ExternalAuth.WeiXin
{
    public class WeiXinExternalAuthSettings : ISettings
    {
        /// <summary>
        /// 应用唯一标识
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 与微信服务器交互次数
        /// </summary>
        public int RequestCount { get; set; }
    }
}
