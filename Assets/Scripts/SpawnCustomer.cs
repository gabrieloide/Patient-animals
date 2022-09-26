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

        if (ocupedTables[0] && ocupedTables[1] && ocupedTables[2] && ocupedTables[3] && ocupedTables[4] && ocupedTables[5] && ocupedTables[6] && ocupedTables[7] && ocupedTables[8] && ocupedTables[9])
        {
            Debug.Log("todas ocupadas");
            allTablesOcuped = true;
        }
        else
        {
            allTablesOcuped = false;
        }

        if (tableFree == true && allTablesOcuped == false)
        {
            tableFree = false;
            StartCoroutine(Spawn ());
        }

    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(customers[UnityEngine.Random.Range(0, 3)], new Vector2(0, 3.3f), Quaternion.identity);
        tableFree = true;
        
    }
}
