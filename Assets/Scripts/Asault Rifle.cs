using UnityEngine;

public class AsaultRifle :  Weapons
{
    void Start()
    {
        for (int i = 0; i < defaultPoolSize; i++)
        {
            GameObject bulletClone = Instantiate(bulPrefab);
            bulletPool.Add(bulletClone);
            bulletClone.SetActive(false);
        }
    }
}
