using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestDamage : MonoBehaviour
{
    public float damageAmount = 20f;
    public FloatData nestHealth, nestMax;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Nest it hit " + damageAmount);
            nestHealth.value += damageAmount;
            nestHealth.value = Mathf.Clamp(nestHealth.value, 0f, nestMax.value);
        }
    }
}
