using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBotheting : MonoBehaviour
{
    public GameObject[] states;
    public float timeStatus;
    public bool si;
    public int amountNumberUp1;
    public float timeNumberUp1;
    public int amountNumberUp2;
    public float timeNumberUp2;
    public int k=1; //para descativar el anterior
    public bool j; //para script CustomerGoingOut
    IEnumerator myCoroutine;

    void Start()
    {
        si = true;
        j = false;
        myCoroutine = ShowStatus();
    }

    void Update()
    {
        if (gameObject.GetComponent<CustomerToTable>().inTable && si)
        {
            StartCoroutine(myCoroutine);
            si = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(myCoroutine);
        }
    }

    IEnumerator ShowStatus()
    {      
        for (int i=0; i<=4 ; i++)
        {
            states[i].SetActive(true);
            if (i == 2)
            {
                //StartCoroutine(GameObject.Find("zeroTo").GetComponent<GeneralBarDisgusting>().NumberUp(amountNumberUp1 ,timeNumberUp1));
                //GameObject.Find("zeroTo").GetComponent<GeneralBarDisgusting>().StartC(amountNumberUp1, timeNumberUp1);
                GameObject.Find("zeroTo").GetComponent<GeneralBarDisgusting>().run1(amountNumberUp1, timeNumberUp1);
                
            }
            if (i == 4)
            {
                //StartCoroutine(GameObject.Find("zeroTo").GetComponent<GeneralBarDisgusting>().NumberUp(amountNumberUp2 ,timeNumberUp2));
                //GameObject.Find("zeroTo").GetComponent<GeneralBarDisgusting>().StartC(amountNumberUp2, timeNumberUp2);
                GameObject.Find("zeroTo").GetComponent<GeneralBarDisgusting>().run2(amountNumberUp2, timeNumberUp2);
                
                j = true;
            }
            yield return new WaitForSeconds(timeStatus);
            states[i].SetActive(false);
        }

    }
}
