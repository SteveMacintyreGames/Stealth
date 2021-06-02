using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{

    public GameObject winCutScene;
   

 void OnTriggerEnter(Collider other)
 {
     if(other.tag == "Player" && GameManager.Instance.HasCard)
     {
        
         winCutScene.gameObject.SetActive(true);
     }
     else
     {
         Debug.Log("You don't have the card!");
     }
 }
}
