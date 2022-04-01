using UnityEngine;

namespace PlaytSDK.Scripts.Unity
{
    public class PlaytSettings : ScriptableObject
    {
        public string apiKey = "";
        public string baseUrl = "http://localhost:8080";
    }
}