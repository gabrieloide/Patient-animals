using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HourTiming : MonoBehaviour
{
    public Text text;
    public float time;
    public string ampm;
    public int hour;
    public int minuts;

    public GameObject panelWin;
    public GameObject textZeroTo;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
        hour = 10;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (minuts < 10)
        {
            text.text = hour + ":0" + minuts + ampm;

        }
        else
        {
            text.text = hour + ":" + minuts + ampm;

        }
        if(hour > 7 && hour < 12)
        {
            ampm = "am";
        }
        else
        {
            ampm = "pm";
        }


        if (time>=1)
        {
            minuts++;
            time = 0;
        }
        if(minuts == 60)
        {
            hour++;
            minuts = 0;
        }
        if (hour > 12)
        {
            hour = 1;
        }

        if (hour == 6)
        {
            YouWin();
        }
    }

    public void YouWin()
    {
        Time.timeScale = 0;
        AudioMusicManager.instance.StopMusic();
        panelWin.SetActive(true);
        textZeroTo.SetActive(false);
        gameObject.SetActive(false);
    }
}
