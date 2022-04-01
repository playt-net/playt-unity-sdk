using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Example.Scripts
{
    public class GameUI : MonoBehaviour
    {
        private BreakoutGameManger _gameManger;

        [SerializeField] private RectTransform gameOverCanvas;

        private void Awake()
        {
            gameOverCanvas.gameObject.SetActive(false);
        }

        void Start()
        {
            _gameManger = BreakoutGameManger.Instance;

            _gameManger.OnGameStartEvent += OnOnGameStartEvent;
            _gameManger.OnGameOverEvent += OnOnGameOverEvent;
        }

        private void OnDestroy()
        {
            _gameManger.OnGameStartEvent -= OnOnGameStartEvent;
            _gameManger.OnGameOverEvent -= OnOnGameOverEvent;
        }

        private void OnOnGameStartEvent(object sender, EventArgs e)
        {
            gameOverCanvas.gameObject.SetActive(false);
        }

        private void OnOnGameOverEvent(object sender, EventArgs e)
        {
            gameOverCanvas.gameObject.SetActive(true);
        }
    }
}