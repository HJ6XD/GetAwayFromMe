using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public virtual void GetEnemyType(GameObject _infa) { }
    public abstract GameObject InstantiateEnemy();
}