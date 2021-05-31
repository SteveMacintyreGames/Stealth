using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
   public GameObject gameOverCutscene;
   public Animator anim;

   void OnTriggerEnter(Collider other)
   {
       if (other.tag == "Player")
       {

           MeshRenderer render = GetComponent<MeshRenderer>();
           Color color = new Color (0.6f,.1f,.1f, .3f);
           render.material.SetColor("_TintColor", color);

           //Debug.Log("Camera sees Darren");
           anim.enabled = false;
           Invoke("EndGame", .75f);          

       }
   }

   void EndGame()
   {
       gameOverCutscene.gameObject.SetActive(true);
   }
}
