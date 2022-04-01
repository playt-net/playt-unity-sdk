using System.Collections.Generic;

namespace PlaytSDK.Client.Models
{
    public class Match
    {
        public Match(string id, List<string> playerTokens)
        {
            Id = id;
            PlayerTokens = playerTokens;
        }

        public string Id { get; }
        public List<string> PlayerTokens { get; }
    }
}