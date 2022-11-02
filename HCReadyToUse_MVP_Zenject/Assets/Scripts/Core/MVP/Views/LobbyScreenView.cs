using UnityEngine;
using UnityEngine.UI;

namespace Core.MVP
{
    public class LobbyScreenView : BaseScreenView
    {
        public override ScreenType Type => ScreenType.Game;
        [SerializeField] private Button _startButton;
        [SerializeField] private LevelProgressBarView _levelProgressBarView;

        private System.Action _startButtonCallback;

        public void InitStartButtonCallback(System.Action action)
        {
            _startButtonCallback = action;
        }

        public void SetCurrentLevel(int level)
        {
            _levelProgressBarView.InitProgressBar(level);
        }

        protected override void OnAwake()
        {
            _startButton.onClick.AddListener(() => _startButtonCallback?.Invoke());
            base.OnAwake();
        }

    }

}