namespace Core.MVP
{
    public enum WindowType
    {
        Reward
    }

    public abstract class BaseWindowView : BaseView
    {
        public override ViewType View => ViewType.Window;
        public abstract WindowType WindowType { get; }
    }
}