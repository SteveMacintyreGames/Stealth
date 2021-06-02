using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSee : MonoBehaviour
{
    [SerializeField] GameObject _gameOverCutScene;

    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            //Debug.Log("Darren Spotted!");
            _gameOverCutScene.gameObject.SetActive(true);
        }
    }
}
