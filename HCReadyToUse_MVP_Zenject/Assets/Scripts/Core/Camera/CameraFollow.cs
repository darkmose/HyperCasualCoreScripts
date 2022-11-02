using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Configuration;
using Zenject;

namespace Core.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        private const float ROTATE_DURATION = 1f;
        private const float MOVE_DURATION = 1f;
        private Transform _target;
        private Vector3 _posOffset;
        private Vector3 _controlOffset = Vector3.zero;
        private Vector3 _screenSizeOffset = Vector3.zero;


        public bool CanMove { get; set; }

        public void ChangeOffset(Transform offsetPoint) 
        {
            _posOffset = offsetPoint.localPosition;
            transform.rotation = offsetPoint.localRotation;
            transform.position = offsetPoint.position;
        }

        public void ChangeOffsetSmoothly(Transform offsetPoint, Action onComplete = null) 
        {
            var pos = SetPosSmoothly(offsetPoint.localPosition);
            var rotate = SetRotateSmoothly(offsetPoint.localRotation);
            DOTween.Sequence().Append(pos).Join(rotate).OnComplete(() => onComplete?.Invoke());
        }

        private Tweener SetPosSmoothly(Vector3 newPos)
        {
            return DOTween.To(() => _posOffset, newOffset => _posOffset = newOffset, newPos, MOVE_DURATION);
        }

        private Tweener SetRotateSmoothly(Quaternion newRotate) 
        {
            return transform.DORotateQuaternion(newRotate, ROTATE_DURATION);
        }

        public void SetTarget(Transform target) 
        {
            _target = target;
        }

        public void SetTargetPos(Transform targetObject)
        {
            var target = targetObject.position;
            transform.position = target + _posOffset;
        }

        public void SetTargetSmoothly(Transform targetObject, Action onComplete = null)
        {
            CanMove = false;
            _target = targetObject;
            var target = targetObject.position;
            transform.DOMove(target + _posOffset, MOVE_DURATION).OnComplete(() =>
            {
                CanMove = true;
                onComplete?.Invoke();                
            });
        }        
        
        public void SetTargetSmoothly(Transform targetObject, Transform offset, Action onComplete = null)
        {
            CanMove = false;
            _target = targetObject;
            var target = targetObject.position;
            _posOffset = offset.position;
            SetRotateSmoothly(offset.localRotation);

            transform.DOMove(target + _posOffset, MOVE_DURATION).OnComplete(() =>
            {
                CanMove = true;
                onComplete?.Invoke();                
            });
        }

        void LateUpdate()
        {
            if (CanMove)
            {
                var target = _target.position;
                transform.position = target + _posOffset + _controlOffset + _screenSizeOffset;
            }
        }
    }
}
