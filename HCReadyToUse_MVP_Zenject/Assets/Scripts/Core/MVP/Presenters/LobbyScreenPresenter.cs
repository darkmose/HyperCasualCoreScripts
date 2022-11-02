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

    class LobbyScreenPresenter : ILobbyScreenPresenter
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

        private void OnStartButtonClickHandler()
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
                InitializeButtonCallbacks();
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

        private void InitializeButtonCallbacks()
        {
            ProxyView.View.InitStartButtonCallback(OnStartButtonClickHandler);
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
