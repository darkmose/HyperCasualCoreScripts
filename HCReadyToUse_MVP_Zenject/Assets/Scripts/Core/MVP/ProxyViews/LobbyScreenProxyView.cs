using Core.UI;

namespace Core.MVP
{
    public class LobbyScreenProxyView : BaseProxyView<LobbyScreenView>
    {
        public LobbyScreenProxyView(IUIManager uIManager) : base(uIManager)
        {
        }

        public override void Prepare()
        {
            View = _uIManager.GetScreen<LobbyScreenView>(ScreenType.Lobby);
        }
    }
}