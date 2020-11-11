using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAnimation : MonoBehaviour
{
    public float x_speed = 3f;

    private void Update()
    {
        transform.Rotate(x_speed, 0, 0);
    }
}
