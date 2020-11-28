using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public FloatData value;
    public GameObject spawnPoint;
    private ClampFloatData healthClamp;

    private void Start()
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
    }
}
