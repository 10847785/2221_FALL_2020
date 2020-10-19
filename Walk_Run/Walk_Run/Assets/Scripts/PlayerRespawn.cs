using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public FloatData value;
    public GameObject spawnPoint;
    

    private void Update()
    {
        if (value.value <=0f)
        {
            gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}
