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
        ocupedTables = new bool[5];

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


        //set bool ocuped table
        /*for (int i = 0; i >= 4; i++)
        {
            if (tables[i].GetComponent<TableOcuped>().isOcuped == true)
            {
                ocupedTables[i] = true;
            }
            else
            {
                ocupedTables[i] = false;
            }
        }*/

    }

    public void checkNumberTable()
    {
        //set bool ocuped table
        if (tables[0].GetComponent<TableOcuped>().isOcuped == true)
        {
            ocupedTables[0] = true;
        }
        else
        {
            ocupedTables[0] = false;
        }

        if (tables[1].GetComponent<TableOcuped>().isOcuped == true)
        {
            ocupedTables[1] = true;
        }
        else
        {
            ocupedTables[1] = false;
        }

        if (tables[2].GetComponent<TableOcuped>().isOcuped == true)
        {
            ocupedTables[2] = true;
        }
        else
        {
            ocupedTables[2] = false;
        }

        if (tables[3].GetComponent<TableOcuped>().isOcuped == true)
        {
            ocupedTables[3] = true;
        }
        else
        {
            ocupedTables[3] = false;
        }

        if (tables[4].GetComponent<TableOcuped>().isOcuped == true)
        {
            ocupedTables[4] = true;
        }
        else
        {
            ocupedTables[4] = false;
        }

        //select target
        if (ocupedTables[0] == true && ocupedTables[1] == true && ocupedTables[2] == true && ocupedTables[3] == true && ocupedTables[4] == true)
        {
            Debug.Log("todas ocupadas");
            s = false;
        }
        else
        {
            while (s == true)
            {
                numberTable = UnityEngine.Random.Range(0, 5);
                target = tables[numberTable];
                Debug.Log(numberTable);

                if (ocupedTables[numberTable] == false)
                {
                    s = false;
                }
            }
        }
    }

}
