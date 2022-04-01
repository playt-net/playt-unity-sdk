using PlaytSDK.Scripts.Api;
using PlaytSDK.Scripts.Unity;
using UnityEngine;

namespace PlaytSDK.Scripts
{
    public class Playt : MonoBehaviour
    {
        private static Playt _instance;
        public static Playt Instance => _instance;

        private PlaytApiClient _apiClient;

        [SerializeField] private PlaytSettings playtSettings;

        private void OnValidate()
        {
            EnsurePlaytSettingsSet();
        }

        private void Awake()
        {
            if (Instance == null)
            {
                _instance = this;
                _apiClient = new PlaytApiClient();
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

            EnsurePlaytSettingsSet();
            _apiClient.Init(new ApiConfig(playtSettings.apiKey, playtSettings.baseUrl));
        }

        private void EnsurePlaytSettingsSet()
        {
            if (playtSettings != null) return;

            // Pick default
            var settings = Resources.FindObjectsOfTypeAll<PlaytSettings>();
            if (settings.Length == 0)
            {
                Debug.LogError(
                    "No PlayerSettings available. Please create a PlayerSettings with the PLAYT Editor", this);
            }
            else if (settings.Length == 0)
            {
                playtSettings = settings[0];
            }
            else
            {
                playtSettings = settings[0];
                Debug.LogWarning("Multiple settings were found but none was assigned - selecting the first",
                    playtSettings);
            }
        }

        // TODO this and all other "service" methods might be removed into another layer later - still evaluating
        public async void LoginWithEmail(string email, string password)
        {
            PlayerPrefs.DeleteKey("accessToken");
            PlayerPrefs.DeleteKey("refreshToken");

            Debug.Log("LoginWithEmail start", this);
            var token = await _apiClient.Login(email, password);
            Debug.Log("LoginWithEmail done" + token, this);

            // TODO store securely
            PlayerPrefs.SetString("accessToken", token.AccessToken);
            PlayerPrefs.SetString("refreshToken", token.RefreshToken);
        }
    }
}