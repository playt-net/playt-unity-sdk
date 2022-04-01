using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using PlaytSDK.Client;
using PlaytSDK.Scripts.Api.Unity;
using UnityEngine;
using UnityEngine.Networking;

namespace PlaytSDK.Scripts.Api.Match
{
    public class MatchApi
    {
        private const string ServiceUrl = "/match";

        private ApiConfig _config;
        private readonly string _url;

        public MatchApi(ApiConfig config)
        {
            _config = config;
            _url = config.BaseUrl + ServiceUrl;
        }

        [ItemCanBeNull]
        public async Task<MatchResponse> JoinMatch(string playerToken)
        {
            var matchJoinRequest = JsonConvert.SerializeObject(new MatchJoinRequest {PlayerToken = playerToken});
            var request = UnityWebRequest.Post(_url, matchJoinRequest);

            request.SetDefaultHeaders(_config);

            var response = await request.SendWebRequest();

            if (response == UnityWebRequest.Result.Success)
            {
                var body = Encoding.UTF8.GetString(request.downloadHandler.data);
                return JsonConvert.DeserializeObject<MatchResponse>(body);
            }
            else
            {
                Debug.LogError(request.error);
                return null;
            }
        }
    }
}