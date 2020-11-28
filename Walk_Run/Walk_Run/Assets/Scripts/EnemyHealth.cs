using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 3;
    public Transform spawnPoint;
    public int points = 10;

    private void Start()
    {
        currentHealth = maxHealth;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            currentHealth = maxHealth;
        }
    }
}
