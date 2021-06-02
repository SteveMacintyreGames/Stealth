using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{

    public AudioClip audioClip;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Instance.PlayVoiceOver(audioClip);
            //AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        }
    }
}
