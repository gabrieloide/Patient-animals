using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralBarDisgusting : MonoBehaviour
{
    public Text text;
    public int number;
    public GameObject panelGameOver;
    public GameObject textHour;

    public int amountNumberUp1;
    public float timeNumberUp1;
    public int amountNumberUp2;
    public float timeNumberUp2;
    public float time1;
    public float time2;
    public bool timeRun1 = false;
    public bool timeRun2 = false;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        text.text = number + "/100";

        if (timeRun1)
        {
            time1 += Time.deltaTime;
            if (timeNumberUp1 < time1)
            {
                GameObject.Find("zeroTo").GetComponent<GeneralBarDisgusting>().number++;
                time1 = 0;
                amountNumberUp1--;
            }
            if (amountNumberUp1 == 0)
            {
                timeRun1 = false;
            }
        }
        if (timeRun2)
        {
            time2 += Time.deltaTime;
            if (timeNumberUp2 < time2)
            {
                GameObject.Find("zeroTo").GetComponent<GeneralBarDisgusting>().number++;
                time2 = 0;
                amountNumberUp2--;
            }
            if (amountNumberUp2 == 0)
            {
                timeRun2 = false;
            }
        }

        if (number >= 25 && number < 50 && AudioMusicManager.instance.musicOnPlay[0])
        {
            AudioMusicManager.instance.PlayMusic2();
        }
        else if (number >= 50 && number < 75 && AudioMusicManager.instance.musicOnPlay[1])
        {
            AudioMusicManager.instance.PlayMusic3();
        }
        else if (number >= 75 && number < 100 && AudioMusicManager.instance.musicOnPlay[2])
        {
            AudioMusicManager.instance.PlayMusic4();
        }
        
        if (number >= 100)
        {
            AudioMusicManager.instance.StopMusic();
            GameOver();
        }
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        textHour.SetActive(false);
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void run1()
    {
        amountNumberUp1 = 10;
        timeRun1 = true;
    }
    public void run2()
    {
        amountNumberUp2 = 15;
        timeRun2 = true;
    }

    /*
    public IEnumerator NumberUp(int bucleTimes, float seconds)
    {
        for(int i=0 ; i<bucleTimes ; i++)
        {
            number += 1;
            yield return new WaitForSeconds(seconds);
        }
    }*/
    
}
