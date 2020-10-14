using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shooting : MonoBehaviour
{
    public int ammoCount = 100;
    public GameObject prefab;
    public float bulletForce;
    public Transform Instancer;

    private void Update()
    {
        if (Input.GetKeyDown("Fire1") && ammoCount > 0)
        {
            Instantiate(prefab, Instancer.position, Instancer.rotation);
        }
    }
}
