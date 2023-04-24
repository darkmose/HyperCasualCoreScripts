using Core.DISimple;
using System.Collections.Generic;
using UnityEngine;
using Core.MVP;
using Zenject;
using UnityEngine.EventSystems;
using Core.UI;

namespace Core.MVP
{
    public interface IUIManager
    {
        T GetScreen<T>(ScreenType screenType);
        T GetWindow<T>(WindowType windowType, Transform parent = null);
        T GetPopup<T>(PopupType popupType);
        T GetPanels<T>(PanelType panelType);
        void PushView(IView view);
        IView PopView();
        void SetActiveEventSystem(bool isActive);
    }

    public class UIManagerAdvanced : MonoBehaviour, IUIManager
    {
        private Dictionary<ScreenType, GameObject> _screens;
        private Dictionary<WindowType, GameObject> _windows;
        private Dictionary<PopupType, GameObject> _popups;
        private Dictionary<PanelType, GameObject> _panels;

        [SerializeField] private Transform _screenParent;
        [SerializeField] private Transform _windowParent;
        [SerializeField] private Transform _popupParent;
        [SerializeField] private Transform _panelParent;
        [SerializeField] private UIElementsResourceDescriptor _uIElementPathGetter;
        [SerializeField] private EventSystem _eventSystem;

        private Stack<IView> _openedView = new Stack<IView>();

        public T GetPopup<T>(PopupType popupType)
        {
            var go = GetPopup(popupType);
            return go.GetComponent<T>();
        }

        public T GetScreen<T>(ScreenType screenType)
        {
            var go = GetScreen(screenType);
            return go.GetComponent<T>();
        }

        public T GetWindow<T>(WindowType windowType, Transform parent = null)
        {
            GameObject go = null;
            if (parent == null)
            {
               go = GetWindow(windowType);
            }
            else
            {
                go = GetWindow(windowType, parent);
            }
            return go.GetComponent<T>();
        }

        public T GetPanels<T>(PanelType panelType)
        {
            var go = GetPanel(panelType);
            return go.GetComponent<T>();
        }

        public void PushView(IView view)
        {
            //add to stack
            //Set as last sibling
            var viewLink = view as IViewLinkWithGameObject;
            if (viewLink != null)
            {
                viewLink.Link.transform.SetAsFirstSibling();
            }

            _openedView.Push(view);

        }

        public IView PopView()
        {
            if (_openedView.Count == 0)
            {
                return null;
            }

            //HideCurrentActive
            var view = _openedView.Pop();

            //Pop from stack previus view
            //Set previus view as last sibling
            var viewLink = view as IViewLinkWithGameObject;
            if (viewLink != null)
            {
                viewLink.Link.transform.SetAsLastSibling();
            }
            return view;
        }

        private void Awake()
        {
            _screens = new Dictionary<ScreenType, GameObject>();
            _windows = new Dictionary<WindowType, GameObject>();
            _popups = new Dictionary<PopupType, GameObject>();
            _panels = new Dictionary<PanelType, GameObject>();

            ServiceLocator.Register<IUIManager>(this);
            DontDestroyOnLoad(gameObject);
        }

        private GameObject GetPopup(PopupType popupType)
        {
            if (_popups.ContainsKey(popupType))
            {
                return _popups[popupType];
            }

            var instance = Resources.Load<GameObject>(_uIElementPathGetter.GetPopup(popupType));

            var go = Instantiate(instance, _popupParent);
            _popups[popupType] = go;

            return go;
        }

        private GameObject GetScreen(ScreenType screenType)
        {
            if (_screens.ContainsKey(screenType))
            {
                return _screens[screenType];
            }

            var prefab = Resources.Load<GameObject>(_uIElementPathGetter.GetScreen(screenType));
            var instance = Instantiate(prefab, _screenParent);
            _screens[screenType] = instance;

            return instance;
        }

        private GameObject GetWindow(WindowType windowType)
        {
            if (_windows.ContainsKey(windowType))
            {
                return _windows[windowType];
            }

            var instance = Resources.Load<GameObject>(_uIElementPathGetter.GetWindow(windowType));
            var go = Instantiate(instance, _windowParent);
            _windows[windowType] = go;

            return go;
        }
        private GameObject GetWindow(WindowType windowType, Transform parent)
        {
            if (_windows.ContainsKey(windowType))
            {
                return _windows[windowType];
            }

            var instance = Resources.Load<GameObject>(_uIElementPathGetter.GetWindow(windowType));
            var go = Instantiate(instance, parent);
            _windows[windowType] = go;

            return go;
        }

        private GameObject GetPanel(PanelType panelType)
        {
            if (_panels.ContainsKey(panelType))
            {
                return _panels[panelType];
            }

            var instance = Resources.Load<GameObject>(_uIElementPathGetter.GetPanel(panelType));
            var go = Instantiate(instance, _panelParent);
            _panels[panelType] = go;

            return go;
        }

        public void SetActiveEventSystem(bool isActive)
        {
            _eventSystem.enabled = isActive;
        }
    }
}
