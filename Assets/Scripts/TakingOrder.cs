using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingOrder : MonoBehaviour
{
    public GameObject[] Meal;
    public GameObject Player;
    int i;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Order(i);
        }
    }
    public void Order(int i)
    {
        Instantiate(Meal[i], transform.position, Quaternion.identity);
    }
}
