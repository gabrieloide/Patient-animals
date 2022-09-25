using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralBarDisgusting : MonoBehaviour
{
    public Text text;
    public int number;
    public GameObject panelGameOver;

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

        if (number>=100)
        {
            //text.text = "Game Over";
            GameOver();
        }

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
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void run1(int a, float b)
    {
        amountNumberUp1 = a;
        timeNumberUp1 = b;
        timeRun1 = true;
    }
    public void run2(int a, float b)
    {
        amountNumberUp2 = a;
        timeNumberUp2 = b;
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
