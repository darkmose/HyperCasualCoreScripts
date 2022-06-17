namespace Core.UI
{
    public enum ScreenType
    {
        Loading,
        Lobby,
        Game
    }

    public abstract class BaseScreenView : BaseView
    {
        public abstract ScreenType Type { get; }
    }
}