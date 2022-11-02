namespace Core.MVP
{
    public enum ScreenType
    {
        Loading,
        Lobby,
        Game
    }

    public abstract class BaseScreenView : BaseView
    {
        public override ViewType View => ViewType.Screen;
        public abstract ScreenType Type { get; }
    }

}