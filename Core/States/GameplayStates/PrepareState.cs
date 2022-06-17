using Core.DISimple;
using Core.Level;
using Core.Resourses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.States
{
    public class PrepareState : BaseState<GameplayStates>
    {
        public override GameplayStates State => GameplayStates.Prepare;

        private LevelController _levelController;

        public PrepareState(LevelController levelController)
        {
            _levelController = levelController;
        }


        public override void Enter()
        {
            _levelController.PrepareNextLevel();
            stateMachine.SwitchToState(GameplayStates.Lobby);
        }

        public override void Exit()
        {
            
        }     
    }
}

