using UnityEngine;

public class EnemyLifeSystem : MonoBehaviour
{
    private const string BulletTagName = "Bullet";
    public event System.Action OnEnemyDie;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BulletTagName))
        {
            other.gameObject.SetActive(false);
            OnEnemyDie?.Invoke();
        }
    }
}
