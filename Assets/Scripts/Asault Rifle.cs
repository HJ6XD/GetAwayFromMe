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
    void Update()
    {
        if (Input.GetMouseButton(0) && curBullets != 0 && Time.time > firerate + lastShot)
            Fire();

        if(Input.GetKeyDown(KeyCode.R) && curBullets != maxBullets)
            Reload();
    }
}
