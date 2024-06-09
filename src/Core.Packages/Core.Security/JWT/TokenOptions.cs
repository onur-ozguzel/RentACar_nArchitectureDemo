﻿namespace Core.Security.JWT
{
    public class TokenOptions
    {
        public TokenOptions()
        {
            Audience = string.Empty;
            Issuer = string.Empty;
            SecurityKey = string.Empty;
        }

        public TokenOptions(string audience, string issuer, int accessTokenExpiration, string securityKey, int refreshTokenTTL)
        {
            Audience = audience;
            Issuer = issuer;
            AccessTokenExpiration = accessTokenExpiration;
            SecurityKey = securityKey;
            RefreshTokenTTL = refreshTokenTTL;
        }

        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
        public int RefreshTokenTTL { get; set; }
    }
}
