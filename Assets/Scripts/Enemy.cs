using UnityEngine;
using UnityEngine.AI;
public enum EnemyType
{
    Mutant,
    Infamous,
    Abominaion
}
public class Enemy : MonoBehaviour, IEnemies
{
    int life;
    [SerializeField] int maxlife;
    [SerializeField] int damage;
    [SerializeField] float speed;
    [SerializeField] public EnemyType enemyType;
    [SerializeField] Transform player;
    NavMeshAgent agent;

    [SerializeField] protected AudioClip dmg;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        life = maxlife;
        agent.speed = speed;
    }
    void Update()
    {
        agent.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
        if (player != null) 
            player.RecibeDamage(damage);
    }
    public void RecibeDamage(int _dmg)
    {
        life -= _dmg;
        ControladordeAudiio.audioInstance.EjecutarSonido(dmg);
        if (life <= 0) { 
            gameObject.SetActive(false);
            ScoreManager.scoreInstance.GainPoints(maxlife);
        }
    }

    public void SetPosition(Vector2 pos) { 
    transform.position = new Vector3(pos.x, transform.position.y, pos.y);
    }

    public void ResteEnemy()
    {
        life = maxlife;
    }
}
