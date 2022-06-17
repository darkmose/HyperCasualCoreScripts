using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI
{
    public class JoystickDetector : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IMovable
    {
        private const float Sensitivity = 0.3f;
        private Vector2 _moveVector;
        private bool _isTouched;
        public bool IsMoved { get; private set; }
        public Vector3 MotionVector => _moveVector;

        public bool IsTouched => _isTouched;


        private void Awake()
        {
            Core.DISimple.ServiceLocator.Register<IMovable>(this);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            IsMoved = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _moveVector += eventData.delta.normalized * Sensitivity;
            Debug.Log($"Joystick: {_moveVector}");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            IsMoved = false;
        }

        private void OnDestroy()
        {
            Core.DISimple.ServiceLocator.Unregister<IMovable>();
        }


        private void FixedUpdate()
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                _isTouched = true;
            }
            else
            {
                _isTouched = false;
            }
            _moveVector = Vector2.zero;
        }
    }

    public interface IMovable
    {
        bool IsTouched { get; }
        bool IsMoved { get; }
        Vector3 MotionVector { get; }
    }

}
