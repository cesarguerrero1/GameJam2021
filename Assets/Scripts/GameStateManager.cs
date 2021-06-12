using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{


    public GameObject pauseMenu;
    public GameObject victoryScreen;
    public GameObject lossScreen;
    public enum GameState{
        playing,
        paused,
        wonGame,
        gameOver,
    }

    public GameState currentGameState;
    
    void Start(){
        currentGameState = GameState.playing;
    }

    public void OnRetry(){
        SceneManager.LoadScene("LoadingScreen");
    }

    public void OnMainMenu(){
        SceneManager.LoadScene("Start-Menu");
    }

    void Update(){
        switch(currentGameState){
            case GameState.playing:
                //Resume game and hide the pause screen
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                break;
            case GameState.paused:
                //Stop the game and overlay a pause screen. Include a button to resume game or go to main-menu.
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                break;
            case GameState.wonGame:
                //Stop the game and overlay a gameover screen. Include a button to restart game or go to main-menu.
                victoryScreen.SetActive(true);
                Time.timeScale = 0f;
                break;
            case GameState.gameOver:
                //Stop the game and overlay a gameover screen. Include a button to restart game or go to main-menu.
                lossScreen.SetActive(true);
                Time.timeScale = 0f;
                break;
        }
    }
}
