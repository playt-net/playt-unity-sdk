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

        /*
         *
         {"status":"BAD_REQUEST","statusCode":400,"error":"JSON parse error: Unexpected character ('%' (code 37)): expected a valid value (JSON String, Number, Array, Object or token 'null', 'true' or 'false'); nested exception is com.fasterxml.jackson.core.JsonParseException: Unexpected character ('%' (code 37)): expected a valid value (JSON String, Number, Array, Object or token 'null', 'true' or 'false')\n at [Source: (org.springframework.util.StreamUtils$NonClosingInputStream); line: 1, column: 2]"}
         * 
         */

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