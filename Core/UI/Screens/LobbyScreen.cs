using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class LobbyScreen : BaseScreenView
    {
        public override ScreenType Type => ScreenType.Lobby;
        public override ViewType View => ViewType.Screen;

        public Button StartButton => _startButton;

        [SerializeField] private Button _startButton;
        [SerializeField] private Text _levelNumber;

        private System.Action _startButtonCallback;

        public void InitCallback(System.Action startButtonCallback)
        {
            _startButtonCallback = startButtonCallback;
        }

        public void SetLevelNumber(int levelNumber) 
        {
            _levelNumber.text = $"LEVEL {levelNumber}";
        }

        public void ShowElement(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public void HideElement(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        protected override void OnAwake()
        {
            UIManager.RegisterView(this);
            base.OnAwake();
            _startButton.onClick.AddListener(OnStartButtonHandler);
        }

        private void OnStartButtonHandler()
        {
            _startButtonCallback?.Invoke();
        }
    }
}