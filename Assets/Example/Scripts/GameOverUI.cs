using System;
using UnityEngine;
using UnityEngine.UI;

namespace Example.Scripts
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private Button gameOverButton;

        private BreakoutGameManger _gameManger;

        private void Awake()
        {
            if (gameOverButton == null)
            {
                gameOverButton = GetComponentInChildren<Button>();
            }

            gameOverButton.onClick.AddListener(OnGameOverButtonClick);
        }

        private void Start()
        {
            _gameManger = BreakoutGameManger.Instance;
        }

        private void OnDestroy()
        {
            gameOverButton.onClick.RemoveListener(OnGameOverButtonClick);
        }

        private void OnGameOverButtonClick()
        {
            _gameManger.Restart();
        }
    }
}