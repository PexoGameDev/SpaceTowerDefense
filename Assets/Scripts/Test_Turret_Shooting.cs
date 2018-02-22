using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Turret_Shooting : MonoBehaviour, ITurretShootingModule {

    public GameObject BulletPrefab;
    [SerializeField]
    Turrets.DamageType DamageType;
    [SerializeField]
    int DamageUpgrade = 50;
    [SerializeField]
    Vector2 WeaponDamage = new Vector2(100, 200);
    [SerializeField]
    float WeaponDelayUpgrade = 0.01f;
    [SerializeField]
    float WeaponDelay = 0.2f;

    float ShootingSpeed;
    bool CanShoot = true;
    Coroutine ActualShooting;

    private void Start()
    {
        ShootingSpeed = 1 / WeaponDelay;
    }

    public void StartShooting(IEnemy Target)
    {
        ActualShooting = StartCoroutine(Shooting(Target));
    }

    public void StopShooting()
    {
        if(ActualShooting!=null)
        StopCoroutine(ActualShooting);
    }

    IEnumerator Shooting(IEnemy Target)
    {
        for (;;)
        {
                if (CanShoot)
                {
                    StartCoroutine(Shoot(Target));
                    yield return null;
                }
                yield return new WaitForEndOfFrame();
            }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(WeaponDelay);
        CanShoot = true;
    }

    IEnumerator Shoot(IEnemy Target)
    {
        GameObject myBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        myBullet.GetComponent<Bullet_Spinning>().MyTarget = Target.GetGameObject();
        Target.GetDamaged((int)Random.Range(WeaponDamage.x, WeaponDamage.y), DamageType);
        CanShoot = false;
        StartCoroutine(Reload());
        yield return null;
    }

    public void UpgradeTurretShooting()
    {
        WeaponDamage.x += DamageUpgrade;
        WeaponDamage.y += DamageUpgrade*2;
        WeaponDelay -= WeaponDelayUpgrade;
        ShootingSpeed = 1 / WeaponDelay;
    }

    public string GetDamage()
    {
        return string.Format("{0} - {1}", WeaponDamage.x, WeaponDamage.y);
    }

    public string GetShootingFrequency()
    {
        return ShootingSpeed.ToString("F2")+"Hz";
    }
}
