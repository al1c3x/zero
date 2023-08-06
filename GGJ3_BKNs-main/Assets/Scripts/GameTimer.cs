using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float timerValue = 0.0f;
    private int minuteVal = 0;
    private float secondVal = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //call the timer to run
        RunTimer();
        Debug.Log(GetElapsedGameTime());
    }

    private void RunTimer()
    {
        timerValue += Time.deltaTime;
    }

    public string GetElapsedGameTime()
    {
        minuteVal = ((int)timerValue) / 60;
        secondVal = timerValue % 60;

        return string.Format(minuteVal + ":" + "{0:#0.00}", secondVal);
    }
}
