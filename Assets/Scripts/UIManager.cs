using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI Element GameObjects
    public GameObject gameTimeUI;
    public GameObject percentCompleteUI;
    public GameObject batteryLifeUI;

    //Text Elements
    private TextMeshProUGUI gameTimeText;
    private TextMeshProUGUI percentCompleteText;
    private Slider batteryLifeSlider;

    public float batteryDrainRate = .1f;
    public float batteryValue;
    private float batteryDrainTimer = 0f;
    private float lastTimer;
    void Start(){
        //Grab the Text Elements from the UI Elements
        gameTimeText = gameTimeUI.GetComponent<TextMeshProUGUI>();
        percentCompleteText = percentCompleteUI.GetComponent<TextMeshProUGUI>();
        batteryLifeSlider = batteryLifeUI.GetComponent<Slider>();

        //Set the immediate values
        gameTimeText.text = $"Time: {Mathf.Round(Time.time)}";
        percentCompleteText.text = "0%";
        batteryLifeSlider.value = 1;
        batteryValue = batteryLifeSlider.value;
        batteryDrainTimer = Time.time;
    }

    private void ReduceBatteryLife(){
        batteryLifeSlider.value -= batteryDrainRate;
        batteryValue = batteryLifeSlider.value;
        batteryDrainTimer = Time.time;
    }

    void Update(){

        gameTimeText.text = $"Time: {Mathf.Round(Time.time)}";
        if(Time.time - batteryDrainTimer > 5){
            ReduceBatteryLife();
        }
    }
}
