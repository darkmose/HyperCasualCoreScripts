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


        [SerializeField] private GameObject _playerController;
        [SerializeField] private Text _currentLevel;


        public void SetCurrentLevel(int level) 
        {
            _currentLevel.text = level.ToString();
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