using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlaytSDK.Scripts.UI
{
    public class PlaytLoginUi : MonoBehaviour
    {
        [SerializeField] private TMP_InputField emailInput;
        [SerializeField] private TMP_InputField passwordInput;
        [SerializeField] private Button loginButton;

        private Playt _playt;

        private void OnValidate()
        {
            if (emailInput == null || passwordInput == null)
            {
                var inputFields = GetComponentsInChildren<TMP_InputField>();
                if (emailInput == null)
                {
                    emailInput = inputFields.FirstOrDefault(input => input.gameObject.name == "Email Login Field");
                    if (emailInput == null)
                    {
                        Debug.LogError("Could not find email field 'Email Login Field'", this);
                    }
                }

                if (passwordInput == null)
                {
                    passwordInput =
                        inputFields.FirstOrDefault(input => input.gameObject.name == "Password Login Field");
                    if (passwordInput == null)
                    {
                        Debug.LogError("Could not find password field 'Password Login Field'", this);
                    }
                }
            }

            if (loginButton != null) return;
            {
                var buttons = GetComponentsInChildren<Button>();

                loginButton =
                    buttons.FirstOrDefault(input => input.gameObject.name == "Login");
                if (loginButton == null)
                {
                    Debug.LogError("Could not find button 'Login'", this);
                }
            }
        }

        private void Awake()
        {
            loginButton.onClick.AddListener(OnLoginClick);
        }

        private void Start()
        {
            _playt = Playt.Instance;
        }

        private void OnDestroy()
        {
            loginButton.onClick.RemoveListener(OnLoginClick);
        }

        private void OnLoginClick()
        {
            var email = emailInput.text;
            var password = passwordInput.text;

            // TODO validate later
            _playt.LoginWithEmail(email, password);
        }
    }
}