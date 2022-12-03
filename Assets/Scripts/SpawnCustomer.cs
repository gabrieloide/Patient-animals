using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    public bool tableFree;
    public bool allTablesOcuped;

    public GameObject[] customers;
    public Transform[] tables;
    public bool[] ocupedTables;
    public float timeToSpawn;


    private void Start()
    {
        tableFree = true;
        allTablesOcuped = false;
    }
    void Update()
    {
        for (int i=0; i<=9 ; i++)
        {
            if (tables[i].GetComponent<TableOcuped>().isOcuped == true)
            {
                ocupedTables[i] = true;
            }
            else
            {
                ocupedTables[i] = false;
            }
        }
        bool L = true;
        for (int i = 0; i < ocupedTables.Length; i++)
        {
            L &= ocupedTables[i];
        }
        if (L)
        {
            allTablesOcuped = true;
        }
        else
        {
            allTablesOcuped = false;
        }
        if (tableFree)
        {
            tableFree = false;
            StartCoroutine(Spawn ());
        }
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeToSpawn);
        if (!allTablesOcuped)
        {
            Instantiate(customers[Random.Range(0, 4)], new Vector2(0, 3.3f), Quaternion.identity);
        }
        tableFree = true;
    }
}
public class Customers
{


    public Customers(GameObject _customer, int _Meal)
    {
        
    }
}
