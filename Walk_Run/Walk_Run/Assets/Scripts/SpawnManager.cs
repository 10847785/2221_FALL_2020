using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int enemyIndex;

    void Update()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(enemyPrefabs[enemyIndex], new Vector3(0, 0, 0), enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
}
