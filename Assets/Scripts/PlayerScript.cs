using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int maxlife;
    int life;
    [SerializeField] float speed; 
    public bool canRecibeDamage = true;
    bool isDead = false;

    [SerializeField] AudioClip dmg;
    private void Start()
    {
        life = maxlife;                
        ControladorUI.uiInstance.UpdateLifeText(life);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (!isDead)
        {
            //Movimiento del jugador
            if (Input.GetKey(KeyCode.W))
                transform.position = new Vector3(transform.position.x, 1, transform.position.z + (speed * Time.deltaTime));
            if (Input.GetKey(KeyCode.S))
                transform.position = new Vector3(transform.position.x, 1, transform.position.z - (speed * Time.deltaTime));
            if (Input.GetKey(KeyCode.D))
                transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), 1, transform.position.z);
            if (Input.GetKey(KeyCode.A))
                transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), 1, transform.position.z);
        }
    }
    public void RecibeDamage(int _damage)
    {
        life -= _damage;
        if (life < 0)
        {
            PlayerDead();
        }
        ControladorUI.uiInstance.UpdateLifeText(life);
        ControladordeAudiio.audioInstance.EjecutarSonido(dmg);        
    }

    void PlayerDead()
    {
        GetComponent<PlayerLookAtCursor>().StopLooking();
        ControladorUI.uiInstance.GameOverScreen();
        Timer.timerInstance.isTicking = false;
        isDead = true;
    }
}
