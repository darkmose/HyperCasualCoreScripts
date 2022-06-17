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

namespace Core.States
{
    public class LoadingState : BaseState<ApplicationStates>
    {
        public override ApplicationStates State => ApplicationStates.Loading;

        private Player _player;

        private LevelController _levelController;
        private GameConfiguration _gameConfiguration;
        private ResourceHolder _resourceHolder;

        public LoadingState(ResourceHolder resourceHolder)
        {
            _resourceHolder = resourceHolder;

            _gameConfiguration = ServiceLocator.Resolve<GameConfiguration>();

        }

        public override void Enter()
        {
            PreparePlayer();
            PrepareLevelController();
            PrepareObjectPooler();
            stateMachine.SwitchToState(ApplicationStates.Gameplay);
        }

        public override void Exit()
        {
        }

        private void PrepareObjectPooler()
        {
            var rootOfPooler = new GameObject("PoolerRoot");
            var objectPooler = new ObjectPooler(rootOfPooler.transform, false);
            ServiceLocator.Register<ObjectPooler>(objectPooler);
        }

        private void PrepareLevelController()
        {
            _levelController = new LevelController(_player.LevelProgression, _resourceHolder);
            ServiceLocator.Register(_levelController);
        }

        private void PreparePlayer()
        {
            var wallet = new Wallet(MoneyType.Coins, _gameConfiguration.PlayerCoinsAmoint);
            var settings = new Settings();
            var levelProgression = new LevelProgression();
            var privacyPolicy = new PrivacyPolicy();
            _player = new Player(privacyPolicy, settings, wallet, levelProgression);
            ServiceLocator.Register(_player);
            _player.Load();
        }
    }
}