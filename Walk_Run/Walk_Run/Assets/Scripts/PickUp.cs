using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string pickUpName;
    public string pickUpType;
    public int PointsToAdd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WinGame.AddPoints(PointsToAdd);
            Destroy(gameObject);
        }
    }
}
