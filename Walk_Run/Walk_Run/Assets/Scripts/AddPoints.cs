using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    public int addPoints;

    private void OnTriggerEnter(Collider other)
    {
        WinGame.AddPoints (addPoints);
    }
}
