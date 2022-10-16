using IdentityModel.Client;

namespace Client.Services;

internal interface ITokenService
{
    Task<TokenResponse> GetToken(string scope);
}
