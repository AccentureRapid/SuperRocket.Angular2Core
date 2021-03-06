﻿using Abp.AutoMapper;
using SuperRocket.Angular2Core.Authentication.External;

namespace SuperRocket.Angular2Core.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
