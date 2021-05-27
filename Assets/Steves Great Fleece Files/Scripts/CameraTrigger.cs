using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Transform _triggerCam;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Debug.Log("Trigger entered");
            Camera.main.transform.position = _triggerCam.transform.position;
            Camera.main.transform.rotation = _triggerCam.transform.rotation;
        }
 
    }
}
