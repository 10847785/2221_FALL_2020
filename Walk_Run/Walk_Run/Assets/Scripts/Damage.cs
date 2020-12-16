using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount = 20f;
    public FloatData playerHealth, maximumHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The damage is " + damageAmount);
            playerHealth.value += damageAmount;
            playerHealth.value = Mathf.Clamp(playerHealth.value, 0f, maximumHealth.value);
        }
    }

    private void Update()
    {
        
    }
}
