using Core.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/Game Config")]
    public class GameConfiguration : ScriptableObject
    {
        public PlayerConfiguration PlayerConfiguration;
    }

    [System.Serializable]
    public sealed class PlayerConfiguration
    {
        public float MoveSpeed = 1f;
        public float ControlSensitivity = 1f;
        public float MoveBoundOffset = 5f;
    }
}