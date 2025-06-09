using UnityEngine;

public class AbominationFactory : EnemyFactory
{
    GameObject abomination;
    public override void GetEnemyType(GameObject _abom)
    {
        abomination = _abom;
    }
    public override GameObject InstantiateEnemy()
    {
        Instantiate(abomination);
        return abomination;
    }
}