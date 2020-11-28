using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageAmount = 20f;
    public FloatData enemyHealth, enemyMax;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy it hit " + damageAmount);
            enemyHealth.value += damageAmount;
            enemyHealth.value = Mathf.Clamp(enemyHealth.value, 0f, enemyMax.value);
        }
    }
}
