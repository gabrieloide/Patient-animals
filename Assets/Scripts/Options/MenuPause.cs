using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panelPauseBackground;
    public GameObject textZeroTo;
    public bool IsPaused;

    private void Start()
    {
        IsPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused)
            {
                Resume();
                textZeroTo.SetActive(true);
            }
            else
            {
                Pause();
                textZeroTo.SetActive(false);
                panel1.SetActive(true);
                panel2.SetActive(false);
            }
        }
    }

    public void activeZeroTo()
    {
        textZeroTo.SetActive(true);
    }
    public void Pause()
    {
        panelPause.SetActive(true);
        panelPauseBackground.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
    }
    public void Resume()
    {
        panelPause.SetActive(false);
        panelPauseBackground.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }
}
