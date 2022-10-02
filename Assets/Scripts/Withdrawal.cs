using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Withdrawal : MonoBehaviour
{
    bool canWitdhdrawal = false;
    public int orderNumber;
    bool canThrowAway;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.parent = FindObjectOfType<PlayerController>().gameObject.transform;
        }
        if (Input.GetKeyDown(KeyCode.K) && canThrowAway)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canWitdhdrawal = true;
        }
        if (collision.gameObject.CompareTag("Basura"))
        {
            canThrowAway = true;
        }
        if (collision.gameObject.CompareTag("Customer"))
        {
            canThrowAway = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canWitdhdrawal = false;
        }
        if (collision.gameObject.CompareTag("Basura"))
        {
            canThrowAway = false;
        }
        if (collision.gameObject.CompareTag("Customer"))
        {
            canThrowAway = false;
        }
    }
}
