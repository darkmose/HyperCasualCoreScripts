using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.MVP
{
    public interface IGameScreenPresenter : IPresenter<GameScreenModel, GameScreenProxyView, GameScreenView>
    {
    }

    public class GameScreenPresenter : IGameScreenPresenter
    {
        public GameScreenModel Model { get; }
        public GameScreenProxyView ProxyView { get; }
        public GameScreenUseCases UseCases { get; }

        public GameScreenPresenter(GameScreenModel model, GameScreenProxyView proxyView)
        {
            Model = model;
            ProxyView = proxyView;
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
            OnMoneyChanged(Model.CurrentMoney.Value);
        }

        private void SubscribeDataChange()
        {
            Model.CurrentMoney.RegisterValueChangeListener(OnMoneyChanged);
            Model.CurrentLevel.RegisterValueChangeListener(OnCurrentLevelChanged);
        }

        private void OnCurrentLevelChanged(int level)
        {
            ProxyView.View.SetCurrentLevel(level);
        }

        private void OnMoneyChanged(int money)
        {
            ProxyView.View.SetCurrentMoneyBalance(money);
        }
    }
    
}