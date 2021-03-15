using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public PlayerRigidbodyController rigidbodyController;

    public int currentMomentum;
    public int maxMomentum;

    public Slider momentumSlider;
    public TextMeshProUGUI speedText;

    //public TextMeshProUGUI fpsText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI stopwatchText;

    public TextMeshProUGUI bannerText;

    public float maxTimer;

    public float timer;
    public float seconds;
    public float minutes;
    

    private void Awake()
    {
        timer = maxTimer;

        momentumSlider.minValue = 0;
        momentumSlider.maxValue = maxMomentum;
    }

    private void Update()
    {
       
        //stopwatchText.text = minutes.ToString() +":"+ seconds.ToString();
        timerText.text = timer.ToString("f0");


        momentumSlider.value = currentMomentum;
        speedText.text = Mathf.RoundToInt(rigidbodyController.moveX).ToString();
        //momentumText.text = currentMomentum.ToString();
        currentMomentum = Mathf.Clamp(currentMomentum,0,maxMomentum);

        timer -= Time.deltaTime;


        if (timer <= 9)
        {
            timerText.text = "0" + timer.ToString("f0");
        }

        if (rigidbodyController.moveXRaw!= 0)
        {
            currentMomentum += 1;
        }

        else
        {
            currentMomentum -= 1;
        }
    }

    public void StopWatch()
    {
        string secondsString = "0" + seconds.ToString("f2");
        string minutesString = "0" + minutes.ToString();
        stopwatchText.text = minutesString + ":" + secondsString; 

        seconds += Time.deltaTime;
        if (seconds>=9)
        {
           secondsString = seconds.ToString("f2");
        }

        if (minutes >= 9)
        {
            minutesString= minutes.ToString();
        }


        if (seconds >= 60)
        {
            seconds = 0;
            minutes += 1;
        }
    }

    public void TimeOut()
    {

    }
}
