using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioClip parte1;
    [SerializeField] private AudioClip parte2;
    [SerializeField] private AudioClip parte3;
    [SerializeField] private AudioClip transicion1a2;
    [SerializeField] private AudioClip transicion2a3;
    
    [SerializeField] private int totalEnemyQuant = 3;

    [SerializeField] private int qToChangeTo2;
    [SerializeField] private int qToChangeTo3;

    [SerializeField] private int expectedTimeTochange2;
    [SerializeField] private int expectedTimeTochange3;

    [SerializeField] bool playing2 = false, playing3 = false;
    public static MusicManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }
    void Start()
    {
        musicSource.clip = parte1;
        musicSource.Play();
    }

    public void UpdateTotalEnemyQuantity(int q)
    {
        totalEnemyQuant += q;
        if (totalEnemyQuant >= qToChangeTo3 && !playing3)
        {
            playing3 = true;
            StartCoroutine(ChangeClip(3));
        }
        else if (totalEnemyQuant >= qToChangeTo2 && !playing2)
        {
            playing2 = true;
            StartCoroutine(ChangeClip(2));
        }
    }

    IEnumerator ChangeClip(int clipToPlay)
    {
        if (clipToPlay == 2) {
            musicSource.Stop();
            musicSource.clip = transicion1a2;
            musicSource.Play();
            yield return new WaitForSeconds(expectedTimeTochange2);
            musicSource.Stop();
            musicSource.clip = parte2;
            musicSource.Play();

        }
        else if (clipToPlay == 3) {
            musicSource.Stop();
            musicSource.clip = transicion2a3;
            musicSource.Play();
            yield return new WaitForSeconds(expectedTimeTochange3);
            musicSource.Stop();
            musicSource.clip = parte3;
            musicSource.Play();
        }
    }
}
