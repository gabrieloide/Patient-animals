using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public GameObject[] Meal;
    public float timeToWithdrawal;
    bool CanOrder = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && CanOrder)
        {
            StartCoroutine(CanWithdrawal(9));

        }
    }
    IEnumerator CanWithdrawal(int IN)
    {
        yield return new WaitForSeconds(timeToWithdrawal);
        Instantiate(Meal[IN], transform.position, Quaternion.identity);
        FindObjectOfType<PlayerController>().Mealqueue.Dequeue();
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
