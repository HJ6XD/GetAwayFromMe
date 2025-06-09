using UnityEngine;

public class MutantFactory : EnemyFactory
{
    GameObject mutant;
    public override void GetEnemyType(GameObject _muta)
    {
        mutant = _muta;
    }
    public override GameObject InstantiateEnemy()
    {
        Instantiate(mutant);
        return mutant;
    }
}