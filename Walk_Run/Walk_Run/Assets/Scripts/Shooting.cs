using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shooting : MonoBehaviour
{
    public int ammoCount = 10;
    public int maxAmmo = 10;
    public GameObject prefab;
    public Transform Instancer;
    public WaitForSeconds reloadTime;

    private void Start()
    {
        reloadTime = new WaitForSeconds(2f);
        ammoCount = maxAmmo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && ammoCount > 0)
        {
            fire();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
        }
    }

    private void fire()
    {
        Instantiate(prefab, Instancer.position, Instancer.rotation);
        ammoCount--;
        
        if (ammoCount == 0)
        {
            StartCoroutine(reload());
        }
    }

    private IEnumerator reload()
    {
        yield return reloadTime;
        ammoCount = maxAmmo;
    }
    
}
