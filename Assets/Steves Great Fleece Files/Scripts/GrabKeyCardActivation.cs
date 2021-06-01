using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    public GameObject keycardCutscene;

    //I'm sure I set the activation track for Darren and the guard correctly
    //but they're not turning off in gameplay so I'm doing it manually.
    public GameObject guard;
    public GameObject darren;
    public GameObject cutScene;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            keycardCutscene.gameObject.SetActive(true);
            StartCoroutine(TurnGamePlayCharactersOffTemporarily());
            
        }
    }

    IEnumerator TurnGamePlayCharactersOffTemporarily()
    {
        guard.SetActive(false);
        darren.SetActive(false);
        yield return new WaitForSeconds(6f);        
        guard.SetActive(true);
        darren.SetActive(true);
        cutScene.SetActive(false);
       
        
        
    }

}
