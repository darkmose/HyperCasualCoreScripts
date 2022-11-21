using Configuration;
using Core.ControlLogic;
using UnityEngine;
using Zenject;

namespace Core.GameLogic
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [Inject(Id = "GameControlPanel")] private IControlPanel _controlPanel;
        private float _moveSpeed;
        private float _controlSensitivity;
        private Vector3 _moveVector = Vector3.zero;
        private float _boundLeft;
        private float _boundRight;
        private float _startXPosition;
        private bool _canMove;

        public bool CanMove 
        {
            get => _canMove; 
            set
            {
                _canMove = value;
                if (!value)
                {
                    ResetControl();
                }
            }
        }

        private void Awake()
        {
        }

        [Inject]
        private void Constructor(GameConfiguration gameConfiguration)
        {
            _controlPanel.OnControlDeltaChangedEvent += OnControlDeltaChangedEvent;
            _moveSpeed = gameConfiguration.PlayerConfiguration.MoveSpeed * Time.fixedDeltaTime;
            var boundOffset = gameConfiguration.PlayerConfiguration.MoveBoundOffset;
            _startXPosition = transform.position.x;
            _boundLeft = _startXPosition - boundOffset;
            _boundRight = _startXPosition + boundOffset;
        }

        private void OnControlDeltaChangedEvent(Vector2 delta)
        {
            _moveVector.x = delta.x * _controlSensitivity * Time.fixedDeltaTime;
        }

        private void Move()
        {
            _moveVector.z = _moveSpeed;
            var newPosition = _rigidbody.position + _moveVector;
            newPosition = LimitMovement(newPosition);
            _rigidbody.MovePosition(newPosition);
        }

        private void ResetControl()
        {
            _moveVector.x = 0f;
        }

        private Vector3 LimitMovement(Vector3 currentPosition)
        {
            currentPosition.x = Mathf.Clamp(currentPosition.x, _boundLeft, _boundRight);
            return currentPosition;
        }

        private void FixedUpdate()
        {
            if (CanMove)
            {
                Move();
                ResetControl();
            }
        }

    }

}