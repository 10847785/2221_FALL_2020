using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    //public FloatData value;
    public GameObject spawnPoint;
    private ClampFloatData healthClamp;
    public GameObject enemy;
    private WaitForSeconds wfs;
    public float holdTime = 5;

    public void RespawnEnemy()
    {
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        enemy.SetActive(false);
        enemy.transform.position = spawnPoint.transform.position;
        enemy.transform.rotation = spawnPoint.transform.rotation;
        yield return wfs;
        enemy.SetActive(true);
    }

    private void Start()
    {
        wfs = new WaitForSeconds(holdTime);
    }

    /* private void Start()
     {
         healthClamp = GetComponent<ClampFloatData>();
     }
 
     private void Update()
     {
         if (value.value <=0f)
         {
             healthClamp.enabled = false;
             transform.position = spawnPoint.transform.position;
 
             if (transform.position == spawnPoint.transform.position)
             {
                 healthClamp.enabled = true;
                 value.value = 50f;
             }
         }
     }*/
}
