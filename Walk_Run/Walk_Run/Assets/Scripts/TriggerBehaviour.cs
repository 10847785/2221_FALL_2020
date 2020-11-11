using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class TriggerBehaviour : MonoBehaviour
{
    public Color newColor;
    public Color defaultColor;
    private MeshRenderer colorChange;

    public bool isOpen;
    private WaitForSeconds wfs;
    public int holdTime = 3;
    public GameObject door;
    public TimerUI timer;
    private void Start()
    {
        colorChange = GetComponent<MeshRenderer>();
        colorChange.material.color = defaultColor;
        
        wfs = new WaitForSeconds(holdTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        newColor.a = 0.5f;
        colorChange.material.color = newColor;
        
        door.SetActive(false);
        
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        colorChange.material.color = defaultColor;
       
        StartCoroutine(timer.Countdown());
        yield return wfs;
        isOpen = false;
        door.SetActive(true);
    } 
   
  /* public UnityEvent triggerEnterEvent, triggerExitEvent;
   public float delayTime = 0.01f;
   private WaitForSeconds waitObj;

   private void Start()
   {
       waitObj = new WaitForSeconds(delayTime);
   }

   private IEnumerator OnTriggerEnter(Collider other)
   {
       yield return waitObj;
       triggerEnterEvent.Invoke();
   }

   private void OnTriggerExit(Collider other)
   {
       triggerExitEvent.Invoke();
   } */
    
}
