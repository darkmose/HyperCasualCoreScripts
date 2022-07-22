using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class WinWindow : BaseWindowView
    {
        public override WindowType Type => WindowType.LevelCompleted;
        public override ViewType View => ViewType.Window;

        [SerializeField] private Button _nextButton;
        [SerializeField] private TMPro.TextMeshProUGUI _winText;
        [SerializeField] private TMPro.TextMeshProUGUI _currentMoney;
        [SerializeField] private TMPro.TextMeshProUGUI _bonusMoney;

        public Button NextLevelButton => _nextButton;

        private System.Action _nextButtonCallback;

        public void SetInteractableButton(Button button, bool isInteractable)
        {
            button.interactable = isInteractable;
        }

        public void InitCallback(System.Action nextButtonCallback)
        {
            _nextButtonCallback = nextButtonCallback;
        }

        public void SetCurrentMoney(int value)
        {
            _currentMoney.text = value.ToString();
        }

        public void SetBonusMoney(int value)
        {
            _bonusMoney.text = value.ToString();
        }

        public void SetWinLevel(int level)
        {
            string winText = $"LEVEL {level}\n";
            winText += "COMPLETE";
            _winText.text = winText;
        }

        protected override void OnAwake()
        {
            UIManager.RegisterView(this);
            base.OnAwake();
            _nextButton.onClick.AddListener(OnNextButtonHandler);
        }

        private void OnNextButtonHandler()
        {
            _nextButtonCallback?.Invoke();
        }
    }

}
