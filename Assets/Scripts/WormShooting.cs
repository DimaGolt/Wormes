using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormShooting : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform muzzle;
    public WormAiming aimingScript;

    public void FireProjectile(int power)
    {
        GameObject insProjectile = Instantiate(ProjectilePrefab, muzzle.transform.position, muzzle.transform.rotation);
        insProjectile.GetComponent<Projectile>().Initialize(power, aimingScript.getShootingVector());
    }
}
