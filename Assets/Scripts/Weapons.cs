using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public enum WeaponType
{
    AsaultRifle,
    Shotgun,
    Uzi
}
public abstract class Weapons : MonoBehaviour
{
    [SerializeField] protected float firerate;
    protected float lastShot;

    [SerializeField] protected int curBullets;
    [SerializeField] protected int maxBullets;
    [SerializeField] protected float reloadTime;
    public bool IsReloading;

    [SerializeField] protected int bulDamage;
    [SerializeField] protected float bulSpeed;
    [SerializeField] protected Transform muzle;

    [SerializeField] protected int defaultPoolSize = 10;
    [SerializeField] protected GameObject bulPrefab;

    [SerializeField] protected List<GameObject>  bulletPool;

    [SerializeField] protected AudioClip bulSound;
    public virtual void Reload()
    {
        if (curBullets == maxBullets)
            return;
        StartCoroutine(RelodBullets());
    }

    protected void OnEnable()
    {
        WeaponsUIManager.wuiInstance.UpdateCurBulText(curBullets, maxBullets);
    }

    IEnumerator RelodBullets()
    {
        IsReloading = true;
        yield return new WaitForSeconds(reloadTime);
        curBullets = maxBullets;
        WeaponsUIManager.wuiInstance.UpdateCurBulText(curBullets, maxBullets);
        IsReloading = false;
    }

    public virtual void Fire()
    {
        if (curBullets <= 0 || Time.time < firerate + lastShot)
            return;

        if (TryGetBul(out GameObject bullet))
            SetBulSettings(ref bullet);
        if (bullet == null)
        {
            bullet = Instantiate(bulPrefab, muzle);
            SetBulSettings(ref bullet);
        }
        lastShot = Time.time;
        curBullets--;
        WeaponsUIManager.wuiInstance.UpdateCurBulText(curBullets, maxBullets);
        ControladordeAudiio.audioInstance.EjecutarSonido(bulSound);
    }
    protected virtual void SetBulSettings(ref GameObject _bul)
    {
        _bul.SetActive(true);
        _bul.transform.SetPositionAndRotation(muzle.position, Quaternion.identity);
        Rigidbody rb = _bul.GetComponent<Rigidbody>();
        Bullet bulcomp = _bul.GetComponent<Bullet>();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(muzle.forward * bulSpeed);
        bulcomp.SetDamage(bulDamage);
    }
    protected bool TryGetBul(out GameObject _bul)
    {
        foreach (GameObject b in bulletPool) {
            if (b.activeInHierarchy) continue;
            _bul = b;
            return true;
        }
        _bul = null;
        return false;
    }
}