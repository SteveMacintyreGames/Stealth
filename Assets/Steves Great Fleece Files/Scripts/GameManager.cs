using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is null");
            }
                return _instance;   
        }
    }

    public bool HasCard { get; set; }
    public PlayableDirector introCutScene;
    public Transform mainCameraPos;
    public GameObject player;
    public AudioSource music;




    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        StartCoroutine(PlayIntroCutscene());

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutScene.time = 60f;
            Initialize();
        }
    }
    
    void Initialize()
    {                
        introCutScene.gameObject.SetActive(false);
        ResetCam();
        player.gameObject.SetActive(true);
        music.Play();
        music.volume = .24f;
    }
    void ResetCam()
    {
        Camera.main.transform.position = mainCameraPos.position;
        Camera.main.transform.rotation = mainCameraPos.rotation;
    }
    
    IEnumerator PlayIntroCutscene()
    {
        introCutScene.gameObject.SetActive(true);
        yield return new WaitForSeconds(60f);
        Initialize();
    }

}
