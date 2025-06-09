using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawn")]
    [SerializeField] MutantFactory mutantf;
    [SerializeField] InfamousFactory infamousf;
    [SerializeField] AbominationFactory abominationf;

    public GameObject[] enemyArray;
    [SerializeField]
    float timeBetwenSpawns = 5,
        randomTimeIncrease = 0,
        increaseSpawn = 0,
        minSpawnTime = 0.65f,
        maxNumItemss = 0;
    [SerializeField] private int poolObjects = 0;
    int rnd = 0;
    int lenghtFP = 0;
    private float waitForNew = 1;
    int itemsSpawned = 0;

    private List<GameObject> enemiesToSpawn;

    [Header("Random Pos")]
    private float minX, maxX, minY, maxY;
    [SerializeField] Transform[] puntos;

    private void Awake()
    {
        lenghtFP = enemyArray.Length;
        waitForNew = timeBetwenSpawns + Random.Range(0, randomTimeIncrease);
        if (poolObjects > 0)
        {
            GameObject tempObject;
            enemiesToSpawn = new List<GameObject>();

            for (int i = 0; i < poolObjects; i++)
            {
                rnd = Random.Range(0, lenghtFP);
                tempObject = Instantiate(enemyArray[rnd], transform.position, Quaternion.identity);
                tempObject.SetActive(false);
                enemiesToSpawn.Add(tempObject);
            }
        }

        infamousf.GetEnemyType(enemyArray[0]);
        mutantf.GetEnemyType(enemyArray[1]);
        abominationf.GetEnemyType(enemyArray[2]);
    }

    private void Start()
    {
        lenghtFP = enemyArray.Count();
        minX = puntos.Min(puntos => puntos.position.x);
        maxX = puntos.Max(puntos => puntos.position.x);
        minY = puntos.Min(puntos => puntos.position.y);
        maxY = puntos.Max(puntos => puntos.position.y);
    }

    private void Update()
    {
        if(waitForNew <= 0 && (maxNumItemss == 0 || maxNumItemss > itemsSpawned))
        {
            Lanza();
            if(increaseSpawn >=0 && timeBetwenSpawns > minSpawnTime)
                timeBetwenSpawns -= increaseSpawn;
            waitForNew = timeBetwenSpawns;
            if (randomTimeIncrease > 0)
                waitForNew += Random.Range(0, randomTimeIncrease);
            if(waitForNew < minSpawnTime)
                waitForNew = minSpawnTime;
            itemsSpawned += 1;
        }
        else
            waitForNew -= Time.deltaTime;
    }

    void Lanza()
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        if(TryGetEnemy(out GameObject enemy))
        {
            Enemy eComp = enemy.GetComponent<Enemy>();
            eComp.SetPosition(randomPos);
            eComp.ResteEnemy();
            enemy.SetActive(true);
        }
        if(enemy == null)
        {
            rnd = Random.Range(0, 5);
            switch (rnd)
            {
                case <3:
                    enemy = infamousf.InstantiateEnemy();
                    break;
                case <5:
                    enemy = mutantf.InstantiateEnemy();
                    break;
                case 5:
                    enemy = abominationf.InstantiateEnemy();
                    break;
            }

            enemiesToSpawn.Add(enemy);
        }
    }

    bool TryGetEnemy(out GameObject _enem)
    {
        foreach(GameObject enemy in enemiesToSpawn)
        {
            if (enemy.activeInHierarchy == true) continue;
            
            _enem = enemy;
            return true;
        }
        _enem = null;
        return false;
    }
}
