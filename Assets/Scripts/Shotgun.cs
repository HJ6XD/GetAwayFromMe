using System.Collections;
using UnityEngine;

public class Shotgun : Weapons
{
    private Quaternion newCustomDir;
    float lastReload = 0;
    void Start()
    {
        newCustomDir = muzle.rotation;
        for (int i = 0; i < defaultPoolSize; i++)
        {
            GameObject bulletClone = Instantiate(bulPrefab);
            bulletPool.Add(bulletClone);
            bulletClone.SetActive(false);
        }
    }
    void Update()
    {

        if (IsReloading && Time.time > lastReload + reloadTime)
        {
            curBullets++;
            WeaponsUIManager.wuiInstance.UpdateCurBulText(curBullets, maxBullets);
            lastReload = Time.time;

            if (curBullets == maxBullets)
                IsReloading = false;
        }
    }

    public override void Reload()
    {
        if (curBullets == maxBullets)
            return;

        IsReloading = true;
        lastReload = Time.time;
    }

    public override void Fire()
    {
        if (curBullets <= 0 || Time.time < firerate + lastShot)
            return;

        int bul2Sut = 5;
        int cdir = -20;
        newCustomDir = muzle.rotation;

        for (int i = 0; i < bul2Sut; i++)
        {
            float rotationOffset = (newCustomDir.y + cdir);
            Vector3 eulerOffset = (new Vector3(0, rotationOffset, 0)) + muzle.rotation.eulerAngles;

            newCustomDir = Quaternion.Euler(eulerOffset);

            if (TryGetBul(out GameObject bullet))
                SetBulSettings(ref bullet);
            if (bullet == null)
            {
                bullet = Instantiate(bulPrefab);
                SetBulSettings(ref bullet);
            }
            cdir += 10;
        }
        lastShot = Time.time;
        curBullets--;
        WeaponsUIManager.wuiInstance.UpdateCurBulText(curBullets, maxBullets);
        ControladordeAudiio.audioInstance.EjecutarSonido(bulSound);

        IsReloading = false;
    }
    protected override void SetBulSettings(ref GameObject _bul)
    {
        _bul.SetActive(true);
        _bul.transform.SetPositionAndRotation(muzle.position, newCustomDir);
        Rigidbody rb = _bul.GetComponent<Rigidbody>();
        Bullet bulcomp = _bul.GetComponent<Bullet>();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(_bul.transform.forward * bulSpeed);
        bulcomp.SetDamage(bulDamage);
    }
}
