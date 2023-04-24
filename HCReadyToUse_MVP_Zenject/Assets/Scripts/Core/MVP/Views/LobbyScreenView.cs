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
        
        public void InitPresenter(LobbyScreenPresenter presenter)
        {
            _startButton.onClick.AddListener(presenter.OnStartButtonClickHandler);
        }

        public void SetCurrentLevel(int level)
        {
            _levelProgressBarView.InitProgressBar(level);
        }

        protected override void OnAwake()
        {
            base.OnAwake();
        }

    }

}