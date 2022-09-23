using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    public bool tableFree;
    public bool allTablesOcuped;

    public GameObject[] customers;
    public float timeToSpawn;


    private void Start()
    {
        tableFree = true;
        allTablesOcuped = false;
    }

    void Update()
    {
        if (GameObject.Find("Table0").GetComponent<TableOcuped>().isOcuped==true && GameObject.Find("Table1").GetComponent<TableOcuped>().isOcuped == true && GameObject.Find("Table2").GetComponent<TableOcuped>().isOcuped == true && GameObject.Find("Table3").GetComponent<TableOcuped>().isOcuped == true && GameObject.Find("Table4").GetComponent<TableOcuped>().isOcuped == true)
        {
            allTablesOcuped = true;
        }
        else
        {
            allTablesOcuped = false;
        }

        if (tableFree == true && allTablesOcuped == false)
        {
            tableFree = false;
            StartCoroutine(Asd());
        }

    }

    IEnumerator Asd()
    {
        Instantiate(customers[UnityEngine.Random.Range(0, 1)], new Vector2(0, 4), Quaternion.identity);
        yield return new WaitForSeconds(timeToSpawn);
        tableFree = true;
        
    }
}
