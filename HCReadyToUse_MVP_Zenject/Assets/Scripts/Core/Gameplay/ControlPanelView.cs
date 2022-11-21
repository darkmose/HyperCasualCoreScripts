using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.ControlLogic
{
    public interface IControlPanel
    {
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;
        public event System.Action<Vector2> OnControlDeltaChangedEvent;

        void Reset();
    }

    public class ControlPanelView : MonoBehaviour, IControlPanel, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 _oldTouchPos = Vector2.zero;
        private Vector2 _currentTouchPos;
        private bool _isTouched;

        public event Action<Vector2> OnControlDeltaChangedEvent;
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointerDownEvent?.Invoke();
            _currentTouchPos = eventData.position;
            _oldTouchPos = eventData.position;
            _isTouched = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnPointerUpEvent?.Invoke();
            _currentTouchPos = eventData.position;
            _oldTouchPos = eventData.position;
            _isTouched = false;
        }

        private void MakeControlDelta()
        {
            _currentTouchPos = Input.mousePosition;
            var controlDelta = _currentTouchPos - _oldTouchPos;
            _oldTouchPos = _currentTouchPos;
            OnControlDeltaChangedEvent?.Invoke(controlDelta);            
        }

        private void FixedUpdate()
        {
            if (_isTouched)
            {
                MakeControlDelta();
            }
        }

        public void Reset()
        {
            OnPointerUpEvent?.Invoke();
            _isTouched = false;
        }
    }
}