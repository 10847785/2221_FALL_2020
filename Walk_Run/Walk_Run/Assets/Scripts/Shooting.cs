using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public int ammoCount = 10;
    public int maxAmmo = 10;
    public GameObject prefab;
    public Transform Instancer;
    public float reloadTime;
    public WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    public Image coolDownImage;
    private bool canShoot = true;

    private void Start()
    {
       // reloadTime = new WaitForSeconds(2f);
       coolDownImage.fillAmount = 0;
       ammoCount = maxAmmo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && ammoCount > 0 && canShoot)
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
        canShoot = false;
        var countDown = reloadTime;
        while (countDown > 0)
        {
            yield return wffu;
            countDown -= .01f;
            countDown = countDown - .01f;
            coolDownImage.fillAmount = countDown / reloadTime;
        }
       // yield return reloadTime;
        ammoCount = maxAmmo;
        canShoot = true;
    }
    
}
