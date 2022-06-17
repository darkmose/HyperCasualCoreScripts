using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class GameScreen : BaseScreenView
    {
        public override ScreenType Type => ScreenType.Game;
        public override ViewType View => ViewType.Screen;

        public GameObject PlayerController => _playerController;
        public GameObject ProgressBar => _progressBar;
        public GameObject AimTarget => _aimTarget.gameObject;
        public GameObject ToastMessagesPanel => _toastMessagesPanel;

        [SerializeField] private Button _startButton;
        [SerializeField] private GameObject _playerController;
        [SerializeField] private GameObject _progressBar;
        [SerializeField] private Image _progressValue;
        [SerializeField] private Text _weaponYears;
        [SerializeField] private Text _currentLevel;
        [SerializeField] private Image _aimTarget;
        [SerializeField] private GameObject _toastMessagesPanel;

        /// <summary>
        /// From 0 to 1
        /// </summary>
        public void SetProgressValue(float value)
        {
            _progressValue.fillAmount = value;
        }

        public void SetCurrentLevel(int level) 
        {
            _currentLevel.text = level.ToString();
        }

        public void SetWeaponYears(int years) 
        {
            _weaponYears.text = $"{years} YEARS";
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
        }

    }
}