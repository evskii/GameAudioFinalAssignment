using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyController : MonoBehaviour, IDamageable
{
    public int maxHealth;
    public int currentHealth;

    private void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amt) {
        currentHealth -= amt;

        if (currentHealth <= 0) {
             Die();
        }
    }

    public void Die() {
        //Code here for them to die!
        Destroy(gameObject);
    }
    
}
