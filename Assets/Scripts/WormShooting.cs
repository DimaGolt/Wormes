using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormShooting : MonoBehaviour
{
    public Transform muzzle;
    public WormAiming aimingScript;
    public WormWeapon weaponScript;

    public GameObject ProjectileRocketPrefab;
    public GameObject ProjectileGrenadePrefab;
    public GameObject ProjectileMinePrefab;
    public GameObject ProjectileDynamitePrefab;
    public GameObject ProjectileShotPrefab;

    public void FireProjectile(int power)
    {
        int weapon = weaponScript.GetWeapon();
        GameObject insProjectile;
        switch(weapon)
        {
            case 1:
            case 2:
                insProjectile = Instantiate(ProjectileRocketPrefab, muzzle.transform.position, muzzle.transform.rotation);
                insProjectile.GetComponent<Projectile>().Initialize(power, aimingScript.getShootingVector());
                break;
            case 3:
            case 4:
                insProjectile = Instantiate(ProjectileGrenadePrefab, muzzle.transform.position, muzzle.transform.rotation);
                insProjectile.GetComponent<Projectile>().Initialize(power, aimingScript.getShootingVector());
                break;
            case 5:
            case 6:
                insProjectile = Instantiate(ProjectileShotPrefab, muzzle.transform.position, muzzle.transform.rotation);
                insProjectile.GetComponent<Projectile>().Initialize(100, aimingScript.getShootingVector());
                break;
            case 7:
            case 8:
                break;
            case 9:
                insProjectile = Instantiate(ProjectileDynamitePrefab, muzzle.transform.position, muzzle.transform.rotation);
                insProjectile.GetComponent<Projectile>().Initialize(0, aimingScript.getShootingVector());
                break;
            case 10:
                insProjectile = Instantiate(ProjectileMinePrefab, muzzle.transform.position, muzzle.transform.rotation);
                insProjectile.GetComponent<Projectile>().Initialize(0, aimingScript.getShootingVector());
                break;
        }
    }
}
