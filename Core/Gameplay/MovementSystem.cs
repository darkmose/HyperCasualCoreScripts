using Core.DISimple;
using Core.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] private float _movementBounds = 10f;
    [SerializeField] private Rigidbody _rigidbody;

    private float _moveBoundLeft;
    private float _moveBountRight;

    private Core.UI.IMovable _movable;
    private Vector3 _motionVector;
    private Configuration.GameConfiguration _gameConfiguration;
    private bool _canMove;
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    private void Start()
    {
        _gameConfiguration = ServiceLocator.Resolve<Configuration.GameConfiguration>();
        _movable = Core.DISimple.ServiceLocator.Resolve<Core.UI.IMovable>();
        _moveBoundLeft = transform.position.x - _movementBounds;
        _moveBountRight = transform.position.x + _movementBounds;
    }

    private void Update()
    {
        _motionVector = _movable.MotionVector * _gameConfiguration.CameraSensitive;
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            var moveVector = transform.forward * Time.fixedDeltaTime * _gameConfiguration.PlayerSpeed;
            moveVector += _motionVector;
            moveVector += _rigidbody.position;
            moveVector.x = Mathf.Clamp(moveVector.x, _moveBoundLeft, _moveBountRight);
            _rigidbody.MovePosition(moveVector);
        }
    }
}
