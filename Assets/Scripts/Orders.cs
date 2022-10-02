using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public GameObject[] Meal;
    public float timeToWithdrawal;
    bool CanOrder = false;
    //Queue Mealqueue;

    void Update()
    {
        if (FindObjectOfType<PlayerController>().Mealqueue.Count <= 0)
        {
            FindObjectOfType<PlayerController>().Mealqueue.Enqueue(4);
        }
        else if(FindObjectOfType<PlayerController>().Mealqueue.Count >= 2)
        {
           FindObjectOfType<PlayerController>().Mealqueue.Dequeue();

        }

        string i = FindObjectOfType<PlayerController>().Mealqueue.Peek().ToString();
            int IN = int.Parse(i);
        
        if (Input.GetKeyDown(KeyCode.J) && CanOrder)
        {
            StartCoroutine(CanWithdrawal());
            Instantiate(Meal[IN], transform.position, Quaternion.identity);
            FindObjectOfType<PlayerController>().Mealqueue.Dequeue();
        }
    }
    IEnumerator CanWithdrawal()
    {
        yield return new WaitForSeconds(timeToWithdrawal);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanOrder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanOrder = false;
        }
    }
}
