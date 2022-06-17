using Core.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private MovementSystem _movementSystem;

        public MovementSystem MovementSystem => _movementSystem;
    }
}