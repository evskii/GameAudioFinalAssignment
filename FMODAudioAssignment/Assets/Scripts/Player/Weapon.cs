using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public int maxAmmo;
    public int currentAmmo;
    public float gunRange;
    public int gunDamage;
    public Transform muzzle;

    private void Start() {
        currentAmmo = maxAmmo;
    }

    //Called from Player Input Component
    private void OnFireLeft() {
        if (currentAmmo > 0) {
            //Raycast from muzzle to find IDamageable
            RaycastHit hit;
            if (Physics.Raycast(muzzle.transform.position, muzzle.forward, out hit, gunRange)) {
                // Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.TryGetComponent(out IDamageable damageable)) { //If the thing that it hits has code with IDamageable in it then call it
                    damageable.TakeDamage(gunDamage);
                }
            }

            currentAmmo--;
            
        } else {
            Debug.Log("OUT OF AMMO");
        }
    }

    //Called from Player Input Component
    private void OnReload() {
        currentAmmo = maxAmmo;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(muzzle.position, muzzle.forward * gunRange);
    }
}
