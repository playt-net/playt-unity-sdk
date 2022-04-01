using System;
using UnityEngine;

namespace Example.Scripts
{
    public class DeathZone : MonoBehaviour
    {
        private BreakoutGameManger _gameManger;

        private void Start()
        {
            _gameManger = BreakoutGameManger.Instance;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var ball = col.GetComponent<Ball>();
            if (ball != null)
            {
                Destroy(ball.gameObject);
                _gameManger.OnDeath();
            }
        }
    }
}