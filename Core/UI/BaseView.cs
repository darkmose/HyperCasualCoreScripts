using UnityEngine;
namespace Core.UI
{
    public enum ViewType
    {
        Window,
        Screen,
        Popup
    }

    public abstract class BaseView : MonoBehaviour
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

        protected virtual void OnAwake() { }
        protected virtual void OnStart() { }

        protected virtual void OnShow() { }

        protected virtual void OnHide() { }

        protected virtual void OnDestroyInner() { }

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