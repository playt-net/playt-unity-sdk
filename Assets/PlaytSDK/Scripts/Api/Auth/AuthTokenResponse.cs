using Newtonsoft.Json;

namespace PlaytSDK.Scripts.Api.Auth
{
    public class AuthTokenResponse
    {
        [JsonProperty("accessToken")] public string AccessToken;
        [JsonProperty("refreshToken")] public string RefreshToken;
    }
}