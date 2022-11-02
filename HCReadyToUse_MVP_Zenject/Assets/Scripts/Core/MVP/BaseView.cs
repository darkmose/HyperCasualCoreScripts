using UnityEngine;

namespace Core.MVP
{
    public enum ViewType
    {
        Window,
        Screen,
        Popup
    }

    public abstract class BaseView : MonoBehaviour, IView
    {
        [SerializeField] private bool _hideOnAwake;
        public bool IsActive { get; protected set; }
        public abstract ViewType View { get; }

        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }
        public virtual void Destroy() { }
        protected virtual void OnAwake() { }
        protected virtual void OnStart() { }

        protected virtual void OnShow() { }

        protected virtual void OnHide() { }

        protected virtual void OnDestroyInner() { }

        public virtual void Init() { }

        private void Awake()
        {
            if (_hideOnAwake)
            {
                Hide();
            }

            OnAwake();
        }
        private void Start()
        {
            OnStart();
        }

        private void OnDestroy()
        {
            OnDestroyInner();
        }

    }
}