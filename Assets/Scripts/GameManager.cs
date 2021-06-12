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

    }
}
