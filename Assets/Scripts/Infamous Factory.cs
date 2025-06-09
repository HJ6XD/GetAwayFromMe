using UnityEngine;

public class InfamousFactory : EnemyFactory
{
    GameObject infamous;

    public override void GetEnemyType(GameObject _infa)
    {
        infamous = _infa;
    }
    public override GameObject InstantiateEnemy()
    {
        Instantiate(infamous);
        return infamous;
    }
}