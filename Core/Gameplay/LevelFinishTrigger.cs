using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.States;
using Core.DISimple;
using Core.Events;

namespace Core.Gameplay
{
    public class LevelFinishTrigger : MonoBehaviour
    {
        private const string PlayerTagName = "MainCharacter";

        public event System.Action OnLevelFinished;
        public float CurrentPosZ => transform.position.z;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTagName))
            {
                OnLevelFinished?.Invoke();
                EventAggregator.Post<GameFinishEvent>(this, new GameFinishEvent());
                if (TryGetComponent(out BoxCollider boxCollider))
                {
                    boxCollider.enabled = false;
                }
            }
        }
    }
}