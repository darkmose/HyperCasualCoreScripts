using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
using Core.UI;

namespace Core.MVP
{
    public class GameScreenView : BaseScreenView
    {
        public override ScreenType Type => ScreenType.Game;
        [SerializeField] private TextMeshProUGUI _currentMoneyBalance;
        [SerializeField] private TextMeshProUGUI _currentLevel;

        private DiContainer _diContainer;

        [Inject]
        private void Constructor(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void SetCurrentLevel(int level)
        {
            _currentLevel.text = $"Level {level}";
        }

        public void SetCurrentMoneyBalance(int money)
        {
            if (money > 1000)
            {
                var resultMoney = (float)money / 1000f;
                _currentMoneyBalance.text = resultMoney.ToString("0.00k");
            }
            else
            {
                _currentMoneyBalance.text = money.ToString();
            }

        }

        protected override void OnAwake()
        {
            var uiManager = _diContainer.Resolve<UIManager>();
            uiManager.RegisterView(this);

            base.OnAwake();            
        }
    }
}