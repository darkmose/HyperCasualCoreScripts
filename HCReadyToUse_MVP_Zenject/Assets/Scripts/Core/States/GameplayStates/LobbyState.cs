using Core.PlayerModule;
using Core.MVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Events;
using Core.Level;
using Core.CameraLogic;
using Core.DISimple;

namespace Core.States
{
    public class LobbyState : BaseState<GameplayStates>
    {
        public override GameplayStates State => GameplayStates.Lobby;

        private const string LobbyCameraPointName = "Lobby";
        private LevelController _levelController;

        public LobbyState(LevelController levelController)
        {
            _levelController = levelController;
        }

        public override void Enter()
        {
            stateMachine.SwitchToState(GameplayStates.Game);
        }

        public override void Exit()
        {
        }
    }
}