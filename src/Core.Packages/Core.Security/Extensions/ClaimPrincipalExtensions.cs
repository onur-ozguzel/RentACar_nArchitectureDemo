﻿using System.Security.Claims;

namespace Core.Security.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal?.Claims(ClaimTypes.Role);

        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal) =>
           Guid.Parse(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
    }
}
