using System;
using UnityEngine;

namespace Example.Scripts
{
    public class Ball : MonoBehaviour
    {
        private bool _ballActive;
        private Rigidbody2D _rigidbody2D;
        [SerializeField] private float ballSpeed = 5f;

        private void Awake()
        {
            _ballActive = false;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_ballActive)
            {
                _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * ballSpeed;
            }
        }

        public void Fire()
        {
            if (!_ballActive)
            {
                _ballActive = true;
                _rigidbody2D.velocity = Vector2.up * ballSpeed;
            }
        }
    }
}