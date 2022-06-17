using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Core.Gameplay
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _shakingTime = .3f;
        [SerializeField] private float _shakingHeight;

        private Transform _target;
        private Vector3 _offset;
        private bool _canMove;
        private Tweener _shakingTweener;
        private float _shakeX;
        private float _shakeY;
        private Vector3 _shakeOffset = Vector3.zero;

        public void ChangeOffset(Vector3 offset) 
        {
            _offset = offset;
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

        public void ShakingCameraOn() 
        {
            _shakeX = -_shakingHeight;
            _shakingTweener = DOTween.To(() => _shakeX, x => _shakeX = x, _shakingHeight, _shakingTime)
                .OnUpdate(() => 
                { 
                    _shakeY = _shakeX * _shakeX;
                    _shakeOffset.x = _shakeX;
                    _shakeOffset.y = _shakeY;
                })
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void ShakingCameraOff() 
        {
            _shakingTweener.Kill();
            _shakeOffset = Vector3.zero;
        }

        void LateUpdate()
        {
            if (_canMove)
            {
                transform.position = _target.position + _offset + _shakeOffset;
            }
        }
    }
}
