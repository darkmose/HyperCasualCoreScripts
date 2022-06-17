using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class LoseWindow : BaseWindowView
    {
        public override WindowType Type => WindowType.LevelFail;
        public override ViewType View => ViewType.Window;

        [SerializeField] private Button _retryButton;
        private System.Action _retryButtonCallback;

        protected override void OnAwake()
        {
            UIManager.RegisterView(this);
            base.OnAwake();
            _retryButton.onClick.AddListener(OnRetryButtonHandler);
        }

        private void OnRetryButtonHandler()
        {
            _retryButtonCallback?.Invoke();
        }

        public void InitRetryButtonCallback(System.Action retryButtonCallback) 
        {
            _retryButtonCallback = retryButtonCallback;
        }
    }
}
