using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlaytSDK.Scripts.Api.Match
{
    /*
     * {
  "id": "string",
  "playerTokens": [
    "string"
  ],
  "matchState": "string",
  "matchingState": "string",
  "participants": [
    "string"
  ],
  "result": {
    "winners": [
      {
        "userId": "string",
        "score": 0,
        "displayName": "string",
        "avatarUrl": "string"
      }
    ],
    "losers": [
      {
        "userId": "string",
        "score": 0,
        "displayName": "string",
        "avatarUrl": "string"
      }
    ]
  },
  "matchTier": "string",
  "denominationTier": "string",
  "possibleWins": [
    {
      "fullQualifiedName": "string",
      "amount": 0
    }
  ],
  "entryCosts": [
    {
      "fullQualifiedName": "string",
      "amount": 0
    }
  ],
  "gameId": "string",
  "timeoutAt": "2022-04-01T09:14:11.197Z",
  "deletedAt": "2022-04-01T09:14:11.197Z",
  "finishedAt": "2022-04-01T09:14:11.197Z",
  "scoreSnapshots": [
    {
      "userId": "string",
      "score": 0,
      "timestamp": "2022-04-01T09:14:11.197Z",
      "finalSnapshot": true
    }
  ],
  "seed": "string",
  "availableReplays": [
    {
      "matchId": "string",
      "userId": "string"
    }
  ]
}
     */

    public class MatchResponse
    {
        [JsonProperty("id")] public string Id;

        [JsonProperty("playerTokens")] public List<string> PlayerTokens;
    }
}