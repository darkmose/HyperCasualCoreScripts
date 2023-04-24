using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.MVP;

namespace Core.UI
{
    public interface IUIElementPathGetter
    {
        string GetScreen(ScreenType screenType);
        string GetWindow(WindowType windowType);
        string GetPopup(PopupType popupType);
        string GetPanel(PanelType panelType);
    }

    [CreateAssetMenu(fileName = "UIElementDescriptor", menuName ="Create/UI element descriptor")]
    public class UIElementsResourceDescriptor : ScriptableObject, IUIElementPathGetter
    {
        private const string Path = "ScriptableObjects/UIElementDescriptor";
        private static UIElementsResourceDescriptor _instanceInner;
        public static UIElementsResourceDescriptor Instance
        {
            get
            {
                return _instanceInner ?? (_instanceInner = Resources.Load<UIElementsResourceDescriptor>(Path));
            }
        }

        [SerializeField] private List<WindowResourceDescriptor> _windowResourceDescriptors = new List<WindowResourceDescriptor>();
        [SerializeField] private List<ScreenResourceDescriptor> _screenResourceDescriptors = new List<ScreenResourceDescriptor>();
        [SerializeField] private List<PopupResourceDescriptor> _popupResourceDescriptors = new List<PopupResourceDescriptor>();
        [SerializeField] private List<PanelResourceDescriptor> _panelResourceDescriptors = new List<PanelResourceDescriptor>();

        public string GetWindow(WindowType windowType)
        {
            var result = _windowResourceDescriptors.Find(descriptor => descriptor.Type == windowType);
            if (result == null)
            {
                Debug.LogError($"[{GetType().Name}][GetWindow] Cannot find window type: {windowType}");
                return null;
            }

            return result.Path;
        }

        public string GetScreen(ScreenType screenType)
        {
            var result = _screenResourceDescriptors.Find(descriptor => descriptor.Type == screenType);
            if (result == null)
            {
                Debug.LogError($"[{GetType().Name}][GetScreen] Cannot find screen type: {screenType}");
                return null;
            }

            return result.Path;
        }

        public string GetPopup(PopupType popupType)
        {
            var result = _popupResourceDescriptors.Find(descriptor => descriptor.Type == popupType);
            if (result == null)
            {
                Debug.LogError($"[{GetType().Name}][GetPopup] Cannot find popup type: {popupType}");
                return null;
            }

            return result.Path;
        }

        public string GetPanel(PanelType panelType)
        {
            var result = _panelResourceDescriptors.Find(descriptor => descriptor.Type == panelType);
            if (result == null)
            {
                Debug.LogError($"[{GetType().Name}][GetPanel] Cannot find panel type: {panelType}");
                return null;
            }

            return result.Path;
        }
    }
}
