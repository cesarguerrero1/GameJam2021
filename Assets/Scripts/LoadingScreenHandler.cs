using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenHandler : MonoBehaviour
{
    
    IEnumerator AsyncLoadScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("InGame");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void StartLoad(){
        StartCoroutine(AsyncLoadScene());
    }
    void Start(){
        //Different parts of the game pause time so to be safe we are forcing it correctly here.
        Time.timeScale = 1f;
        Invoke("StartLoad", 2.5f);
    }


}
