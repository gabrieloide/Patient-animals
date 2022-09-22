using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableOcuped : MonoBehaviour
{
    public bool isOcuped;

    void Start()
    {
        isOcuped = false;
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOcuped = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOcuped = false;
        }
    }
}
