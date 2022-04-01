using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Example.Scripts
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private Transform ballStart;
        [SerializeField] private Ball ballPrefab;

        private Ball _ball;
        private Rigidbody2D _rigidbody2D;
        private BreakoutGameManger _gameManger;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _gameManger = BreakoutGameManger.Instance;
            _gameManger.OnGameStartEvent += OnOnGameStartEvent;
        }

        private void OnDestroy()
        {
            _gameManger.OnGameStartEvent -= OnOnGameStartEvent;
        }

        private void OnOnGameStartEvent(object sender, EventArgs e)
        {
            var position = ballStart.position;
            _ball = FindObjectOfType<Ball>() ?? Instantiate(ballPrefab, position, Quaternion.identity);
            _ball.transform.position = position;
        }

        private void Update()
        {
            if (_gameManger.State != GameState.Start) return;
            
            _ball.transform.position = ballStart.position;
            if (Input.GetMouseButton(0))
            {
                _gameManger.StartRound();
                _ball.Fire();
            }
        }

        private void FixedUpdate()
        {
            var xInput = Input.GetAxisRaw("Horizontal");
            _rigidbody2D.position += new Vector2(xInput, 0).normalized * Time.fixedDeltaTime * movementSpeed;
        }
    }
}