using UnityEngine;

public class Uzi : Weapons
{
    private Quaternion newCustomDir;

    void Start()
    {
        for (int i = 0; i < defaultPoolSize; i++)
        {
            GameObject bulletClone = Instantiate(bulPrefab);
            bulletPool.Add(bulletClone);
            bulletClone.SetActive(false);
        }
    }

    public override void Fire()
    {
        if (curBullets <= 0 || Time.time < firerate + lastShot)
            return;

        float spread = Random.Range(-10,10);
        newCustomDir = muzle.rotation;

        float rotationOffset = (newCustomDir.y + spread);
        Vector3 eulerOffset = (new Vector3(0, rotationOffset, 0)) + muzle.rotation.eulerAngles;

        newCustomDir = Quaternion.Euler(eulerOffset);

        if (TryGetBul(out GameObject bullet))
            SetBulSettings(ref bullet);
        if (bullet == null)
        {
            bullet = Instantiate(bulPrefab);
            SetBulSettings(ref bullet);
        }
        
        lastShot = Time.time;
        curBullets--;
        WeaponsUIManager.wuiInstance.UpdateCurBulText(curBullets, maxBullets);
        ControladordeAudiio.audioInstance.EjecutarSonido(bulSound);

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
