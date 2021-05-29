using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSee : MonoBehaviour
{
    [SerializeField] GameObject _gameOverCutScene;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Darren Spotted!");
        if (other.tag == "Player")
        {
            _gameOverCutScene.gameObject.SetActive(true);
        }
    }
}
