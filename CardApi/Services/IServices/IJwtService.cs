using System;
using CardApi.Model;

namespace CardApi.Services.IServices
{
    public interface IJwtService
    {
        string GenerateToken(JwtTokenData tokenData);
        JwtTokenData DecryptToken(string token);
    }
}