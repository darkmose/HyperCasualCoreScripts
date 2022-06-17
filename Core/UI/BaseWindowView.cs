using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public enum WindowType
    {
        Settings,
        LevelCompleted,
        LevelFail,
        Shop
    }

    public abstract class BaseWindowView : BaseView
    {
        public abstract WindowType Type { get;}
    }
}