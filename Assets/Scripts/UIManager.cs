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

    void Start(){
        //Grab the Text Elements from the UI Elements
        gameTimeText = gameTimeUI.GetComponent<TextMeshProUGUI>();
        percentCompleteText = percentCompleteUI.GetComponent<TextMeshProUGUI>();
        batteryLifeSlider = batteryLifeUI.GetComponent<Slider>();

        //Set the immediate values
        gameTimeText.text = $"Time: {Mathf.Round(Time.time)}";
        percentCompleteText.text = "0%";
        batteryLifeSlider.value = 1;
    }

    void Update(){

        gameTimeText.text = $"Time: {Mathf.Round(Time.time)}";
        if(Time.time % 5f == 0){
            batteryLifeSlider.value -= batteryDrainRate;
        }
    }
}
