using Core.MVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    [System.Serializable]
    public class ViewResourceDescriptor<TView>
    {
        [SerializeField] private TView _type;
        [SerializeField] private string _path;

        public TView Type => _type;
        public string Path => _path;
    }

    [System.Serializable]
    public class WindowResourceDescriptor: ViewResourceDescriptor<WindowType> {}

    [System.Serializable]
    public class ScreenResourceDescriptor: ViewResourceDescriptor<ScreenType> { }

    [System.Serializable]
    public class PopupResourceDescriptor: ViewResourceDescriptor<PopupType> { }

    [System.Serializable]
    public class PanelResourceDescriptor : ViewResourceDescriptor<PanelType> { }
}
