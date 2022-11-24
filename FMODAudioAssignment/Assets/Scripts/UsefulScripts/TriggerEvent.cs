using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent enterEvent;
    public UnityEvent exitEvent;

    public bool useExitEvent = false;

    public bool limitToSpecificTags = false;
    public string[] specificTags;
    
    private void OnTriggerEnter(Collider other) {
        if(limitToSpecificTags){
            if(specificTags.Contains(other.transform.tag)) {
                enterEvent.Invoke();
            }
        } else {
            enterEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (useExitEvent) {
            if(limitToSpecificTags){
                if(specificTags.Contains(other.transform.tag)) {
                    exitEvent.Invoke();
                }
            } else {
                exitEvent.Invoke();
            }
        }
       
    }

}
