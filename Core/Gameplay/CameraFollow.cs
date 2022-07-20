using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Configuration;

namespace Core.Gameplay
{
    public class CameraFollow : MonoBehaviour
    {
        private const float RotateDuration = 1f;
        private const float MoveDuration = 1f;
        private const float CameraFollowSpeed = 7f;
        private Transform _target;
        private Vector3 _posOffset;
        private float _xPosOffset;
        private bool _canMove;
        private float _moveBounds;
        private float _startXPosition;

        public void InitStartPosition()
        {
            var config = Core.DISimple.ServiceLocator.Resolve<GameConfiguration>();
            _moveBounds = config.CameraMovementBounds;
            _startXPosition = transform.position.x;
        }

        public void ChangeOffset(Transform offsetPoint) 
        {
            _posOffset = offsetPoint.localPosition;
            transform.rotation = offsetPoint.localRotation;
            transform.position = offsetPoint.position;
        }

        /// <summary>
        /// Convert -1 to 1 to local position offset
        /// </summary>
        /// <param name="normalizedX">Normalized param from -1 to 1</param>
        public void ChangePosOffsetX(float normalizedX) 
        {
            var endPoint = _startXPosition + _moveBounds * normalizedX;
            _xPosOffset = Mathf.MoveTowards(_xPosOffset, endPoint, Time.deltaTime * CameraFollowSpeed);
        }

        public void ChangeOffsetSmoothly(Transform offsetPoint) 
        {
            SetPosSmoothly(offsetPoint.localPosition);
            SetRotateSmoothly(offsetPoint.localRotation);
        }

        private void SetPosSmoothly(Vector3 newPos)
        {
            DOTween.To(() => _posOffset, newOffset => _posOffset = newOffset, newPos, MoveDuration);
        }

        private void SetRotateSmoothly(Quaternion newRotate) 
        {
            transform.DORotateQuaternion(newRotate, RotateDuration);
        }

        public void SetTarget(Transform target) 
        {
            _target = target;
            if (System.Object.ReferenceEquals(target,null))
            {
                _canMove = false;
            }
            else
            {
                _canMove = true;
            }
        }

        void LateUpdate()
        {
            if (_canMove)
            {
                var target = _target.position;
                target.x = _xPosOffset;
                target.y = 0f;
                transform.position = target + _posOffset;
            }
        }
    }
}
