using Core.States;

namespace Core.MVP
{
    public class LobbyScreenUseCases 
    {
        private IStateMachine<GameplayStates> _gameplayStateMachine;

        public LobbyScreenUseCases(IStateMachine<GameplayStates> gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
        }

        public void OnStartButtonClick()
        {
            _gameplayStateMachine.SwitchToState(GameplayStates.Game);
        }
    }
}