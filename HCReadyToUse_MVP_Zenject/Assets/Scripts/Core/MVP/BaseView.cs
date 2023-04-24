using UnityEngine;
using Core.UI;

namespace Core.MVP
{
    public enum ViewType
    {
        Window,
        Screen,
        Popup,
        Panel
    }

    public abstract class BaseView : MonoBehaviour, IView, IViewLinkWithGameObject
    {
        [SerializeField] private bool _hideOnAwake;
        public bool IsOpen { get; protected set; }

        public abstract ViewType View { get; }

        public GameObject Link => gameObject;

        public void Show()
        {
            IsOpen = true;
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            IsOpen = false;
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

        public virtual void Init()
        {
        }

        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}