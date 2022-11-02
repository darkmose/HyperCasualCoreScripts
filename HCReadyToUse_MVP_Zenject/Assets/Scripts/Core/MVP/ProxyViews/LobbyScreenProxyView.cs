using Core.UI;

namespace Core.MVP
{
    public class LobbyScreenProxyView : BaseProxyView<LobbyScreenView>
    {
        public LobbyScreenProxyView(UIManager uIManager) : base(uIManager)
        {
        }

        public override void Prepare()
        {
            View = _uIManager.GetView<LobbyScreenView>();
        }
    }
}