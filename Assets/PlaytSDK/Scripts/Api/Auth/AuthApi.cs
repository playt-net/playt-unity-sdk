using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using PlaytSDK.Scripts.Api.Unity;
using UnityEngine;
using UnityEngine.Networking;

namespace PlaytSDK.Scripts.Api.Auth
{
    public class AuthApi
    {
        private const string ServiceUrl = "/auth";

        private ApiConfig _config;
        private readonly string _url;

        public AuthApi(ApiConfig config)
        {
            _config = config;
            _url = config.BaseUrl + ServiceUrl;
        }
        
        [ItemCanBeNull]
        public async Task<AuthTokenResponse> Login(string email, string password)
        {
            var loginRequest = JsonConvert.SerializeObject(new LoginRequest {Email = email, Password = password});
            using var request = new UnityWebRequest(_url + "/login", "POST");
            
            request.uploadHandler = new UploadHandlerRaw(new UTF8Encoding().GetBytes(loginRequest));
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetDefaultHeaders(_config);

            var response = await request.SendWebRequest();

            if (response == UnityWebRequest.Result.Success)
            {
                var body = Encoding.UTF8.GetString(request.downloadHandler.data);
                Debug.Log(body);
                return JsonConvert.DeserializeObject<AuthTokenResponse>(body);
            }
            else
            {
                var body = Encoding.UTF8.GetString(request.downloadHandler.data);
                Debug.LogError(body);
                Debug.LogError(request.error);
                return null;
            }
        }
    }
}