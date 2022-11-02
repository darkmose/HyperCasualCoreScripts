using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.MVP;

namespace Core.UI
{
    public class UIManager : MonoBehaviour
    {
        private Dictionary<System.Type, BaseView> _allViews = new Dictionary<System.Type, BaseView>();

        [SerializeField] private Transform _windowsParent;
        [SerializeField] private List<WindowDescriptor> _windowDescriptors;

        public void RegisterView<TView>(TView view) where TView: BaseView
        {
            if (_allViews.ContainsKey(typeof(TView)) == true)
            {
                Debug.LogError($"View {typeof(TView).Name} already exist");
            }
            else
            {
                _allViews[typeof(TView)] = view;
            }
        }

        public void UnregisterView<TView>() where TView:BaseView
        {
            if (_allViews.ContainsKey(typeof(TView)) == false)
            {
                Debug.LogError($"View {typeof(TView).Name} did not exist");
            }
            else
            {
                _allViews.Remove(typeof(TView));
            }
        }

        public TView GetView<TView>() where TView : BaseView
        {
            if (_allViews.ContainsKey(typeof(TView)) == false)
            {
                Debug.LogError($"View {typeof(TView).Name} did not exist");
                return null;
            }
            else
            {
               return (TView) _allViews[typeof(TView)];
            }
        }

        public BaseWindowView GetWindowInstance(WindowType windowType)
        {
            var descriptor = _windowDescriptors.Find(descr => descr.WindowType == windowType);
            if (ReferenceEquals(descriptor, null))
            {
                throw new System.Exception($"There is no window with type [{windowType}]");
            }

            var window = Instantiate(descriptor.Prefab, _windowsParent);
            window.transform.SetAsFirstSibling();
            return window;
        }
    }

    [System.Serializable]
    public class WindowDescriptor
    {
        public WindowType WindowType;
        public BaseWindowView Prefab;
    }
}