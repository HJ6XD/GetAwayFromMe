using UnityEngine;
using UnityEngine.Audio;

public class ControladordeAudiio : MonoBehaviour
{
    [SerializeField] private AudioSource music, sounfEefect;

    public static ControladordeAudiio audioInstance;

    private void Awake()
    {
        if (audioInstance != null && audioInstance != this) 
            Destroy(this);
        else
            audioInstance = this;
    }
    public void EjecutarSonido(AudioClip sonido)
    {
        sounfEefect.PlayOneShot(sonido);
    }
    public void EjecutarMusica(AudioClip musica)
    {
        sounfEefect.PlayOneShot(musica);
    }

}
