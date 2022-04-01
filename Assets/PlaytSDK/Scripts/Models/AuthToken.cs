namespace PlaytSDK.Scripts.Models
{
    public class AuthToken
    {
        public AuthToken(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string AccessToken { get; }
        public string RefreshToken { get; }
    }
}