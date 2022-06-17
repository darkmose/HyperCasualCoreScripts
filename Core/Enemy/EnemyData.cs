using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] private EnemyLifeSystem _enemyLifeSystem;
    public EnemyLifeSystem LifeSystem => _enemyLifeSystem;
}
