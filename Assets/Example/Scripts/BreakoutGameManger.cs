using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Example.Scripts
{
    public class BreakoutGameManger : MonoBehaviour
    {
        private static BreakoutGameManger _instance;
        public static BreakoutGameManger Instance => _instance;

        private GameState _state;
        public GameState State => _state;

        public event EventHandler OnGameStartEvent;
        public event EventHandler OnGamePlayingEvent;
        public event EventHandler OnGameOverEvent;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                _state = GameState.Start;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Restart();
        }

        public void OnDeath()
        {
            _state = GameState.End;
            OnGameOverEvent?.Invoke(this, null);
        }

        public void StartRound()
        {
            _state = GameState.Playing;
            OnGamePlayingEvent?.Invoke(this, null);
        }

        public void Restart()
        {
            _state = GameState.Start;
            OnGameStartEvent?.Invoke(this, null);
        }
    }
}