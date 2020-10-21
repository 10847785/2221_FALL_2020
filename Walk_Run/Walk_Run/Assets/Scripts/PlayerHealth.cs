using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float healthAmount = 20f;
    public FloatData playerHealth, maximumHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The damage is " + healthAmount);
            playerHealth.value += healthAmount;
            playerHealth.value = Mathf.Clamp(playerHealth.value, 0f, maximumHealth.value);
        }
    }
}
