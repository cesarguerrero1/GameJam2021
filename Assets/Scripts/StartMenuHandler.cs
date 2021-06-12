using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour
{
    public void OnStart(){
        SceneManager.LoadScene("LoadingScreen");
    }

    public void onQuit(){
        Application.Quit();
    }
}
