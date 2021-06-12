using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerGameInteraction : MonoBehaviour
{
    
    public GameObject GameManager;
    private GameStateManager GameStateManager;
    private bool isPaused = false;

    private float levelDistance = 100f;
    private float distanceTraveled = 0f;
    public float referenceAltitude;
    
    void Start(){
        GameStateManager = GameManager.GetComponent<GameStateManager>();

        //We need to know where the player exists in y so that if they fall we know that they fell out of the level. Game over!
        referenceAltitude = this.transform.position.y;
    }

    public void OnPause(InputAction.CallbackContext callback){
        
        if(callback.performed && isPaused == false){
            GameStateManager.currentGameState =  GameStateManager.GameState.paused;
            isPaused = true;
        }else if(callback.performed && isPaused){
            GameStateManager.currentGameState =  GameStateManager.GameState.playing;
            isPaused = false;
        }
    }

    void Update(){
        referenceAltitude = this.transform.position.y;
        if(referenceAltitude <= -5f){
            GameStateManager.currentGameState =  GameStateManager.GameState.gameOver;
        }

        if(distanceTraveled >= levelDistance){
             GameStateManager.currentGameState =  GameStateManager.GameState.wonGame;
        }
    }

}
