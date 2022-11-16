using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HourTiming : MonoBehaviour
{
    public Text text;
    public float time;
    public string ampm;
    public int hour;
    public int minuts;
    public bool win;

    public GameObject hourInGame;
    public GameObject panelBackground;
    public GameObject panelWin;
    public GameObject textZeroTo;

    void Start()
    {
        text = hourInGame.GetComponent<Text>();
        hour = 10;
        win = false;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Time.timeScale = 2;
        }


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

        if (win)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }

    public void YouWin()
    {
        win = true;
        Time.timeScale = 0;
        AudioMusicManager.instance.StopMusic();
        panelBackground.SetActive(true);
        panelWin.SetActive(true);
        textZeroTo.SetActive(false);
        hourInGame.SetActive(false);
    }
}
