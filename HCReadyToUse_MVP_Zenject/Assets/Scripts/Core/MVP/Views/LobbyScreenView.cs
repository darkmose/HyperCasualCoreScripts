using Core.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.MVP
{
    public class LobbyScreenView : BaseScreenView
    {
        public override ScreenType Type => ScreenType.Game;
        [SerializeField] private Button _startButton;
        [SerializeField] private LevelProgressBarView _levelProgressBarView;

        private System.Action _startButtonCallback;
        private DiContainer _diContainer;

        [Inject]
        private void Constructor(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

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
            var uiManager = _diContainer.Resolve<UIManager>();
            uiManager.RegisterView(this);
            _startButton.onClick.AddListener(() => _startButtonCallback?.Invoke());
            base.OnAwake();
        }

    }

}