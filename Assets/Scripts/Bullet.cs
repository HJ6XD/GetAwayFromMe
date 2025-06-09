using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage;
    float lifeSpan = 3;
    float elapsedTime =0;

    public void SetDamage(int _damage) { damage = _damage; }

    private void OnEnable()
    {
        elapsedTime = 0;
    }

    private void Update()
    {
        if (elapsedTime > lifeSpan)
            gameObject.SetActive(false);

        elapsedTime += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        
        if (enemy != null)
            enemy.RecibeDamage(damage);
        
        this.gameObject.SetActive(false);
    }
}
