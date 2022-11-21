using Configuration;
using Core.ControlLogic;
using UnityEngine;
using Zenject;

namespace Core.GameLogic
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [Inject(Id = "GameControlPanel")] private IControlPanel _controlPanel;

        [Inject]
        private void Constructor(GameConfiguration gameConfiguration)
        {
            
        }
        
        


    }

}