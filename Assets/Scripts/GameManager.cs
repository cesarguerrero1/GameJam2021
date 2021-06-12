using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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

    void Update(){
        switch(currentGameState){
            case GameState.playing:
                //Resume game and hide the pause screen
                Time.timeScale = 1f;
                break;
            case GameState.paused:
                //Stop the game and overlay a pause screen. Include a button to resume game or go to main-menu.
                Time.timeScale = 0f;
                break;
            case GameState.wonGame:
                //Stop the game and overlay a gameover screen. Include a button to restart game or go to main-menu.
                Time.timeScale = 0f;
                break;
            case GameState.gameOver:
                //Stop the game and overlay a gameover screen. Include a button to restart game or go to main-menu.
                Time.timeScale = 0f;
                break;
        }
    }
}
