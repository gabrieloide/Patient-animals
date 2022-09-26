using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCredits : MonoBehaviour
{
    Animator animator;
    public float TimeToTransition;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
            StartCoroutine(ChangeScene(0));  
    }
    IEnumerator ChangeScene(int indexScene)
    {
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(TimeToTransition);
        SceneManager.LoadScene(indexScene);

    }
}
