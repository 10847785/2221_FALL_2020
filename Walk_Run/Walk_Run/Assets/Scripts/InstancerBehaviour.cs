using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancerBehaviour : MonoBehaviour
{
    public GameObject prefab;
   /* public float holdTime = 0.5f;
    public UnityEvent startEvent, onCallEvent, restartLoopEvent;
    public int instanceCount = 30;
    private int counter = 0;
    
    
    private WaitForSeconds wfs;
    
    private void Start()
    {
        wfs = new WaitForSeconds(holdTime);
    }

    public void StartLoopEvents()
    {
        StartCoroutine(CallInstanceEvent());
    }

    private IEnumerator CallInstanceEvent()
    {
        while (counter < instanceCount)
        {
            onCallEvent.Invoke();
            counter++;
            yield return wfs;
        }
        counter = 0;
        restartLoopEvent.Invoke();
    } */
    
    //Make a method to call the Instance Method

    public void Instance()
    {
        var location = transform.position;
        var var = Instantiate(prefab);
    }
}
