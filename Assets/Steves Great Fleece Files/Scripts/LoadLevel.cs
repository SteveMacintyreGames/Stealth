using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Image loadingBar;
    void Start()
    {
        StartCoroutine(LoadLevelAsync());
        loadingBar.fillAmount = 0;
    }

   IEnumerator LoadLevelAsync()
   {
       yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Game");

        while (!asyncOperation.isDone)
        {
            //change the fillbar
            loadingBar.fillAmount = asyncOperation.progress;
            yield return new WaitForEndOfFrame();
        }



   }
}
