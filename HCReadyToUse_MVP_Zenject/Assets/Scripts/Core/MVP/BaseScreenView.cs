namespace Core.MVP
{
    public enum ScreenType
    {
        Loading,
        Lobby,
        Game,
        Collection,
        CarSelect,
        Tutorial
    }

    public abstract class BaseScreenView : BaseView
    {
        public override ViewType View => ViewType.Screen;
        public abstract ScreenType Type { get; }
    }

}