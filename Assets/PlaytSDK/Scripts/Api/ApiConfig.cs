namespace PlaytSDK.Scripts.Api
{
    public class ApiConfig
    {
        public string ApiKey { get; }
        public string BaseUrl { get; }

        public ApiConfig(string apiKey, string baseUrl)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }
    }
}