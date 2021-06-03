using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static MainMenu _instance;
    public static MainMenu Instance
    {
        get
        {
        if(_instance == null)
        {
            Debug.LogError("MainMenu is null");
        }
        
        return _instance;  
        }
      
    }

void Awake()
{
    _instance = this;
}
 public void StartGame()
 {
     SceneManager.LoadScene("LoadingScreen");
 }

 public void Quit()
 {
     Application.Quit();
 }
}
