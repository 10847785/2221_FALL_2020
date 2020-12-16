using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public FloatData maxHealth;
    public Transform spawnPoint;
    public int points = 10;
    public UnityEvent EnemyRespawn, lessThanZeroEvent;
    public float amount = 10;

 /*   private void OnEnable()
    {
        currentHealth = maxHealth.value;
    }

    private void Start()
    {
        currentHealth = maxHealth.value;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
    } */

    public void UpdateHealth()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            lessThanZeroEvent.Invoke();
        } 
    }

    /* public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10) 
        currentHealth.value -= amount;
        if (currentHealth.value <= 0)
        {
            currentHealth.value = 0;
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            currentHealth.value = maxHealth.value;
            
            
        }
    } */

   /* private void Update()
    {
        if (currentHealth <= 0f)
        {
            //UnityEvent = EnemyRespawn;
        } 
    } */
}
