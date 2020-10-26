﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public FloatData value, maxHealth;
    public GameObject spawnPoint;
    private ClampFloatData healthClamp;
    [SerializeField] private CharacterController myCharacterControllerScript;

    private void Start()
    {
        myCharacterControllerScript = GetComponent<CharacterController>();
        healthClamp = GetComponent<ClampFloatData>();
    }

    private void Update()
    {
        if (value.value <=0)
        {
            myCharacterControllerScript.enabled = false;
            healthClamp.enabled = false;
            transform.position = spawnPoint.transform.position;

            if (transform.position == spawnPoint.transform.position)
            {
                healthClamp.enabled = true;
                myCharacterControllerScript.enabled = true;
            }
        }
    }
}
