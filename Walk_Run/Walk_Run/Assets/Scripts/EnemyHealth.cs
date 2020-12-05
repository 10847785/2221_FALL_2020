using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 3;
    public Transform spawnPoint;
    public int points = 10;
    private UnityEvent EnemyRespawn;
    public int amount = 10;

    private void Start()
    {
        currentHealth = maxHealth;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10) 
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            currentHealth = maxHealth;
            
            
        }
    }

    private void Update()
    {
        if (currentHealth <= 0f)
        {
            //UnityEvent = EnemyRespawn;
        }
    }
}
