﻿using Microsoft.AspNetCore.Http;

namespace CampaignManager.Infrastructure.Common.Utils
{
    public interface IUtilService
    {
        string GenerateMD5Hash(string sessionId);
        string GetRemoteIPAddress(HttpContext context, bool allowForwarded = true);
        string GenerateTwoFACode();
    }
}
