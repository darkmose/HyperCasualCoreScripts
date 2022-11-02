using Configuration;
using Core.DISimple;
using Core.Events;
using Core.Level;
using Core.PlayerModule;
using Core.Resourses;
using Core.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.States
{
    public class LoadingState : BaseState<ApplicationStates>
    {
        public override ApplicationStates State => ApplicationStates.Loading;

        private const string TOAST_IMAGE_MONEY_NAME = "ToastImageMoney";
        private const string TOAST_MESSAGE_NAME = "ToastMessage";
        private IPlayer _playerModule;
        private ResourceHolder _resourceHolder;
        private ObjectPooler<ToastMessage> _toastMessagePooler;

        public LoadingState(ResourceHolder resourceHolder, IPlayer player, ObjectPooler<ToastMessage> toastMessagePooler)
        {
            _resourceHolder = resourceHolder;
            _playerModule = player;

            _playerModule.OnLoadCompleteEvent += PlayerDataLoadCompleteEvent;
            _toastMessagePooler = toastMessagePooler;
        }

        private void PlayerDataLoadCompleteEvent()
        {
            stateMachine.SwitchToState(ApplicationStates.Gameplay);
        }

        public override void Enter()
        {
            PrepareToastMessagesPools();
            LoadPlayerModuleData();
        }

        private void PrepareToastMessagesPools()
        {
            var toastImageMoneyPrefab = _resourceHolder.ToastImageMoneyPrefab;
            _toastMessagePooler.CreatePool(TOAST_IMAGE_MONEY_NAME, toastImageMoneyPrefab, 10);
            var toastMessagePrefab = _resourceHolder.ToastMessagePrefab;
            _toastMessagePooler.CreatePool(TOAST_MESSAGE_NAME, toastMessagePrefab, 10);
        }

        public override void Exit()
        {
        }

        private void LoadPlayerModuleData()
        {
            _playerModule.Load();
        }
    }
}