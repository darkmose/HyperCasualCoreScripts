using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVP
{
    public interface ILobbyScreenPresenter : IPresenter<LobbyScreenModel, LobbyScreenProxyView, LobbyScreenView>
    {
    }

    public class LobbyScreenPresenter : ILobbyScreenPresenter
    {
        public LobbyScreenModel Model { get; }
        public LobbyScreenProxyView ProxyView { get; }
        public LobbyScreenUseCases UseCases { get; }

        public LobbyScreenPresenter(LobbyScreenModel model, LobbyScreenUseCases useCases, LobbyScreenProxyView proxyView)
        {
            Model = model;
            UseCases = useCases;
            ProxyView = proxyView;
        }

        public void OnStartButtonClickHandler()
        {
            UseCases.OnStartButtonClick();   
        }

        public void Destroy()
        {
            if (!ProxyView.IsPrepared)
            {
                ProxyView.View.Destroy();
            }
        }

        public void Hide()
        {
            if (!ProxyView.IsPrepared)
            {
                return;
            }
            ProxyView.View.Hide();
        }

        public void Init()
        {
            if (!ProxyView.IsPrepared)
            {
                ProxyView.Prepare();
                ProxyView.View.InitPresenter(this);
                SubscribeDataChange();
            }
        }

        public void Show()
        {
            if (!ProxyView.IsPrepared)
            {
                return;
            }
            ProxyView.View.Show();
            RefreshData();
        }

        private void RefreshData()
        {
            OnCurrentLevelChanged(Model.CurrentLevel.Value);
        }

        private void SubscribeDataChange()
        {
            Model.CurrentLevel.RegisterValueChangeListener(OnCurrentLevelChanged);
        }

        private void OnCurrentLevelChanged(int level)
        {
            ProxyView.View.SetCurrentLevel(level);
        }
    }
}
