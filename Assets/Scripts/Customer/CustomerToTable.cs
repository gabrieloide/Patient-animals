using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerToTable : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool inTable;
    public int numberTable;
    public bool[] ocupedTables;
    public bool s;
    
    public Transform[] tables;

    void Start()
    {
        ocupedTables = new bool[10];

        s = true;
        checkNumberTable();
        inTable = false;
    }


    void Update()
    {
        //move to table
        if (inTable == false)
        {
            Vector2 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }

        //stop move
        if (transform.position.x - target.position.x <= 0.01 && transform.position.y - target.position.y <= 0.01)
        {
            inTable = true;
        }
    }

    public void checkNumberTable()
    {
        tables[0] = GameObject.Find("Table0").GetComponent<Transform>();
        tables[1] = GameObject.Find("Table1").GetComponent<Transform>();
        tables[2] = GameObject.Find("Table2").GetComponent<Transform>();
        tables[3] = GameObject.Find("Table3").GetComponent<Transform>();
        tables[4] = GameObject.Find("Table4").GetComponent<Transform>();
        tables[5] = GameObject.Find("Table5").GetComponent<Transform>();
        tables[6] = GameObject.Find("Table6").GetComponent<Transform>();
        tables[7] = GameObject.Find("Table7").GetComponent<Transform>();
        tables[8] = GameObject.Find("Table8").GetComponent<Transform>();
        tables[9] = GameObject.Find("Table9").GetComponent<Transform>();


        //set bool ocuped table
        for (int i = 0; i <= 9; i++)
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


        //select target
        if (ocupedTables[0] && ocupedTables[1] && ocupedTables[2] && ocupedTables[3] && ocupedTables[4] && ocupedTables[5] && ocupedTables[6] && ocupedTables[7] && ocupedTables[8] && ocupedTables[9])
        {
            s = false;
        }
        else
        {
            while (s == true)
            {
                numberTable = Random.Range(0, 10);
                Debug.Log(numberTable);
                target = tables[numberTable];

                if (ocupedTables[numberTable] == false)
                {
                    s = false;
                }
            }
        }
    }
}
