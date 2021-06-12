using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //GameObjects and Transforms
    public GameObject playerToChase;
    private Transform player;
    private Transform enemy;

    //Private Variables
    private float distanceCovered;
    void Start(){
        enemy = this.transform;
        player = playerToChase.transform;
        
    }

    void Update(){
        //LERP to the player. Lerp(starting position, ending position, percentage of journey to conver);
        //Unity Documentation offers a cool idea here. Make the percentage a percent of the journey covered
        distanceCovered = Time.time / 50000f;
        enemy.position = Vector3.Lerp(enemy.position, player.position, distanceCovered);

    }
}


