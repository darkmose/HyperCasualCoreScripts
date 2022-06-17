using Core.UI;

namespace Core.States
{
    public class LoseState : BaseState<GameplayStates>
    {
        public override GameplayStates State => GameplayStates.Lose;
        private LoseWindow _loseWindow;

        public LoseState(LoseWindow loseWindow)
        {
            _loseWindow = loseWindow;
        }

        public override void Enter()
        {
            _loseWindow.Show();
            _loseWindow.InitRetryButtonCallback(OnRetryButtonHandler);
        }

        private void OnRetryButtonHandler()
        {
            stateMachine.SwitchToState(GameplayStates.Prepare);
        }

        public override void Exit()
        {
            _loseWindow.Hide();
        }
    }

}