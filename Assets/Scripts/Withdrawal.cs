using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Withdrawal : MonoBehaviour
{
    bool canWitdhdrawal = false;
    public int orderNumber;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.parent =FindObjectOfType<PlayerController>().gameObject.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canWitdhdrawal = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canWitdhdrawal = false;
        }
    }
}
