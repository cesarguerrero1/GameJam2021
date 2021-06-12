using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerGameInteraction : MonoBehaviour
{
    
    public GameObject GameManager;
    private GameStateManager GameStateManager;
    private bool isPaused = false;
    
    void Start(){
        GameStateManager = GameManager.GetComponent<GameStateManager>();
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

}
