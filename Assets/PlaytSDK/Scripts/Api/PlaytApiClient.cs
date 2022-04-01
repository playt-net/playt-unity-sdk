using System.Threading.Tasks;
using JetBrains.Annotations;
using PlaytSDK.Client;
using PlaytSDK.Client.Models;
using PlaytSDK.Scripts.Api.Auth;
using PlaytSDK.Scripts.Api.Match;
using PlaytSDK.Scripts.Models;

namespace PlaytSDK.Scripts.Api
{
    public class PlaytApiClient
    {
        private ApiConfig _config;
        private MatchApi _matchApi;
        private AuthApi _authApi;

        public void Init(ApiConfig config)
        {
            _config = config;
            //TODO delegate to others
            _matchApi = new MatchApi(config);
            _authApi = new AuthApi(config);
        }

        public async Task<AuthToken> Login(string email, string password)
        {
            var result = await _authApi.Login(email, password);
            return result == null ? null : new AuthToken(result.AccessToken, result.RefreshToken);
        }

        [ItemCanBeNull]
        public async Task<PlaytSDK.Client.Models.Match> JoinMatch(string playerToken)
        {
            var result = await _matchApi.JoinMatch(playerToken);
            return result == null ? null : new PlaytSDK.Client.Models.Match(result.Id, result.PlayerTokens);
        }
    }
}