using Newtonsoft.Json;

namespace PlaytSDK.Scripts.Api.Match
{
    public class MatchJoinRequest
    {
        [JsonProperty("playerToken")] public string PlayerToken;
    }
}