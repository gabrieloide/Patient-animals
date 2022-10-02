using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartIntro : MonoBehaviour
{
    public GameObject carpetIntro;
    public GameObject panelBackground;
    public GameObject textZeroTo;
    public GameObject textHour;
    public GameObject[] textMessage;
    public bool intro;
    private bool pressSpace;
    private int i=0;
    private float cont;

    void Start()
    {
        intro = true;
        pressSpace = false;
        cont = 0;
    }

    void Update()
    {
        if (intro)
        {
            cont += Time.deltaTime;
        }
        
        if(cont >= 1)
        {
            Time.timeScale = 0;
            cont = 0;
            pressSpace = true;
        }

        if (intro && pressSpace == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (i == 0)
                {
                    textMessage[0].SetActive(false);
                    textMessage[1].SetActive(true);
                    i++;
                }
                else if (i == 1)
                {
                    textMessage[1].SetActive(false);
                    textMessage[2].SetActive(true);
                    i++;
                }
                else if (i == 2)
                {
                    intro = false;
                    Time.timeScale = 1;
                    carpetIntro.SetActive(false);
                    panelBackground.SetActive(false);
                    textZeroTo.SetActive(true);
                    textHour.SetActive(true);
                }
            }
        }
    }

    
}
