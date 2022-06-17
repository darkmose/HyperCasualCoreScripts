using Core.DISimple;
using Core.Gameplay;
using Core.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Level
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;

        public PlayerData SpawnPlayer(GameObject player)
        {
            var playerObj = Instantiate(player, _spawnPosition);
            EventAggregator.Post(this, new PlayerSpawnEvent());
            if (playerObj.TryGetComponent(out PlayerData playerData))
            {
                return playerData;
            }
            else
            {
                return default;
            }
        }
    }
}