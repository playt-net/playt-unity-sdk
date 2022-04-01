using Newtonsoft.Json;

namespace PlaytSDK.Scripts.Api.Auth
{
    public class LoginRequest
    {
        [JsonProperty("email")] public string Email;

        [JsonProperty("password")] public string Password;
    }
}