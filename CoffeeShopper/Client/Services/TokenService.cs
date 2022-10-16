using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Client.Services;

internal class TokenService : ITokenService
{
    private readonly IOptions<IdentityServerSettings> _identityServerSettings;
    private readonly HttpClient _httpClient;
    private readonly DiscoveryDocumentResponse _discoveryDocument;

    public TokenService(IOptions<IdentityServerSettings> identityServerSettings)
    {
        _identityServerSettings = identityServerSettings;
        _httpClient = new HttpClient();
        _discoveryDocument = _httpClient.GetDiscoveryDocumentAsync(_identityServerSettings.Value.DiscoveryUrl).Result;

        if (_discoveryDocument.IsError)
        {
            throw new Exception("Unable to get discovery document", _discoveryDocument.Exception);
        }
    }

    public async Task<TokenResponse> GetToken(string scope)
    {
        var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = _discoveryDocument.TokenEndpoint,
            ClientId = _identityServerSettings.Value.ClientName,
            ClientSecret = _identityServerSettings.Value.ClientPassword,
            Scope = scope
        });

        if (tokenResponse.IsError)
        {
            throw new Exception("Unable to get token", tokenResponse.Exception);
        }

        return tokenResponse;
    }
}