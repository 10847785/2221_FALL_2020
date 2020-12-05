using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    // Float that acts as a health bar
    // OnTriggerEnter function needs to know what's its hit by
    // If Statement (if bullet hits take damage)
    // Damage determend by value  Public float damageValue;
    // Use UnityEvent with EnemyRespawn Script
    // Another if statement to see if your out of health then call the UnityEvent statement above this line
    
  //  public float enemyHealth;

    private void OnTriggerEnter(Collider other)
    {
     //   if ("Bullet")
    }
}
