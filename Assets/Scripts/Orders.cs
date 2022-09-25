using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public GameObject[] Meal;
    public List<int> MealList = new List<int>();
    public float timeToWithdrawal;
    bool CanOrder = false;
    //Queue Mealqueue;

    private void Start()
    {
       // Queue myQueue = new Queue();
       //
       // myQueue.Enqueue(1);
       // myQueue.Enqueue(3);
       // myQueue.Enqueue(2);
       // myQueue.Enqueue(3);
       // myQueue.Enqueue(3);
       // foreach (var item in myQueue)
       //      {
       //          Debug.Log("Elementos en q son " + item);
       //      }
    }
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
        if (FindObjectOfType<PlayerController>().Mealqueue.Peek() == null)
        {
            Debug.Log("ff");
        }
        
        if (Input.GetKeyDown(KeyCode.P) && CanOrder)
        {
            Instantiate(Meal[IN], transform.position, Quaternion.identity);
            StartCoroutine(CanWithdrawal());
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
