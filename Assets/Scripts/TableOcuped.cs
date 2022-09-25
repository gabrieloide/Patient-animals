using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableOcuped : MonoBehaviour
{
    public bool isOcuped = false;
    public int i = 0;
    void Update()
    {
        if (i==0)
        {
            isOcuped = false;
        }
        else
        {
            isOcuped = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Customer"))
        {
            i++;
        } 
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Customer"))
        {
            i--;
        }
    }
    
}
