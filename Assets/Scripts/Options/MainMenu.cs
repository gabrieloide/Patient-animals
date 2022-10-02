using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float transitionTime;
    Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void PlayGame()
    {
        StartCoroutine(SceneLoad(1));
    }

    public void OpenCredits()
    {
        StartCoroutine(SceneLoad(2));
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        StartCoroutine(SceneLoad(0));
    }
    public void PlaySoundButton()
    {
        FindObjectOfType<AudioSFXManager>().Play("ButtonSound");
    }
    public IEnumerator SceneLoad(int sceneIndex)
    {
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
