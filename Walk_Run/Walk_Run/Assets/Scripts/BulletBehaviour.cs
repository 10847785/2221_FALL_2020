using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody rBody;
    public float bulletForce;
    public float lifeTime;
    public int damage = 1;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var hit = other.gameObject;
            var health = hit.GetComponent<EnemyHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("Projectile hits!");
            }
        }
    }

    private IEnumerator Start()
    {
        rBody = GetComponent<Rigidbody>();
        
        rBody.AddRelativeForce(Vector3.forward*bulletForce);
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    
}
