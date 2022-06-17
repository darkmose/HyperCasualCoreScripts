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
        [SerializeField] private Text _winText;

        private System.Action _nextButtonCallback;

        public void InitCallback(System.Action nextButtonCallback)
        {
            _nextButtonCallback = nextButtonCallback;
        }

        public void SetWinLevel(int level) 
        {
            string winText = $"LEVEL {level}\n";
            winText += "COMPLETED";
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
